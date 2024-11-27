using MediatR;
using OneOf;

namespace Api.TorMarket.Application.Workflows.Category.Commands.Update;

public class UpdateCategoryRequest : IRequest<OneOf<UpdateCategoryResponse, UpdateCategoryError>>
{
    public UpdateCategoryRequest(int categoryId, string name)
    {
        CategoryId = categoryId;
        Name = name;
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
}
