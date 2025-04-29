namespace DishDash.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime OpeningTime { get; set; }
        public DateTime ClosingTime { get; set; }
        public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
