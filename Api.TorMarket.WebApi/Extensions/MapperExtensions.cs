using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;
using Api.TorMarket.WebApi.DTOs.Requests;

namespace Api.TorMarket.WebApi.Extensions;

public static class MapperExtensions
{
    public static CreateProductCommand ToCommand(this CreateProductRequestDto request)
    {
        return new CreateProductCommand
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            AvailableFrom = request.AvailableFrom
        };
    }
}
