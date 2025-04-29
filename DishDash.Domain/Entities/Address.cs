namespace DishDash.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Government { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
    }
}
