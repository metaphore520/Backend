using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

    }
}
