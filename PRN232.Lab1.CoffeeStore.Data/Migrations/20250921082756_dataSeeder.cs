using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRN232.Lab1.CoffeeStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", "Drinks and coffee", "Beverages" },
                    { "22222222-2222-2222-2222-222222222222", "Light snacks and pastries", "Snacks" },
                    { "33333333-3333-3333-3333-333333333333", "Milk and milk products", "Dairy" },
                    { "44444444-4444-4444-4444-444444444444", "Bread and baked goods", "Bakery" },
                    { "55555555-5555-5555-5555-555555555555", "Cold beverages", "Cold Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "FromDate", "Name", "ToDate" },
                values: new object[,]
                {
                    { "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast Menu", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lunch Menu", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "33333333-cccc-cccc-cccc-cccccccccccc", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinner Menu", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "44444444-dddd-dddd-dddd-dddddddddddd", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Snack Menu", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "55555555-eeee-eeee-eeee-eeeeeeeeeeee", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drinks Menu", new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", "11111111-1111-1111-1111-111111111111", "Strong coffee shot", "Espresso", 2.5m },
                    { "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "22222222-2222-2222-2222-222222222222", "Buttery French pastry", "Croissant", 3.0m },
                    { "cccccccc-cccc-cccc-cccc-cccccccccccc", "33333333-3333-3333-3333-333333333333", "Cheddar cheese block", "Cheese", 4.5m },
                    { "dddddddd-dddd-dddd-dddd-dddddddddddd", "44444444-4444-4444-4444-444444444444", "French bread", "Baguette", 2.0m },
                    { "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee", "55555555-5555-5555-5555-555555555555", "Cold black tea with ice", "Iced Tea", 2.0m }
                });

            migrationBuilder.InsertData(
                table: "ProductInMenus",
                columns: new[] { "ProductInMenuId", "MenuId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "1a1a1a1a-1111-1111-1111-111111111111", "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa", "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa", 10 },
                    { "2b2b2b2b-2222-2222-2222-222222222222", "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb", "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb", 15 },
                    { "3c3c3c3c-3333-3333-3333-333333333333", "33333333-cccc-cccc-cccc-cccccccccccc", "cccccccc-cccc-cccc-cccc-cccccccccccc", 20 },
                    { "4d4d4d4d-4444-4444-4444-444444444444", "44444444-dddd-dddd-dddd-dddddddddddd", "dddddddd-dddd-dddd-dddd-dddddddddddd", 5 },
                    { "5e5e5e5e-5555-5555-5555-555555555555", "55555555-eeee-eeee-eeee-eeeeeeeeeeee", "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee", 25 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductInMenus",
                keyColumn: "ProductInMenuId",
                keyValue: "1a1a1a1a-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "ProductInMenus",
                keyColumn: "ProductInMenuId",
                keyValue: "2b2b2b2b-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "ProductInMenus",
                keyColumn: "ProductInMenuId",
                keyValue: "3c3c3c3c-3333-3333-3333-333333333333");

            migrationBuilder.DeleteData(
                table: "ProductInMenus",
                keyColumn: "ProductInMenuId",
                keyValue: "4d4d4d4d-4444-4444-4444-444444444444");

            migrationBuilder.DeleteData(
                table: "ProductInMenus",
                keyColumn: "ProductInMenuId",
                keyValue: "5e5e5e5e-5555-5555-5555-555555555555");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: "11111111-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: "22222222-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: "33333333-cccc-cccc-cccc-cccccccccccc");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: "44444444-dddd-dddd-dddd-dddddddddddd");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: "55555555-eeee-eeee-eeee-eeeeeeeeeeee");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "cccccccc-cccc-cccc-cccc-cccccccccccc");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "dddddddd-dddd-dddd-dddd-dddddddddddd");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "22222222-2222-2222-2222-222222222222");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "33333333-3333-3333-3333-333333333333");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "44444444-4444-4444-4444-444444444444");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "55555555-5555-5555-5555-555555555555");
        }
    }
}
