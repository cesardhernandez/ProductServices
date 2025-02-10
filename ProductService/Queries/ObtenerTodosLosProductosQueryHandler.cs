using MediatR;
using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Queries
{
    public class ObtenerTodosLosProductosQueryHandler : IRequestHandler<ObtenerTodosLosProductosQuery, IEnumerable<Producto>>
    {
        private readonly IProductoRepository _repository;

        public ObtenerTodosLosProductosQueryHandler(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Producto>> Handle(ObtenerTodosLosProductosQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}