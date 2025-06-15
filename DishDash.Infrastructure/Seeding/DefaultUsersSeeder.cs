using DishDash.Domain.Entities;
using DishDash.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace DishDash.Infrastructure.Seeding
{
    public static class DefaultUsersSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@dishdash.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "P@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, nameof(UserRole.Admin));
                }
            }
        }
    }
}
