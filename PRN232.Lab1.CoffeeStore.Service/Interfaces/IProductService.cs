using PRN232.Lab1.CoffeeStore.Service.Models;

namespace PRN232.Lab1.CoffeeStore.Service.Interfaces
{
    public interface IProductService
    {
        Task CreatProductAsync(ProductRequestModel request);
        Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
        Task<ProductResponseModel?> GetProductByIdAsync(string productId);
        Task UpdateProductAsync(string id, ProductRequestModel request);
        Task DeleteProductAsync(string productId);
    }
}
