using MediatR;

namespace DishDash.Application.Features.Restaurant.Queries.CreateRestuarant
{
    public class CreateRestuarntCommandHandler : IRequestHandler<CreateRestuarntCommand, RestaurantDto>
    {
        public Task<RestaurantDto> Handle(CreateRestuarntCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
