using MediatR;

namespace Api.TorMarket.Application.Workflows.Category.UpdateCategory;

public class UpdateCategoryRequest : IRequest<UpdateCategoryResponse>
{
    public UpdateCategoryRequest(int categoryId, string name)
    {
        CategoryId = categoryId;
        Name = name;
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
}
