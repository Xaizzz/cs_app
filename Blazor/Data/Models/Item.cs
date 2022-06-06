using Blazor.Data.Models;

namespace Blazor.Data.Models
{
    public class Item
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string CompanyName { get; set; }
        public string QuantityInStock { get; set; }
        public string DateOfService { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}