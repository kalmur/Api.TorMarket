using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.TorMarket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MockDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ListingCategories",
                columns: new[] { "ListingCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Games" },
                    { 3, "Toys" },
                    { 4, "Clothing" },
                    { 5, "Vehicles" },
                    { 6, "Pets" },
                    { 7, "Other" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "OrderStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Processing" },
                    { 3, "Shipped" },
                    { 4, "Delivered" },
                    { 5, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedOn", "ProviderId", "UpdatedOn" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "auth0|67b6687fb71ed3cae5848607", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                table: "Listings",
                columns: new[] { "ListingId", "AvailableFrom", "CategoryId", "Description", "Name", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "High-performance gaming laptop with a powerful GPU and fast processor.", "MSI GE76 Raider", 2500m, 1 },
                    { 2, new DateTimeOffset(new DateTime(2025, 4, 9, 9, 45, 52, 995, DateTimeKind.Unspecified).AddTicks(5975), new TimeSpan(0, 0, 0, 0, 0)), 1, "Precision gaming mouse with customizable buttons and RGB lighting.", "Logitech GPROX", 130m, 1 },
                    { 3, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Wireless noise-canceling headphones with superior sound quality.", "Sony WH-1000XM4", 350m, 1 },
                    { 4, new DateTimeOffset(new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "High-end tablet with M1 chip and large Retina display.", "Apple iPad Pro 12.9", 1100m, 1 },
                    { 5, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Compact laptop with a sleek design and high-resolution display.", "Dell XPS 13", 1400m, 1 },
                    { 6, new DateTimeOffset(new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Latest smartphone with advanced camera features and high performance.", "Samsung Galaxy S23 Ultra", 1200m, 1 },
                    { 7, new DateTimeOffset(new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "55-inch OLED TV with stunning color accuracy and contrast.", "LG OLED TV 55\"", 1800m, 1 },
                    { 8, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Wireless headphones with world-class noise cancellation and comfortable fit.", "Bose QuietComfort 35 II", 300m, 1 },
                    { 9, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Next-gen gaming console with immersive graphics.", "PlayStation 5", 499m, 1 },
                    { 10, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Powerful gaming console with a sleek design.", "Xbox Series X", 499m, 1 },
                    { 11, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Portable gaming console with vibrant display.", "Nintendo Switch OLED", 349m, 1 },
                    { 12, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Realistic racing wheel for driving games.", "Logitech G29 Racing Wheel", 299m, 1 },
                    { 13, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Gaming headset with surround sound.", "Razer Kraken Headset", 79m, 1 },
                    { 14, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Mechanical keyboard with RGB lighting.", "Corsair K95 Keyboard", 199m, 1 },
                    { 15, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Gaming mouse with dual sensors.", "SteelSeries Rival 600", 89m, 1 },
                    { 16, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 2, "Comfortable gaming headset with great sound.", "HyperX Cloud II", 99m, 1 },
                    { 17, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Iconic LEGO set for Star Wars fans.", "LEGO Star Wars Millennium Falcon", 159m, 1 },
                    { 18, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Luxury dollhouse with interactive features.", "Barbie Dreamhouse", 199m, 1 },
                    { 19, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Massive garage playset for Hot Wheels cars.", "Hot Wheels Ultimate Garage", 99m, 1 },
                    { 20, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "High-capacity foam dart blaster.", "NERF Ultra One Blaster", 49m, 1 },
                    { 21, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Interactive learning toy for toddlers.", "Fisher-Price Laugh & Learn", 39m, 1 },
                    { 22, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Creative playset for making pretend food.", "Play-Doh Kitchen Creations", 29m, 1 },
                    { 23, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Action figure that transforms into a truck.", "Transformers Optimus Prime", 49m, 1 },
                    { 24, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 3, "Classic board game for family fun.", "Monopoly Classic", 19m, 1 },
                    { 25, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Stylish leather jacket for men.", "Men's Leather Jacket", 120m, 1 },
                    { 26, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Warm and comfortable winter coat.", "Women's Winter Coat", 150m, 1 },
                    { 27, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Durable rain boots for kids.", "Kids' Rain Boots", 30m, 1 },
                    { 28, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Breathable t-shirt for sports activities.", "Sports T-Shirt", 25m, 1 },
                    { 29, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Elegant formal dress for special occasions.", "Formal Dress", 200m, 1 },
                    { 30, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Comfortable sneakers for everyday wear.", "Casual Sneakers", 60m, 1 },
                    { 31, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Soft and warm wool scarf.", "Wool Scarf", 20m, 1 },
                    { 32, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 4, "Classic baseball cap for sunny days.", "Baseball Cap", 15m, 1 },
                    { 33, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Durable mountain bike for off-road adventures.", "Mountain Bike", 500m, 1 },
                    { 34, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Eco-friendly electric scooter for city commuting.", "Electric Scooter", 300m, 1 },
                    { 35, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Convenient roof rack for carrying extra luggage.", "Car Roof Rack", 150m, 1 },
                    { 36, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Safety helmet for motorcycle riders.", "Motorcycle Helmet", 100m, 1 },
                    { 37, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Secure car seat for children.", "Child Car Seat", 80m, 1 },
                    { 38, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Durable tires for all weather conditions.", "All-Weather Tires", 400m, 1 },
                    { 39, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Secure lock for bicycles.", "Bike Lock", 20m, 1 },
                    { 40, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 5, "Protective cover for cars.", "Car Cover", 50m, 1 },
                    { 41, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Comfortable bed for dogs.", "Dog Bed", 40m, 1 },
                    { 42, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Durable scratching post for cats.", "Cat Scratching Post", 30m, 1 },
                    { 43, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Spacious cage for pet birds.", "Bird Cage", 100m, 1 },
                    { 44, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Large tank for pet fish.", "Fish Tank", 200m, 1 },
                    { 45, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Outdoor hutch for rabbits.", "Rabbit Hutch", 150m, 1 },
                    { 46, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Durable leash for walking dogs.", "Dog Leash", 20m, 1 },
                    { 47, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Easy-to-clean litter box for cats.", "Cat Litter Box", 25m, 1 },
                    { 48, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 6, "Exercise wheel for hamsters.", "Hamster Wheel", 15m, 1 },
                    { 49, new DateTimeOffset(new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Spacious tent for outdoor camping.", "Camping Tent", 100m, 1 },
                    { 50, new DateTimeOffset(new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Non-slip mat for yoga and exercise.", "Yoga Mat", 20m, 1 },
                    { 51, new DateTimeOffset(new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Portable toolbox with essential tools.", "Toolbox", 50m, 1 },
                    { 52, new DateTimeOffset(new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Fast-boiling electric kettle.", "Electric Kettle", 30m, 1 },
                    { 53, new DateTimeOffset(new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Powerful vacuum cleaner for home use.", "Vacuum Cleaner", 150m, 1 },
                    { 54, new DateTimeOffset(new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Compact heater for small spaces.", "Portable Heater", 80m, 1 },
                    { 55, new DateTimeOffset(new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Adjustable desk lamp with LED light.", "Desk Lamp", 25m, 1 },
                    { 56, new DateTimeOffset(new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 7, "Durable backpack for travel and school.", "Backpack", 40m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Listings",
                keyColumn: "ListingId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderStatuses",
                keyColumn: "OrderStatusId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ListingCategories",
                keyColumn: "ListingCategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
