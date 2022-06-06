namespace cs_app.Data.DTOs
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public decimal OrderAmount { get; set; }
        public string Customer { get; set; }

        public IEnumerable<long> Items { get; set; }
        public IEnumerable<long> Customers { get; set; }
    }
}