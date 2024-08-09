using MediatR;

namespace Api.TorMarket.Application.Workflows.Category.DeleteCategory;

public class DeleteCategoryNotification : INotification
{
    public DeleteCategoryNotification(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; set; }
}
