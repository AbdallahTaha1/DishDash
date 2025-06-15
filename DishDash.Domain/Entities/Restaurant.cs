using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
