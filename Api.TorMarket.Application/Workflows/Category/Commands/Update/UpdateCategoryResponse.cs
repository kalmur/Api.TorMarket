namespace Api.TorMarket.Application.Workflows.Category.Commands.Update;

public class UpdateCategoryResponse
{
    public UpdateCategoryResponse(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}