using DishDash.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace DishDash.Infrastructure.Seeding
{
    public static class RolesSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            var roles = Enum.GetNames(typeof(UserRole));
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

        }
    }
}
