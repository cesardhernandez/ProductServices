using MediatR;
using ProductService.Commands;
using ProductService.Queries;
using ProductService.Repositories;
using ProductService.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Registrar MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Registrar el repositorio como un servicio singleton
builder.Services.AddSingleton<IProductoRepository, ProductoRepository>();

var app = builder.Build();


// Endpoints
app.MapPost("/productos", async (IMediator mediator, CrearProductoDTO crearProductoDTO) =>
{
    var command = new CrearProductoCommand
    {
        Nombre = crearProductoDTO.Nombre,
        Precio = crearProductoDTO.Precio
    };

    var productoId = await mediator.Send(command);
    return Results.Created($"/productos/{productoId}", new { Id = productoId });
});

app.MapGet("/productos", async (IMediator mediator) =>
{
    var productos = await mediator.Send(new ObtenerTodosLosProductosQuery());
    var productosDTO = productos.Select(p => new ProductoDTO
    {
        Id = p.Id,
        Nombre = p.Nombre,
        Precio = p.Precio
    });

    return Results.Ok(productosDTO);
});

app.Run();