namespace DishDash.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderTime { get; set; }
        public double TotalPrice { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; } = default!;
        public int PaymentId { get; set; }
        public Payment Payment { get; set; } = default!;
    }
}
