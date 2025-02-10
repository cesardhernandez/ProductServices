using ProductService.Models;

namespace ProductService.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task AddAsync(Producto producto);
    }
}