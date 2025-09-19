using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.RequestModels;
using PRN232.Lab1.CoffeeStore.Service.Validations;

namespace PRN232.Lab1.CoffeeStore.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository repo;

        public MenuService(IMenuRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Menu> CreateMenuAsync(MenuRequestModel request)
        {
            // Validate name
            MenuValidation.NameValid(request.Name);
            // Validate date
            DateTime fromDate = MenuValidation.DateCheck(request.FromDate);
            DateTime toDate = MenuValidation.DateCheck(request.ToDate);

            if(fromDate > toDate)
            {
                throw new Exception("From date must be before to date");
            }

            Menu menu = new()
            {
                FromDate = fromDate,
                ToDate = toDate,
                Name = request.Name
            };
            await repo.AddAsync(menu);
            await repo.SaveChangeAsync();
            return menu;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            var menus = await repo.GetAllAsync();
            return menus;
        }

        public async Task<Menu?> GetMenuByIdAsync(string? menuId)
        {
            if (string.IsNullOrWhiteSpace(menuId))
            {
                throw new Exception("Id not null");
            }
            var menu = await repo.GetByIdAsync(menuId) ?? throw new Exception("Id not found");

            return menu;
        }

        public async Task<Menu?> UpdateMenuAsync(string id,MenuRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id not null");
            }
            var menu = await repo.GetByIdAsync(id) ?? throw new Exception("Id not found");

            // Validate updated properties
            MenuValidation.NameValid(request.Name);

            DateTime fromDate = MenuValidation.DateCheck(request.FromDate);
            DateTime toDate = MenuValidation.DateCheck(request.ToDate);

            menu.Name = request.Name;
            menu.FromDate = fromDate;
            menu.ToDate = toDate;

            repo.Update(menu);
            await repo.SaveChangeAsync();

            return menu;
        }

        public async Task<bool> DeleteMenuAsync(string menuId)
        {
            var menu = await repo.GetByIdAsync(menuId) ?? throw new Exception("Id not found");
            if (menu == null)
            {
                return false;
            }
            await repo.DeleteAsync(menu);
            await repo.SaveChangeAsync();
            return true;
        }
    }
}
