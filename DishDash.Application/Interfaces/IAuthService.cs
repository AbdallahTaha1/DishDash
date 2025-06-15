using DishDash.Application.Features.Account;
using DishDash.Application.Features.Account.Commands.Login;
using DishDash.Application.Features.Account.Commands.RegisterCustomer;
using DishDash.Application.Features.Account.Commands.RegisterRestaurant;

namespace DishDash.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(LoginCommand request);
        Task<AuthResultDto> RegisterCustomer(RegisterCustomerCommand request);
        Task<AuthResultDto> RegisterRestaurant(RegisterRestaurantCommand request);

    }
}
