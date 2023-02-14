using Backend.Models;

namespace Backend.ApiModels
{
    public class PostCustomerApiModelTemp
    {
        public PostCustomerApiModelTemp()
        {
            this.Customer = new CustomerTemp();
            this.CustomerAddresses = new List<CustomerAddress>();
        }
        public CustomerTemp Customer { get; set; }
        public List<CustomerAddress> CustomerAddresses { get; set; }

    }
    public class CustomerTemp
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public byte[]  CustomerPhoto { get; set; }

    }

    public class PostCustomerApiModelTempAdd
    {
        Stream RecievedImage { get; set; }

        PostCustomerApiModelTemp Data { get; set; }
    }


}
