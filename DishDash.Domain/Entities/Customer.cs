using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(20)]
        public string LastName { get; set; } = string.Empty;

        [Required, Phone, MaxLength(20)]
        public string ContactNumber { get; set; } = string.Empty;

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public int CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = default!;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public string FullName => $"{FirstName} {LastName}";
    }
}
