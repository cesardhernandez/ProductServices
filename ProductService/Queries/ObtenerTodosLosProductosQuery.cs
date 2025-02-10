using MediatR;
using ProductService.Models;

namespace ProductService.Queries
{
    public class ObtenerTodosLosProductosQuery : IRequest<IEnumerable<Producto>>
    {
    }
}