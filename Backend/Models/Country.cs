using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Country : BaseEntity
    {
        public Country(string CountryName)
        {
            this.CountryName = CountryName;
        }


        public string CountryName { get; set; } = "";
    }
}
