using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        public int RestauranId { get; set; }

        [Required]
        public Restaurant Restaurant { get; set; } = default!;

        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
