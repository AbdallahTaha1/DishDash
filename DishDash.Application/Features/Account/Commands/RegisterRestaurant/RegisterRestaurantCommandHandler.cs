using DishDash.Application.Interfaces;
using MediatR;

namespace DishDash.Application.Features.Account.Commands.RegisterRestaurant
{
    public class RegisterRestaurantCommandHandler : IRequestHandler<RegisterRestaurantCommand, AuthResultDto>
    {
        private readonly IAuthService _authService;

        public RegisterRestaurantCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResultDto> Handle(RegisterRestaurantCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterRestaurant(request);
        }
    }
}
