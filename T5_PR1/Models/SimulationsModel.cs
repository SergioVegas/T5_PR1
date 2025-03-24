using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T5_PR1.Models
{
    public class SimulationsModel
    {
        [Table("Address")]
        public class Address
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }
            public string? Type { get; set; }
            public double City { get; set; }
            public string? PostalCode { get; set; }
        }
    }
}
