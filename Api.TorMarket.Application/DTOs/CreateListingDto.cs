namespace Api.TorMarket.Application.DTOs;

public class CreateListingDto
{
    public CreateListingDto(int userId, int categoryId, string name, int sellLease, string? description, int price, string city, string country, DateTime? availableFrom)
    {
        UserId = userId;
        CategoryId = categoryId;
        Name = name;
        SellLease = sellLease;
        Description = description;
        Price = price;
        City = city;
        Country = country;
        AvailableFrom = availableFrom;
    }

    public int UserId { get; }
    public int CategoryId { get; set; }
    public string Name { get; }
    public int SellLease { get; }
    public string? Description { get; }
    public int Price { get; }
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime? AvailableFrom { get; set; }
}
