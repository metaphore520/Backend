using Backend.ApiModels;
using Backend.Contracts;
using Backend.DatabaseContext;
using Backend.Models;
using Newtonsoft.Json;

namespace Backend.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCustomer(PostCustomerApiModelNew model)
        {
            try
            {
                List<CustomerAddress> listData = new List<CustomerAddress>();
                Customer customer = new Customer();
                HelperService.MapCustomer(model.Customer,customer);
                Console.WriteLine("");
                this._unitOfWork.CustomerRepository.Add(customer);
                List<CustomerAddress> incomingList = new List<CustomerAddress>();
                incomingList = JsonConvert.DeserializeObject<List<CustomerAddress>>(model.CustomerAddresses);
                var customerId = this._unitOfWork.CustomerRepository.GetNextId();
                foreach (var item in incomingList)
                {
                    if (item.Address.Count() > 0)
                    {
                        item.CustomerId = customerId;
                        listData.Add(item);
                    }
                }
                await this._unitOfWork.CustomerAddressRepository.BulkAdd(listData);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public async Task<GetCustomerApiModel> GetAllCustomer()
        {
            Task<List<Customer>> lisDataTask = this._unitOfWork.CustomerRepository.GetAllCustomer();
            lisDataTask.Wait();
            GetCustomerApiModel model = new GetCustomerApiModel(lisDataTask.Result);
            return model;
        }
        public async Task<GetCustomerByIdApiModel> GetCustomerById(int id)
        {
            Task<Customer> customerTask = this._unitOfWork.CustomerRepository.GetCustomerById(id);
            customerTask.Wait();
            GetCustomerByIdApiModel model = new GetCustomerByIdApiModel(customerTask.Result);
            return model;
        }
        public async Task EditCustomer(PostCustomerApiModelNew model)
        {
            var customerId = model.Customer.Id;
            try
            {
                Customer customer = new Customer();
                HelperService.MapCustomer(model.Customer,customer);

                List<CustomerAddress> listData = new List<CustomerAddress>();
                this._unitOfWork.CustomerRepository.Edit(customer);


                List<CustomerAddress> incomingAddresses =
                  JsonConvert.DeserializeObject<List<CustomerAddress>>(model.CustomerAddresses);
                Task<IEnumerable<CustomerAddress>> taskCustomerData =
                     this._unitOfWork.CustomerAddressRepository.Get(x => x.CustomerId == customerId);

                taskCustomerData.Wait();

                IEnumerable<CustomerAddress> dbData = taskCustomerData.Result;

                for (int i = 0; i < dbData.Count(); i++)
                {
                    var val = incomingAddresses.Where(x => x.Id == dbData.ElementAt(i).Id);
                    if (val.Count() == 0)
                    {
                        await this._unitOfWork.CustomerAddressRepository.Delete(dbData.ElementAt(i));
                    }
                }
              
                foreach (var item in incomingAddresses)
                {
                    if (item.Address.Count() > 0)
                    {
                        item.CustomerId = customerId;
                        if (item.Id > 0)
                        {
                            this._unitOfWork.CustomerAddressRepository.Edit(item);
                        }
                        else
                        {
                            this._unitOfWork.CustomerAddressRepository.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
        public async Task DeleteCustomerById(int id)
        {
            Task<GetCustomerByIdApiModel> dataTask = GetCustomerById(id);
            dataTask.Wait();
           
            var customer = dataTask.Result.Customer;
            await this._unitOfWork.CustomerRepository.Delete(customer);

            var listAddr = dataTask.Result.Addresses;
            for (int i = 0; i < listAddr.Count(); i++)
            {
                await this._unitOfWork.CustomerAddressRepository.Delete(listAddr[i]);
            }

        }
    }
}
