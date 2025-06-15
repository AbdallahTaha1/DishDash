using MediatR;

namespace DishDash.Application.Features.Restaurants.Commands.CreateRestuarant
{
    public class CreateRestuarntCommandHandler : IRequestHandler<CreateRestuarntCommand, RestaurantDto>
    {
        public Task<RestaurantDto> Handle(CreateRestuarntCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var newRestautran = new Restaurant()
            //{
            //    Name = request.Name,
            //    Description = request.Description,
            //    Location = request.Location,
            //    Status = request.Status,
            //    OpeningTime = request.OpeningTime,
            //    ClosingTime = request.ClosingTime,

            //};
        }
    }
}
