using PRN232.Lab1.CoffeeStore.Service.Models;

namespace PRN232.Lab1.CoffeeStore.Service.Interfaces
{
    public interface IMenuService
    {
        Task CreateMenuAsync(MenuRequestModel request);
        Task<IEnumerable<MenuResponseModel>> GetAllMenusAsync();
        Task<MenuResponseModel?> GetMenuByIdAsync(string? menuId);
        Task UpdateMenuAsync(string id, MenuUpdateRequestModel request);
        Task DeleteMenuAsync(string menuId);
    }
}
