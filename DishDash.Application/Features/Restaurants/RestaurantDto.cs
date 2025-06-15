namespace DishDash.Application.Features.Restaurants
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
    }
}
