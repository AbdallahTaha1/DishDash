using DishDash.Application.Features.Account;
using DishDash.Application.Features.Account.Commands.Login;
using DishDash.Application.Features.Account.Commands.RegisterCustomer;
using DishDash.Application.Features.Account.Commands.RegisterRestaurant;
using DishDash.Application.Interfaces;
using DishDash.Domain.Entities;
using DishDash.Domain.Enums;
using DishDash.Infrastructure.Authentication.JWT;
using DishDash.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace DishDash.Infrastructure.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IJwtService jwtService)
        {
            _userManager = userManager;
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthResultDto> RegisterCustomer(RegisterCustomerCommand request)
        {
            // ensure that the email is not exist
            var EmailAlreadyExists = await _userManager.FindByEmailAsync(request.Email);
            if (EmailAlreadyExists is not null)
                return new AuthResultDto() { Success = false, Message = "This Email is already Exists!" };

            // request -> Applicatioin user
            var user = new ApplicationUser()
            {
                UserName = request.Email,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthResultDto() { Success = false, Message = errors };
            }

            await _userManager.AddToRoleAsync(user, nameof(UserRole.Customer));

            using var transaction = await _context.Database.BeginTransactionAsync();

            // request -> customer
            var cart = new Cart();
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            var customer = new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ContactNumber = request.ContactNumber,
                ApplicationUserId = user.Id,
                CartId = cart.Id
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            // generate token
            var token = await _jwtService.CreateJwtTokenAsync(user);

            return new AuthResultDto()
            {
                Name = customer.FullName,
                Email = user.Email,
                Roles = new List<string> { UserRole.Customer.ToString() },
                JWTToken = new JwtSecurityTokenHandler().WriteToken(token),
                JWTTokenExpiresOn = token.ValidTo,
                Success = true
            };
        }

        public async Task<AuthResultDto> RegisterRestaurant(RegisterRestaurantCommand request)
        {
            // ensure that the email is not exist
            var EmailAlreadyExists = await _userManager.FindByEmailAsync(request.Email);
            if (EmailAlreadyExists is not null)
                return new AuthResultDto() { Message = "This Email is already Exists!" };

            // request -> Applicatioin user
            var user = new ApplicationUser()
            {
                UserName = request.Email,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AuthResultDto() { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, nameof(UserRole.Restaurant));

            // request -> restaurant
            var restaurant = new Restaurant()
            {
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                OpeningTime = request.OpeningTime,
                ClosingTime = request.ClosingTime,
                ApplicationUserId = user.Id,
            };

            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();

            // generate token
            var token = await _jwtService.CreateJwtTokenAsync(user);

            return new AuthResultDto()
            {
                Name = restaurant.Name,
                Email = user.Email,
                Roles = new List<string> { UserRole.Customer.ToString() },
                JWTToken = new JwtSecurityTokenHandler().WriteToken(token),
                JWTTokenExpiresOn = token.ValidTo,
                Success = true
            };
        }

        public async Task<AuthResultDto> LoginAsync(LoginCommand request)
        {
            // Step 1: Check if user exists
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
                return new AuthResultDto() { Success = false, Message = "Invalid email or password." };

            // Step 2: Verify Password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
                return new AuthResultDto() { Success = false, Message = "Invalid email or password." };

            // Step 3: Get Roles
            var roles = await _userManager.GetRolesAsync(user);

            // Step 4: Generate JWT token
            var token = await _jwtService.CreateJwtTokenAsync(user);

            // Step 5: Get user data
            string name;
            if (roles.Contains(UserRole.Restaurant.ToString()))
            {
                var restaurant = _context.Restaurants.FirstOrDefault(c => c.ApplicationUserId == user.Id);
                name = restaurant?.Name ?? "Unknown Restaurant";
            }
            else if (roles.Contains(UserRole.Customer.ToString()))
            {
                var customer = _context.Customers.FirstOrDefault(c => c.ApplicationUserId == user.Id);
                name = customer?.FullName ?? "Unknown Customer";
            }
            else
                name = user.UserName ?? "User";


            // Step 6: Return Result
            return new AuthResultDto()
            {
                Success = true,
                Name = name,
                Email = request.Email,
                Roles = roles.ToList(),
                JWTToken = new JwtSecurityTokenHandler().WriteToken(token),
                JWTTokenExpiresOn = token.ValidTo
            };
        }
    }
}
