using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;
using PRN232.Lab1.CoffeeStore.Service.Validations;

namespace PRN232.Lab1.CoffeeStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;

        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Product> CreatProductAsync(ProductRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(request.CategoryId))
            {
                throw new Exception("CategoryId is not null");
            }
            // check vallid 
            ProductValidation.ValidatPrice(request.Price);
            ProductValidation.ValidateName(request.Name);
            ProductValidation.ValidateDescription(request.Description);

            Product product = new()
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            await repo.AddAsync(product);
            await repo.SaveChangeAsync();

            return product;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await repo.GetAllAsync();
            return products.ToList();
        }
        public async Task<Product?> GetProductByIdAsync(string productId)
        {
            var product = await repo.GetByIdAsync(productId) ?? throw new Exception("Id not found"); ;
            return product;
        }
        public async Task<Product?> UpdateProductAsync(string id, ProductRequestModel request)
        {
            var product = await repo.GetByIdAsync(id) ?? throw new Exception("Id not found"); ;

            // Validation nếu cần
            if (request.Price != null)
                ProductValidation.ValidatPrice(request.Price);
            if (!string.IsNullOrWhiteSpace(request.Name))
                ProductValidation.ValidateName(request.Name);
            if (!string.IsNullOrWhiteSpace(request.Description))
                ProductValidation.ValidateDescription(request.Description);

            // Cập nhật
            product.Name = request.Name ?? product.Name;
            product.Price = request.Price ?? product.Price;
            product.Description = request.Description ?? product.Description;
            product.CategoryId = request.CategoryId ?? product.CategoryId;

            await repo.UpdateAsync(product);
            await repo.SaveChangeAsync();

            return product;
        }
        public async Task DeleteProductAsync(string productId)
        {
            var product = await repo.GetByIdAsync(productId) ?? throw new Exception("Id not found");
            await repo.DeleteAsync(product);
            await repo.SaveChangeAsync();
        }

    }
}
