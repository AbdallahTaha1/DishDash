using DishDash.Application.Interfaces;
using MediatR;

namespace DishDash.Application.Features.Account.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResultDto>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public Task<AuthResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return _authService.LoginAsync(request);
        }
    }
}
