using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Data.Database;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Service.Services
{
    public class ProductInMenuService: IProductInMenuService
    {
        private readonly IProductInMenuRepository _productMenuRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMenuRepository _menuRepo;

        public ProductInMenuService(IProductInMenuRepository productMenuRepo, IProductRepository productRepo, IMenuRepository menuRepo)
        {
            _productMenuRepo = productMenuRepo;
            _productRepo = productRepo;
            _menuRepo = menuRepo;
        }

        public async Task<ProductInMenu> CreateProductInMenuAsync(ProductInMenuRequestModel request)
        {
            if(string.IsNullOrWhiteSpace(request.ProductId) || string.IsNullOrWhiteSpace(request.MenuId))
            {
                               throw new Exception("ProductId and MenuId cannot be null or empty");
            }
            if(request.Quantity <= 0)
            {
                throw new Exception("Quantity must be greater than zero");
            }
            var product = await _productRepo.GetByIdAsync(request.ProductId) ?? throw new Exception("Product not found");
            var menu = await _menuRepo.GetByIdAsync(request.MenuId) ?? throw new Exception("Menu not found");

            var pim = new ProductInMenu
            {
                ProductId = request.ProductId,
                MenuId = request.MenuId,
                Quantity = request.Quantity
            };

            await _productMenuRepo.AddAsync(pim);
            await _productMenuRepo.SaveChangeAsync();

            return pim;
        }

        public async Task<List<ProductInMenu>> GetProductsInMenuAsync(string? menuId)
        {
            var list = await _productMenuRepo.FindAsync(pim => pim.MenuId == menuId);
            return list.ToList();

        }

        public async Task DeleteProductFromMenuAsync(string productInMenuId)
        {
            var pim = await _productMenuRepo.GetByIdAsync(productInMenuId);
            if (pim == null) throw new Exception("Not found");
            await _productMenuRepo.DeleteAsync(pim);
            await _productMenuRepo.SaveChangeAsync();
        }

        public async Task UpdateProductInMenuAsync(string productInMenuId, ProductInMenuRequestModel request)
        {
            var pim = await _productMenuRepo.GetByIdAsync(productInMenuId);
            if (pim == null) throw new Exception("Not found");
            pim.Quantity = request.Quantity;
            pim.ProductId = request.ProductId;
            pim.MenuId = request.MenuId;
            await _productMenuRepo.UpdateAsync(pim);
            await _productMenuRepo.SaveChangeAsync();
        }
    }
}
