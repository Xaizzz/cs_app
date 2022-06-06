using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Models
{
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportDetails { get; set; }
   
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }

}
