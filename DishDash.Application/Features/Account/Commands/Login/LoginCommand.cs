using MediatR;

namespace DishDash.Application.Features.Account.Commands.Login
{
    public class LoginCommand : IRequest<AuthResultDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
