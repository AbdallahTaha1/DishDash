using DishDash.Domain.Entities;
using DishDash.Infrastructure.Authentication.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DishDash.Infrastructure.Authentication.JWT
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwt;
        private readonly UserManager<ApplicationUser> _userManager;
        public JwtService(IOptions<JwtSettings> options, UserManager<ApplicationUser> userManager)
        {
            _jwt = options.Value;
            _userManager = userManager;
        }
        public async Task<JwtSecurityToken> CreateJwtTokenAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var userRoles = await _userManager.GetRolesAsync(user);
            var roleToClaims = new List<Claim>();

            foreach (var role in userRoles)
                roleToClaims.Add(new Claim(ClaimTypes.Role, role));



            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }
            .Union(userClaims)
            .Union(roleToClaims);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                expires: DateTime.Now.AddMinutes(_jwt.ExpirationInMinutes),
                claims: claims,
                signingCredentials: signingCredentials
            );

            return token;
        }
    }
}
