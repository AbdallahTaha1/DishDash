using MediatR;

namespace DishDash.Application.Features.Restaurant.Queries.CreateRestuarant
{
    public class CreateRestuarntCommand : IRequest<RestaurantDto>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
