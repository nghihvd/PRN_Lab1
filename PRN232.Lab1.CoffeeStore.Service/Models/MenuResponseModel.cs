namespace PRN232.Lab1.CoffeeStore.Service.Models
{
    public class MenuResponseModel
    {
        public string? MenuId { get; set; }
        public string? Name { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
        public List<MenuProductResponseModel>? ProductList { get; set; }
    }
    public class MenuProductResponseModel
    {
        public string ProductId { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
