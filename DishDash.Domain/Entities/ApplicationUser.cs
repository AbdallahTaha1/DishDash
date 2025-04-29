using Microsoft.AspNetCore.Identity;

namespace DishDash.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

    }
}
