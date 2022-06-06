using Blazor.Data.Models;

namespace Blazor.Data.Models
{
    public class Order
    {
        public long Id { get; set; }

        public decimal OrderAmount { get; set; }
        public string Customer { get; set; }

        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Customer> Customers { get; set; }

    }
}