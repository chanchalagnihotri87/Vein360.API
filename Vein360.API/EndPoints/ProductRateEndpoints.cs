using MediatR;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Features.ProductRates.GetProductRates;
using Vein360.Application.Features.ProductRates.SaveProductRates;
using static Vein360.API.EndPoints.AccountEndpoints;

namespace Vein360.API.EndPoints
{
    public static class ProductRateEndpoints
    {
        public static void MapProductRateEndpoints(this WebApplication app)
        {
            app.MapGet("/productrates/{userId}", async (int userId, IMediator mediator, IConfiguration configuration) =>
            {
                var productRates = await mediator.Send(new GetProductRateRequest(userId));

                return Results.Ok(productRates);
            });

            app.MapPut("/productrates/{userId}", async (int userId, List<ProductRateDto> productRates, IMediator mediator, IConfiguration configuration) =>
            {
                await mediator.Send(new SaveProductRatesRequest(userId, productRates));

                return Results.Ok();
            });
        }
    }
}
