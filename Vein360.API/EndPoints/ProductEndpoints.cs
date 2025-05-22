using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Vein360.Application.Features.Products.CreateProduct;
using Vein360.Application.Features.Products.DeleteProduct;
using Vein360.Application.Features.Products.GetAllProductListItems;
using Vein360.Application.Features.Products.GetAllProducts;
using Vein360.Application.Features.Products.UpdateProduct;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapGet("/products", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var products = await mediator.Send(new GetAllProductsRequest(), cancellationToken);

                return Results.Ok(products);
            });

            app.MapGet("/products/listitems", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var products = await mediator.Send(new GetAllProductListItemsRequest(), cancellationToken);

                return Results.Ok(products);
            });

            app.MapPost("/products", [Authorize] async ([FromForm] CreateProductRequest req, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(req);

                return Results.Ok();
            }).DisableAntiforgery();

            app.MapPut("/products", [Authorize] async ([FromForm] UpdateProductRequest req, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(req);

                return Results.Ok();
            }).DisableAntiforgery();

            app.MapDelete("/products/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteProductRequest(id));

                return Results.Ok();
            }).DisableAntiforgery();



            app.MapGet("/products/image/{fileName}", [Authorize] async (string fileName, CancellationToken cancellationToken, IStorageService storageService) =>
            {
                return Results.File(await storageService.GetProductImageAsync(fileName), contentType: storageService.GetMimeType(fileName));
            });
        }
    }
}
