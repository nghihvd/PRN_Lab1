using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;

namespace PRN232.Lab1.CoffeeStore.Service.Interfaces
{
    public interface IMenuService
    {
        Task<Menu> CreateMenuAsync(MenuRequestModel request);
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task<Menu?> GetMenuByIdAsync(string? menuId);
        Task<Menu?> UpdateMenuAsync(string id, MenuRequestModel request);
        Task<bool> DeleteMenuAsync(string menuId);
    }
}
