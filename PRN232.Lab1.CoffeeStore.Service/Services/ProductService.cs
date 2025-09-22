using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Models;
using PRN232.Lab1.CoffeeStore.Service.Validations;

namespace PRN232.Lab1.CoffeeStore.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductInMenuRepository _productInMenuRepo;

        public ProductService(IProductRepository productRepo, ICategoryRepository categoryRepo, IProductInMenuRepository productInMenuRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _productInMenuRepo = productInMenuRepo;
        }

        public async Task CreatProductAsync(ProductRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(request.CategoryId))
            {
                throw new Exception("CategoryId is not null");
            }
            var category = await _categoryRepo.GetByIdAsync(request.CategoryId) ?? throw new Exception("CategoryId not found");
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

            await _productRepo.AddAsync(product);
            await _productRepo.SaveChangeAsync();
        }
        public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();

            return products.Select(p => new ProductResponseModel
            {
                CategoryId = p.CategoryId,
                ProductId = p.ProductId,
                Price = p.Price,
                Description = p.Description,
                Name = p.Name
            });
        }
        public async Task<ProductResponseModel?> GetProductByIdAsync(string productId)
        {
            var product = await _productRepo.GetByIdAsync(productId) ?? throw new Exception("Id not found"); ;
            return new ProductResponseModel
            {
                ProductId = product.ProductId,
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Description = product.Description
            };
        }
        public async Task UpdateProductAsync(string id, ProductRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id is not null");
            }

            var product = await _productRepo.GetByIdAsync(id) ?? throw new Exception("Id not found");
            if (string.IsNullOrWhiteSpace(request.CategoryId))
            {
                throw new Exception("CategoryId is not null");
            }
            var category = await _categoryRepo.GetByIdAsync(request.CategoryId) ?? throw new Exception("CategoryId not found");
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

            await _productRepo.UpdateAsync(product);
            await _productRepo.SaveChangeAsync();
        }
        public async Task DeleteProductAsync(string productId)
        {
            var product = await _productRepo.GetByIdAsync(productId) ?? throw new Exception("Id not found");

            // Xóa các bản ghi ProductInMenu liên quan
            var productInMenus = await _productInMenuRepo.FindAsync(x => x.ProductId!.Equals(productId));

            foreach (var pim in productInMenus)
            {
                await _productInMenuRepo.DeleteAsync(pim);
            }

            // Xóa sản phẩm
            await _productRepo.DeleteAsync(product);

            await _productInMenuRepo.SaveChangeAsync();
            await _productRepo.SaveChangeAsync();
        }


    }
}
