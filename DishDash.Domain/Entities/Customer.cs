using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public ApplicationUser ApplicationUser { get; set; } = default!;

        public int CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = default!;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
