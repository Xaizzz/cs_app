using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cs_app.Data.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]

        public long Id { get; set; }

        public decimal OrderAmount { get; set; }
        public string Customer { get; set; }

        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}