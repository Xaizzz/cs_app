namespace cs_app.Data.DTOs
{
    public class CustomerDTO
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PassportDetails { get; set; }

        public IEnumerable<long> Orders { get; set; }
        public IEnumerable<long> Items { get; set; }
    }
}