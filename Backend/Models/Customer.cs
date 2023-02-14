using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Customer : BaseEntity
    {
        public int CountryId { get; set; }
        public string CustomerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public byte[] CustomerPhoto { get; set; }


        public virtual List<CustomerAddress> CustomerAddresses { get; set; }
    }
}
