using MediatR;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Features.ProductRates.GetProductRates;
using Vein360.Application.Features.ProductRates.SaveProductRates;
using Vein360.Domain.Entities;
using Vein360.Domain.Enums;
using static Vein360.API.EndPoints.AccountEndpoints;

namespace Vein360.API.EndPoints
{
    public static class ProductRateEndpoints
    {
        public class ProductRateRequestDto
        {
            public int ProductId { get; set; }
            public double? SellingPrice { get; set; }
            public bool PayToSalesCredit { get; set; }
            public double? BuyingPrice { get; set; }
            public bool PayFromSalesCredit { get; set; }
        }

        public static void MapProductRateEndpoints(this WebApplication app)
        {
            app.MapGet("/productrates/{userId}", async (int userId, IMediator mediator, IConfiguration configuration) =>
            {
                var productRates = await mediator.Send(new GetProductRateRequest(userId));

                return Results.Ok(productRates);


            });

            app.MapPut("/productrates/{userId}/{trade}", async (int userId, int trade, List<ProductRateDto> productRates, IMediator mediator, IConfiguration configuration) =>
            {
                await mediator.Send(new SaveProductRatesRequest(userId, (TradeType)trade, productRates));

                return Results.Ok();
            });
        }
    }
}
