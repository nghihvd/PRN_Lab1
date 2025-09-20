using PRN232.Lab1.CoffeeStore.Data.Database;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;

namespace PRN232.Lab1.CoffeeStore.Data.Repositories
{
    public class ProductInMenuRepository : GenericRepository<ProductInMenu>, IProductInMenuRepository
    {
        public ProductInMenuRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
