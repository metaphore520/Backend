using Backend.Models;

namespace Backend.ApiModels
{
    public class GetCustomerApiModel
    {
        public GetCustomerApiModel()
        {
        }
        public GetCustomerApiModel(List<Customer> listOfCustomer)
        {
            this.Customers = GetModels(listOfCustomer);
        }
        public List<CustomerModel> GetModels(List<Customer> listOfCustomer)
        {
            List<CustomerModel> customerModels = new List<CustomerModel>();
            var customer = new CustomerModel(0, "");
            foreach (var item in listOfCustomer)
            {
                customer = new CustomerModel(item.Id, item.CustomerName);
                customerModels.Add(customer);
            }
            return customerModels;
        }
        public List<CustomerModel> Customers { get; set; }
    }
    public class CustomerModel
    {
        public CustomerModel()
        {
        }
        public CustomerModel(int _Id, string _CustomerName)
        {
            this.Id = _Id;
            this.CustomerName = _CustomerName;
        }
        public int Id { get; set; }
        public string CustomerName { get; set; }
    }


}
