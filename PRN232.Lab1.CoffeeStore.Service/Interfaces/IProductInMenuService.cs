using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Service.Interfaces
{
    public interface IProductInMenuService
    {
        Task<ProductInMenu> CreateProductInMenuAsync(ProductInMenuRequestModel request);
        Task<List<ProductInMenu>> GetProductsInMenuAsync(string? menuId);
        Task DeleteProductFromMenuAsync(string productInMenuId);
        Task UpdateProductInMenuAsync(string productInMenuId, ProductInMenuRequestModel request);
    }
}
