namespace PRN232.Lab1.CoffeeStore.Data.Entities
{
    public class ProductInMenu
    {
        public string ProductInMenuId { get; set; } = Guid.NewGuid().ToString();
        public string? ProductId { get; set; }
        public Product? Product { get; set; }
        public string? MenuId { get; set; }
        public Menu? Menu { get; set; }
        public int Quantity { get; set; }
    }
}
