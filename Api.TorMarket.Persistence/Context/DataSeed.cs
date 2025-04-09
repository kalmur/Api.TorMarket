using System.Collections.Immutable;
using Api.TorMarket.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.TorMarket.Persistence.Context;

internal static class DataSeed
{
    public static void SeedData(ModelBuilder builder)
    {
        SeedOrderStatuses(builder);
        SeedListingCategories(builder);
        SeedAdminUser(builder);
        SeedMockListings(builder);
    }

    private static void SeedOrderStatuses(ModelBuilder builder)
    {
        static OrderStatusEntity CreateOrderStatus(
            int orderStatusId,
            string statusName
        ) => new()
        {
            OrderStatusId = orderStatusId,
            Status = statusName
        };

        IImmutableList<OrderStatusEntity> orderStatuses = ImmutableList.Create(
            CreateOrderStatus(1, "Pending"),
            CreateOrderStatus(2, "Processing"),
            CreateOrderStatus(3, "Shipped"),
            CreateOrderStatus(4, "Delivered"),
            CreateOrderStatus(5, "Cancelled")
        );

        builder.Entity<OrderStatusEntity>().HasData(orderStatuses);
    }

    private static void SeedListingCategories(ModelBuilder builder)
    {
        static ListingCategoryEntity CreateListingCategory(
            int listingCategoryId,
            string categoryName
        ) => new()
        {
            ListingCategoryId = listingCategoryId,
            Name = categoryName
        };

        IImmutableList<ListingCategoryEntity> listingCategories = ImmutableList.Create(
            CreateListingCategory(1, "Electronics"),
            CreateListingCategory(2, "Games"),
            CreateListingCategory(3, "Toys"),
            CreateListingCategory(4, "Clothing"),
            CreateListingCategory(5, "Vehicles"),
            CreateListingCategory(6, "Pets"),
            CreateListingCategory(7, "Other")
        );

        builder.Entity<ListingCategoryEntity>().HasData(listingCategories);
    }
    private static void SeedAdminUser(ModelBuilder builder)
    {
        var adminUser = new UserEntity
        {
            UserId = 1,
            ProviderId = "auth0|67b6687fb71ed3cae5848607"
        };

        builder.Entity<UserEntity>().HasData(adminUser);
    }

    private static void SeedMockListings(ModelBuilder builder)
    {
        static ListingEntity CreateListing(
            int listingId,
            int userId,
            int categoryId,
            string listingName,
            decimal price,
            string description,
            DateTimeOffset availableFrom
        ) => new()
        {
            ListingId = listingId,
            UserId = userId,
            CategoryId = categoryId,
            Name = listingName,
            Price = price,
            Description = description,
            AvailableFrom = availableFrom
        };

        IImmutableList<ListingEntity> listings = ImmutableList.Create(
            // Electronics
            CreateListing(1, 1, 1, "MSI GE76 Raider", 2500m, "High-performance gaming laptop with a powerful GPU and fast processor.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(2, 1, 1, "Logitech GPROX", 130m, "Precision gaming mouse with customizable buttons and RGB lighting.", DateTimeOffset.UtcNow),
            CreateListing(3, 1, 1, "Sony WH-1000XM4", 350m, "Wireless noise-canceling headphones with superior sound quality.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(4, 1, 1, "Apple iPad Pro 12.9", 1100m, "High-end tablet with M1 chip and large Retina display.", new DateTimeOffset(2024, 12, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(5, 1, 1, "Dell XPS 13", 1400m, "Compact laptop with a sleek design and high-resolution display.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(6, 1, 1, "Samsung Galaxy S23 Ultra", 1200m, "Latest smartphone with advanced camera features and high performance.", new DateTimeOffset(2024, 11, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(7, 1, 1, "LG OLED TV 55\"", 1800m, "55-inch OLED TV with stunning color accuracy and contrast.", new DateTimeOffset(2024, 12, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(8, 1, 1, "Bose QuietComfort 35 II", 300m, "Wireless headphones with world-class noise cancellation and comfortable fit.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),

            // Games
            CreateListing(9, 1, 2, "PlayStation 5", 499m, "Next-gen gaming console with immersive graphics.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(10, 1, 2, "Xbox Series X", 499m, "Powerful gaming console with a sleek design.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(11, 1, 2, "Nintendo Switch OLED", 349m, "Portable gaming console with vibrant display.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(12, 1, 2, "Logitech G29 Racing Wheel", 299m, "Realistic racing wheel for driving games.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(13, 1, 2, "Razer Kraken Headset", 79m, "Gaming headset with surround sound.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(14, 1, 2, "Corsair K95 Keyboard", 199m, "Mechanical keyboard with RGB lighting.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(15, 1, 2, "SteelSeries Rival 600", 89m, "Gaming mouse with dual sensors.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(16, 1, 2, "HyperX Cloud II", 99m, "Comfortable gaming headset with great sound.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)),

            // Toys
            CreateListing(17, 1, 3, "LEGO Star Wars Millennium Falcon", 159m, "Iconic LEGO set for Star Wars fans.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(18, 1, 3, "Barbie Dreamhouse", 199m, "Luxury dollhouse with interactive features.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(19, 1, 3, "Hot Wheels Ultimate Garage", 99m, "Massive garage playset for Hot Wheels cars.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(20, 1, 3, "NERF Ultra One Blaster", 49m, "High-capacity foam dart blaster.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(21, 1, 3, "Fisher-Price Laugh & Learn", 39m, "Interactive learning toy for toddlers.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(22, 1, 3, "Play-Doh Kitchen Creations", 29m, "Creative playset for making pretend food.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(23, 1, 3, "Transformers Optimus Prime", 49m, "Action figure that transforms into a truck.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(24, 1, 3, "Monopoly Classic", 19m, "Classic board game for family fun.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)),

            // Clothing
            CreateListing(25, 1, 4, "Men's Leather Jacket", 120m, "Stylish leather jacket for men.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(26, 1, 4, "Women's Winter Coat", 150m, "Warm and comfortable winter coat.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(27, 1, 4, "Kids' Rain Boots", 30m, "Durable rain boots for kids.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(28, 1, 4, "Sports T-Shirt", 25m, "Breathable t-shirt for sports activities.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(29, 1, 4, "Formal Dress", 200m, "Elegant formal dress for special occasions.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(30, 1, 4, "Casual Sneakers", 60m, "Comfortable sneakers for everyday wear.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(31, 1, 4, "Wool Scarf", 20m, "Soft and warm wool scarf.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(32, 1, 4, "Baseball Cap", 15m, "Classic baseball cap for sunny days.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),

            // Vehicles
            CreateListing(33, 1, 5, "Mountain Bike", 500m, "Durable mountain bike for off-road adventures.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(34, 1, 5, "Electric Scooter", 300m, "Eco-friendly electric scooter for city commuting.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(35, 1, 5, "Car Roof Rack", 150m, "Convenient roof rack for carrying extra luggage.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(36, 1, 5, "Motorcycle Helmet", 100m, "Safety helmet for motorcycle riders.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(37, 1, 5, "Child Car Seat", 80m, "Secure car seat for children.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(38, 1, 5, "All-Weather Tires", 400m, "Durable tires for all weather conditions.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(39, 1, 5, "Bike Lock", 20m, "Secure lock for bicycles.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(40, 1, 5, "Car Cover", 50m, "Protective cover for cars.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)),

            // Pets
            CreateListing(41, 1, 6, "Dog Bed", 40m, "Comfortable bed for dogs.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(42, 1, 6, "Cat Scratching Post", 30m, "Durable scratching post for cats.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(43, 1, 6, "Bird Cage", 100m, "Spacious cage for pet birds.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(44, 1, 6, "Fish Tank", 200m, "Large tank for pet fish.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(45, 1, 6, "Rabbit Hutch", 150m, "Outdoor hutch for rabbits.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(46, 1, 6, "Dog Leash", 20m, "Durable leash for walking dogs.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(47, 1, 6, "Cat Litter Box", 25m, "Easy-to-clean litter box for cats.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(48, 1, 6, "Hamster Wheel", 15m, "Exercise wheel for hamsters.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero)),

            // Other
            CreateListing(49, 1, 7, "Camping Tent", 100m, "Spacious tent for outdoor camping.", new DateTimeOffset(2024, 10, 1, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(50, 1, 7, "Yoga Mat", 20m, "Non-slip mat for yoga and exercise.", new DateTimeOffset(2024, 10, 5, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(51, 1, 7, "Toolbox", 50m, "Portable toolbox with essential tools.", new DateTimeOffset(2024, 10, 10, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(52, 1, 7, "Electric Kettle", 30m, "Fast-boiling electric kettle.", new DateTimeOffset(2024, 10, 15, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(53, 1, 7, "Vacuum Cleaner", 150m, "Powerful vacuum cleaner for home use.", new DateTimeOffset(2024, 10, 20, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(54, 1, 7, "Portable Heater", 80m, "Compact heater for small spaces.", new DateTimeOffset(2024, 10, 25, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(55, 1, 7, "Desk Lamp", 25m, "Adjustable desk lamp with LED light.", new DateTimeOffset(2024, 10, 30, 0, 0, 0, TimeSpan.Zero)),
            CreateListing(56, 1, 7, "Backpack", 40m, "Durable backpack for travel and school.", new DateTimeOffset(2024, 11, 1, 0, 0, 0, TimeSpan.Zero))
        );

        builder.Entity<ListingEntity>().HasData(listings);
    }
}
