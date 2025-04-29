namespace DishDash.Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ingredients { get; set; } = string.Empty;
        public double price { get; set; }
        public int Quantity { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; } = default!;
    }
}
