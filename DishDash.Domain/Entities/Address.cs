using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Government { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

        public int CustomerId { get; set; }

        [Required]
        public Customer Customer { get; set; } = default!;
    }
}
