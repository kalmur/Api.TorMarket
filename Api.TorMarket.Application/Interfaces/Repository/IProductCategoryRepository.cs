using Api.TorMarket.Domain.Entities;
using Api.TorMarket.Domain.Models;

namespace Api.TorMarket.Application.Interfaces.Repository;

public interface IProductCategoryRepository
{
    //Task<CategoryModel?> GetCategoryById(int id, CancellationToken cancellationToken);
    Task AddCategoryAsync(ProductCategoryEntity categoryEntity, CancellationToken cancellationToken);
    Task RemoveCategoryAsync(ProductCategoryEntity categoryEntity, CancellationToken cancellationToken);
}
