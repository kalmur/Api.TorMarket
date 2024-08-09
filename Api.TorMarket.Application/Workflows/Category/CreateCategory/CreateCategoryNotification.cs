using MediatR;

namespace Api.TorMarket.Application.Workflows.Category.CreateCategory;

public class CreateCategoryNotification : INotification
{
    public CreateCategoryNotification(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
