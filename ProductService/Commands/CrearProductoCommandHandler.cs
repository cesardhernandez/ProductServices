using MediatR;
using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Commands
{
    public class CrearProductoCommandHandler : IRequestHandler<CrearProductoCommand, Guid>
    {
        private readonly IProductoRepository _repository;

        public CrearProductoCommandHandler(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CrearProductoCommand request, CancellationToken cancellationToken)
        {
            var producto = new Producto
            {
                Id = Guid.NewGuid(),
                Nombre = request.Nombre,
                Precio = request.Precio
            };

            await _repository.AddAsync(producto);
            return producto.Id;
        }
    }
}