namespace DishDash.Domain.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RestauranId { get; set; }
        public Restaurant Restaurant { get; set; } = default!;
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}
