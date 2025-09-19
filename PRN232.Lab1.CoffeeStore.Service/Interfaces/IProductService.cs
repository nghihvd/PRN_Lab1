using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;

namespace PRN232.Lab1.CoffeeStore.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> CreatProductAsync(ProductRequestModel request);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(string productId);
        Task<Product?> UpdateProductAsync(string id, ProductRequestModel request);
        Task DeleteProductAsync(string productId);
    }
}
