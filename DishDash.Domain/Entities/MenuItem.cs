using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Ingredients { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public int MenuId { get; set; }

        [Required]
        public Menu Menu { get; set; } = default!;
    }
}
