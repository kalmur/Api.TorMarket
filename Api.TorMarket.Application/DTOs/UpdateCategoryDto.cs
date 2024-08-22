namespace Api.TorMarket.Application.DTOs;

public class UpdateCategoryDto
{
    public UpdateCategoryDto(int categoryId, string name)
    {
        CategoryId = categoryId;
        Name = name;
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
}
