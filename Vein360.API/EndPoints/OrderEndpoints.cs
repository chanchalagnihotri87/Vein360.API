using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Vein360.Application.Features.Orders.CreateOrder;
using Vein360.Application.Features.Orders.DeleteOrder;
using Vein360.Application.Features.Orders.GetAllOrders;
using Vein360.Application.Features.Orders.GetMyOrders;
using Vein360.Application.Features.Orders.GetOrder;
using Vein360.Application.Features.Orders.UpdateOrder;
using Vein360.Application.Features.Orders.UpdateOrderClinic;
using Vein360.Application.Features.Products.CreateProduct;
using Vein360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public static class OrderEndpoints
    {
        public record UpdateOrderRequestData(int OrderId, int ProductId, int ClinicId, decimal Price, int Status);

        public static void MapOrderEndpoints(this WebApplication app)
        {
            app.MapGet("/orders/myorders", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var orders = await mediator.Send(new GetMyOrdersRequest(), cancellationToken);

                return Results.Ok(orders);
            });

            app.MapGet("/orders/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var order = await mediator.Send(new GetOrderRequest(id));

                return Results.Ok(order);
            });


            app.MapGet("/orders", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var orders = await mediator.Send(new GetAllOrdersRequest());

                return Results.Ok(orders);
            });

            app.MapPost("/orders", [Authorize] async (CreateOrderRequest req, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(req);

                return Results.Ok();
            }).DisableAntiforgery();

            app.MapPatch("/orders/{id}", [Authorize] async (int id, int clinicId, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var order = await mediator.Send(new UpdateOrderClinicRequest(id, clinicId), cancellationToken);

                return Results.Ok(order);
            });

            app.MapPut("/orders", [Authorize] async (UpdateOrderRequestData requestData, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var request = requestData.Adapt<UpdateOrderRequest>();

                var order = await mediator.Send(request, cancellationToken);

                return Results.Ok(order);
            });

            app.MapDelete("/orders/{id}", [Authorize] async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteOrderRequest(id));
                return Results.Ok();
            });
        }
    }
}
