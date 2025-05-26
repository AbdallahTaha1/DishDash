using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        [Required]
        [MaxLength(30)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string PaymentStatus { get; set; } = string.Empty;

    }
}
