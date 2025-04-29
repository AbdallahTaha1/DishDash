namespace DishDash.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;

    }
}
