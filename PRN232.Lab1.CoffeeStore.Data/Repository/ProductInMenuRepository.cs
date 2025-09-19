using PRN232.Lab1.CoffeeStore.Data.Database;
using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN232.Lab1.CoffeeStore.Data.Repository
{
    public class ProductInMenuRepository: GenericRepository<ProductInMenu>, IProductInMenuRepository
    {
        public ProductInMenuRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
