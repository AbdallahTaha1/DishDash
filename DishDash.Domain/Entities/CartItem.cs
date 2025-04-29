namespace DishDash.Domain.Entities
{
    internal class CartItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; } = default!;

        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; } = default!;
    }
}
