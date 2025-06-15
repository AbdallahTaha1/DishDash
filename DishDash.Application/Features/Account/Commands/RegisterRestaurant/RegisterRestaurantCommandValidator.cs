using FluentValidation;

namespace DishDash.Application.Features.Account.Commands.RegisterRestaurant
{
    public class RegisterRestaurantCommandValidator : AbstractValidator<RegisterRestaurantCommand>
    {
        public RegisterRestaurantCommandValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Restaurant name is required.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description can't exceed 500 characters.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.")
                .MaximumLength(200).WithMessage("Location can't exceed 200 characters.");

            RuleFor(x => x.OpeningTime)
                .NotEmpty().WithMessage("Opening time is required.");

            RuleFor(x => x.ClosingTime)
                .NotEmpty().WithMessage("Closing time is required.")
                .GreaterThan(x => x.OpeningTime).WithMessage("Closing time must be after opening time.");
        }
    }
}
