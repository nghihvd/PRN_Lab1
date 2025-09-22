using PRN232.Lab1.CoffeeStore.Data.Entities;

namespace PRN232.Lab1.CoffeeStore.Data.Interfaces
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<List<Menu>> GetAllIncludeAsync();
        Task<Menu?> GetByIdIncludeAsync(string id);
    }
}
