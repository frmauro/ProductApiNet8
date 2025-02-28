using ProductApi.Entities;

namespace ProductApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
}