using MediatR;
using Vein360.Application.Features.Products.GetAllProducts;

namespace Vein360.API.EndPoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/products", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var donations = await mediator.Send(new GetAllProductsRequest(), cancellationToken);

                return Results.Ok(donations);
            });
        }
    }
}
