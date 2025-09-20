namespace PRN232.Lab1.CoffeeStore.API.Models
{
    public class MenuModel
    {
        public string? Name { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }

        public List<MenuProductRequestModel>? ProductList { get; set; }
    }
    public class MenuProductRequestModel
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
