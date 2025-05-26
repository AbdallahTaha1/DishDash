using DishDash.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderTime { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public Address Address { get; set; } = default!;

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; } = default!;

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public Restaurant Restaurant { get; set; } = default!;

        [Required]
        public int PaymentId { get; set; }

        [Required]
        public Payment Payment { get; set; } = default!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
