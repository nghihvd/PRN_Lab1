using Microsoft.EntityFrameworkCore;
using PRN232.Lab1.CoffeeStore.Data.Entities;

namespace PRN232.Lab1.CoffeeStore.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInMenu> ProductInMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Seed Category
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "11111111-1111-1111-1111-111111111111", Name = "Beverages", Description = "Drinks and coffee" },
                new Category { CategoryId = "22222222-2222-2222-2222-222222222222", Name = "Snacks", Description = "Light snacks and pastries" },
                new Category { CategoryId = "33333333-3333-3333-3333-333333333333", Name = "Dairy", Description = "Milk and milk products" },
                new Category { CategoryId = "44444444-4444-4444-4444-444444444444", Name = "Bakery", Description = "Bread and baked goods" },
                new Category { CategoryId = "55555555-5555-5555-5555-555555555555", Name = "Cold Drinks", Description = "Cold beverages" }
            );

            // Seed Product
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", Name = "Espresso", Price = 2.5m, Description = "Strong coffee shot", CategoryId = "11111111-1111-1111-1111-111111111111" },
                new Product { ProductId = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", Name = "Croissant", Price = 3.0m, Description = "Buttery French pastry", CategoryId = "22222222-2222-2222-2222-222222222222" },
                new Product { ProductId = "cccccccc-cccc-cccc-cccc-cccccccccccc", Name = "Cheese", Price = 4.5m, Description = "Cheddar cheese block", CategoryId = "33333333-3333-3333-3333-333333333333" },
                new Product { ProductId = "dddddddd-dddd-dddd-dddd-dddddddddddd", Name = "Baguette", Price = 2.0m, Description = "French bread", CategoryId = "44444444-4444-4444-4444-444444444444" },
                new Product { ProductId = "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee", Name = "Iced Tea", Price = 2.0m, Description = "Cold black tea with ice", CategoryId = "55555555-5555-5555-5555-555555555555" }
            );

            // Seed Menu
            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa", Name = "Breakfast Menu", FromDate = DateTime.Parse("2025-09-01"), ToDate = DateTime.Parse("2025-09-30") },
                new Menu { MenuId = "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb", Name = "Lunch Menu", FromDate = DateTime.Parse("2025-09-01"), ToDate = DateTime.Parse("2025-09-30") },
                new Menu { MenuId = "33333333-cccc-cccc-cccc-cccccccccccc", Name = "Dinner Menu", FromDate = DateTime.Parse("2025-09-01"), ToDate = DateTime.Parse("2025-09-30") },
                new Menu { MenuId = "44444444-dddd-dddd-dddd-dddddddddddd", Name = "Snack Menu", FromDate = DateTime.Parse("2025-09-01"), ToDate = DateTime.Parse("2025-09-30") },
                new Menu { MenuId = "55555555-eeee-eeee-eeee-eeeeeeeeeeee", Name = "Drinks Menu", FromDate = DateTime.Parse("2025-09-01"), ToDate = DateTime.Parse("2025-09-30") }
            );

            // Seed ProductInMenu
            modelBuilder.Entity<ProductInMenu>().HasData(
                new ProductInMenu { ProductInMenuId = "1a1a1a1a-1111-1111-1111-111111111111", ProductId = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", MenuId = "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa", Quantity = 10 },
                new ProductInMenu { ProductInMenuId = "2b2b2b2b-2222-2222-2222-222222222222", ProductId = "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", MenuId = "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb", Quantity = 15 },
                new ProductInMenu { ProductInMenuId = "3c3c3c3c-3333-3333-3333-333333333333", ProductId = "cccccccc-cccc-cccc-cccc-cccccccccccc", MenuId = "33333333-cccc-cccc-cccc-cccccccccccc", Quantity = 20 },
                new ProductInMenu { ProductInMenuId = "4d4d4d4d-4444-4444-4444-444444444444", ProductId = "dddddddd-dddd-dddd-dddd-dddddddddddd", MenuId = "44444444-dddd-dddd-dddd-dddddddddddd", Quantity = 5 },
                new ProductInMenu { ProductInMenuId = "5e5e5e5e-5555-5555-5555-555555555555", ProductId = "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee", MenuId = "55555555-eeee-eeee-eeee-eeeeeeeeeeee", Quantity = 25 }
            );
        }
    }
}
