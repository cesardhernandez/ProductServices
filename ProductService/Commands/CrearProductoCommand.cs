using MediatR;

namespace ProductService.Commands
{
    public class CrearProductoCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}