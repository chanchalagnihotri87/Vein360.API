using MediatR;
using Microsoft.AspNetCore.Authorization;
using Vein360.Application.Features.UserProducts.GetProduct;
using Vein360.Application.Features.UserProducts.GetProducts;

namespace Vein360.API.EndPoints
{
    public static class UserProductEndpoints
    {
        public static void MapUserProductEndpoints(this WebApplication app)
        {
            app.MapGet("/user/products", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var products = await mediator.Send(new GetUserProductsRequest());

                return Results.Ok(products);
            });

            app.MapGet("/user/product/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var product = await mediator.Send(new GetUserProductRequest(id));

                return Results.Ok(product);
            });

        }
    }
}
