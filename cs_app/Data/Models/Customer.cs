using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cs_app.Data.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public long Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportDetails { get; set; }
   
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

}
