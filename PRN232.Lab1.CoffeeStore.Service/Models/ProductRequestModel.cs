namespace PRN232.Lab1.CoffeeStore.Service.Models
{
    public class ProductRequestModel
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
    }
}
