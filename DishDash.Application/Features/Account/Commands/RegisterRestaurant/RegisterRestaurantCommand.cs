using MediatR;

namespace DishDash.Application.Features.Account.Commands.RegisterRestaurant
{
    public class RegisterRestaurantCommand : IRequest<AuthResultDto>
    {

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }

    }
}
