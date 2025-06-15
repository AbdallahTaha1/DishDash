using DishDash.Application.Features.Account.Commands.Login;
using DishDash.Application.Features.Account.Commands.RegisterCustomer;
using DishDash.Application.Features.Account.Commands.RegisterRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DishDash.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("register-customer")]
        public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
        {
            return Ok(await _sender.Send(command));
        }
        [HttpPost("register-restaurant")]
        public async Task<IActionResult> RegisterRestaurant(RegisterRestaurantCommand command)
        {
            return Ok(await _sender.Send(command));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            return Ok(await _sender.Send(command));
        }
    }
}
