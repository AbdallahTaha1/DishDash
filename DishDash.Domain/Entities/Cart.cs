namespace DishDash.Domain.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public double TotalPrice { get; set; }
        public int TotalItems { get; set; }
        public string CartStatus { get; set; } = string.Empty;
        public double discount { get; set; }

        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
    }
}
