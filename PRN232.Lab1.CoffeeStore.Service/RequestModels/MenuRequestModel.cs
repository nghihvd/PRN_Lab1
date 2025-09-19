using PRN232.Lab1.CoffeeStore.Data.Entities;

namespace PRN232.Lab1.CoffeeStore.Service.RequestModels
{
    public class MenuRequestModel
    {
        public string? Name { get; set; }
        public string? FromDate { get; set; }
        public string? ToDate { get; set; }
    }
}
