using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalItems { get; set; }

        [Required]
        [MaxLength(20)]
        public string CartStatus { get; set; } = string.Empty;

        [Range(0, 100)]
        public double Discount { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
