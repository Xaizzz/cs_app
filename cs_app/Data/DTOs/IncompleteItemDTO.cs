namespace cs_app.Data.DTOs
{
    public class IncompleteItemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string CompanyName { get; set; }
        public string QuantityInStock { get; set; }
        public string Description { get; set; }
        public string Parameters { get; set; }
    }
}