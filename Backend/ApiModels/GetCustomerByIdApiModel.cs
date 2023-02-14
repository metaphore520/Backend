using Backend.Models;

namespace Backend.ApiModels
{
    public class GetCustomerByIdApiModel
    {
        public GetCustomerByIdApiModel()
        {

        }
        public GetCustomerByIdApiModel(Customer customer)
        {
            GetModel(customer);
        }
        void GetModel(Customer customer)
        {
            this.Addresses = customer.CustomerAddresses;
            customer.CustomerAddresses = null;
            this.Customer = customer;

        }
        public Customer Customer { get; set; }
        public List<CustomerAddress> Addresses { get; set; }
    }
}
