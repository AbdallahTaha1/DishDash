using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DishDash.Application.Features.Restaurants.Commands.CreateRestuarant
{
    public class CreateRestuarntCommand : IRequest<RestaurantDto>
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required, MaxLength(20)]
        public string Status { get; set; } = string.Empty;

        [Required]
        public DateTime OpeningTime { get; set; }

        [Required]
        public DateTime ClosingTime { get; set; }

    }
}
