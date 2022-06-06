namespace cs_app.Data.DTOs
{
    public class ItemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string CompanyName { get; set; }
        public string QuantityInStock { get; set; }
        public string DateOfService { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
        public IEnumerable<long> Orders { get; set; }
        public IEnumerable<long> Customers { get; set; }
    }
}