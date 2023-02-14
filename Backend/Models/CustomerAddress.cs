using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class CustomerAddress : BaseEntity
    {
        public int CustomerId { get; set; }
        public string Address { get; set; }
    }
}
