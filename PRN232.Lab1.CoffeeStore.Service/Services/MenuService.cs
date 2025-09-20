using PRN232.Lab1.CoffeeStore.Data.Entities;
using PRN232.Lab1.CoffeeStore.Data.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Interfaces;
using PRN232.Lab1.CoffeeStore.Service.Models;
using PRN232.Lab1.CoffeeStore.Service.Validations;

namespace PRN232.Lab1.CoffeeStore.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepo;
        private readonly IProductRepository productRepository;
        private readonly IProductInMenuRepository _productMenuRepo;

        public MenuService(IMenuRepository menuRepo, IProductRepository productRepository, IProductInMenuRepository productMenuRepo)
        {
            _menuRepo = menuRepo;
            this.productRepository = productRepository;
            _productMenuRepo = productMenuRepo;
        }

        public async Task CreateMenuAsync(MenuRequestModel request)
        {
            // Validate name
            MenuValidation.NameValid(request.Name);
            // Validate date
            DateTime fromDate = MenuValidation.DateCheck(request.FromDate);
            DateTime toDate = MenuValidation.DateCheck(request.ToDate);
            if (fromDate > toDate)
            {
                throw new Exception("From date must be before to date");
            }

            Menu menu = new()
            {
                FromDate = fromDate,
                ToDate = toDate,
                Name = request.Name
            };

            await _menuRepo.AddAsync(menu);

            if (request.ProductList != null && request.ProductList.Count > 0)
            {
                foreach (var item in request.ProductList)
                {
                    var product = await productRepository.GetByIdAsync(item.ProductId)
                                  ?? throw new Exception($"Product with ID {item.ProductId} not found");
                    if (item.Quantity <= 0)
                    {
                        throw new Exception("Quantity must be greater than 0");
                    }
                    ProductInMenu productInMenu = new()
                    {
                        MenuId = menu.MenuId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    if (menu.ProductInMenus == null)
                    {
                        menu.ProductInMenus = new List<ProductInMenu>();
                    }
                    menu.ProductInMenus.Add(productInMenu);
                }
            }
            await _menuRepo.SaveChangeAsync();
        }


        public async Task<IEnumerable<MenuResponseModel>> GetAllMenusAsync()
        {
            var menus = await _menuRepo.GetAllAsync();

            var result = menus.Select(menu => new MenuResponseModel
            {
                Name = menu.Name,
                FromDate = menu.FromDate.ToString("yyyy-MM-dd"),
                ToDate = menu.ToDate.ToString("yyyy-MM-dd"),
                ProductList = menu.ProductInMenus?.Select(pim => new MenuProductResponseModel
                {
                    ProductId = pim.ProductId!,
                    Quantity = pim.Quantity
                }).ToList()
            });

            return result;
        }


        public async Task<MenuResponseModel?> GetMenuByIdAsync(string? menuId)
        {
            if (string.IsNullOrWhiteSpace(menuId))
            {
                throw new Exception("Id not null");
            }

            var menu = await _menuRepo.GetByIdAsync(menuId)
                       ?? throw new Exception("Id not found");

            return new MenuResponseModel
            {
                Name = menu.Name,
                FromDate = menu.FromDate.ToString("yyyy-MM-dd"),
                ToDate = menu.ToDate.ToString("yyyy-MM-dd"),
                ProductList = menu.ProductInMenus?.Select(pim => new MenuProductResponseModel
                {
                    ProductId = pim.ProductId!,
                    Quantity = pim.Quantity
                }).ToList()
            };
        }


        public async Task UpdateMenuAsync(string id, MenuRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Id not null");
            }
            var menu = await _menuRepo.GetByIdAsync(id) ?? throw new Exception("Id not found");

            // Validate updated properties
            MenuValidation.NameValid(request.Name);

            DateTime fromDate = MenuValidation.DateCheck(request.FromDate);
            DateTime toDate = MenuValidation.DateCheck(request.ToDate);

            menu.Name = request.Name;
            menu.FromDate = fromDate;
            menu.ToDate = toDate;

            _menuRepo.Update(menu);
            await _menuRepo.SaveChangeAsync();
        }

        public async Task DeleteMenuAsync(string menuId)
        {
            var menu = await _menuRepo.GetByIdAsync(menuId) ?? throw new Exception("Id not found");

            await _menuRepo.DeleteAsync(menu);
            await _menuRepo.SaveChangeAsync();
        }
    }
}
