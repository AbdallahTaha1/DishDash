using DishDash.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace DishDash.Infrastructure.Authentication.JWT
{
    public interface IJwtService
    {
        Task<JwtSecurityToken> CreateJwtTokenAsync(ApplicationUser user);
    }
}
