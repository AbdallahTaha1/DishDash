using DishDash.Application.Interfaces;
using MediatR;

namespace DishDash.Application.Features.Account.Commands.RegisterCustomer
{
    public class RegisterCustomerCommandHandler : IRequestHandler<RegisterCustomerCommand, AuthResultDto>
    {
        private readonly IAuthService _authService;

        public RegisterCustomerCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResultDto> Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
        {
            return await _authService.RegisterCustomer(request);
        }
    }
}
