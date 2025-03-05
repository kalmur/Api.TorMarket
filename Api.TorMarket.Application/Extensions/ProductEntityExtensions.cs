using Api.TorMarket.Application.Repositories.Requests;
using Api.TorMarket.Application.Workflows.Product.Commands.CreateProduct;
using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Extensions;

public static class ProductEntityExtensions
{
    public static Product ToModel(this ProductEntity entity)
    {
        return new Product
        {
            ProductId = entity.ProductId,
            UserId = entity.UserId,
            CategoryId = entity.CategoryId,
            Name = entity.Name,
            Price = entity.Price,
            Description = entity.Description,
            AvailableFrom = entity.AvailableFrom
        };
    }

    public static ProductEntity ToEntity(this CreateProductRequest request)
    {
        return new ProductEntity
        {
            UserId = request.UserId,
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            AvailableFrom = request.AvailableFrom
        };
    }

    public static CreateProductRequest ToRequest(this CreateProductCommand command)
    {
        return new CreateProductRequest
        {
            UserId = command.UserId,
            CategoryId = command.CategoryId,
            Name = command.Name,
            Price = command.Price,
            Description = command.Description,
            AvailableFrom = command.AvailableFrom
        };
    }
}
