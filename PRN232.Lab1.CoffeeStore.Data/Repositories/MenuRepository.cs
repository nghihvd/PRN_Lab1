using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Data.Database;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;

namespace PRN232.Lab1.CoffeeStore.Data.Repositories
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        public MenuRepository(DatabaseContext context) : base(context)
        {
        }
        public async Task<List<Menu>> GetAllIncludeAsync()
        {
            return await _context.Menus
                .Include(m => m.ProductInMenus)
                .ToListAsync();
        }
        public async Task<Menu?> GetByIdIncludeAsync(string id)
        {
            return await _context.Menus
                .Include(m => m.ProductInMenus)
                .FirstOrDefaultAsync(m => m.MenuId == id);
        }

    }
}
