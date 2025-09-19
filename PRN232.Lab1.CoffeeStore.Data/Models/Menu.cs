namespace PRN232.Lab1.CoffeeStore.Data.Entities
{
    public class Menu
    {
        public string MenuId { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public ICollection<ProductInMenu>? ProductInMenus { get; set; }
    }
}
