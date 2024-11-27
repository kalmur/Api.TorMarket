using MediatR;

namespace Api.TorMarket.Application.Workflows.Category.Commands.Delete;

public class DeleteCategoryNotification : INotification
{
    public DeleteCategoryNotification(int categoryId)
    {
        CategoryId = categoryId;
    }

    public int CategoryId { get; set; }
}
