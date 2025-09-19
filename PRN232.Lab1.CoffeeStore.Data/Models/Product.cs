namespace PRN232.Lab1.CoffeeStore.Data.Entities
{
    public class Product
    {
        public string ProductId { get; set; } = Guid.NewGuid().ToString();

        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }

        public ICollection<ProductInMenu>? ProductInMenus { get; set; }
    }
}
