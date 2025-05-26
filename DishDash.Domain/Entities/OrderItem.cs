using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public Order Order { get; set; } = default!;

        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public MenuItem MenuItem { get; set; } = default!;
    }
}
