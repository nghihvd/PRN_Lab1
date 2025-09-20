using PRN232.Lab1.CoffeeStore.Data.Database;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;

namespace PRN232.Lab1.CoffeeStore.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context) : base(context)
        {
        }
    }

}
