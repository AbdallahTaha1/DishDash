using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class Customer
    {
        [Key]
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; } = default!;
        public int CartId { get; set; }
        public Cart Cart { get; set; } = default!;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
