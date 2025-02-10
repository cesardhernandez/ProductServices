using System.Collections.Concurrent;
using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ConcurrentDictionary<Guid, Producto> _productos = new();

        public Task<IEnumerable<Producto>> GetAllAsync()
        {
            return Task.FromResult(_productos.Values.AsEnumerable());
        }

        public Task AddAsync(Producto producto)
        {
            _productos[producto.Id] = producto;
            return Task.CompletedTask;
        }
    }
}