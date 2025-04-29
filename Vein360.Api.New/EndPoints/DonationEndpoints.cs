using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Dtos;
using Vein360.Application.Features.Donations.CreateDonation;
using Vein360.Application.Features.Donations.DeleteDonation;
using Vein360.Application.Features.Donations.DispatchDonation;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vien360.Domain.Enums;

namespace Vein360.API.EndPoints
{
    public record CreateDonationRequestData(int ContainerType, int ContainerId, int Weight, List<DonationProductItemDto> Products);
    public static class DonationEndpoints
    {
        public static void MapDonationEndpoints(this WebApplication app)
        {
            app.MapGet("/donations", [Authorize] async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                var donations = await mediator.Send(new GetAllDonationsRequest(), cancellationToken);

                return Results.Ok(donations);
            });

            app.MapGet("/donations/{id}", async (int id, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var donation = await mediator.Send(new GetDonationRequest { Id = id }, cancellationToken);

                return donation is not null ? Results.Ok(donation) : Results.NotFound();
            });

            app.MapPost("/donations", async ([FromBody] CreateDonationRequestData donation, IMediator mediator) =>
            {
                await mediator.Send(donation.Adapt<CreateDonationRequest>());

                return Results.Ok();
            });

            app.MapDelete("/donations/{id}", async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DeleteDonationRequest { DonationId = id });

                return Results.Ok();
            });

            app.MapPatch("/donations/dispatch/{id}", async (int id, IMediator mediator) =>
            {
                await mediator.Send(new DispatchDonationRequest(id));

                return Results.Ok();
            });

            #region OtherEndpoints

            //app.MapGet("/donations/{id}", async (int id, IDonationService donationService) =>
            //{
            //    var donation = await donationService.GetDonationByIdAsync(id);
            //    return donation is not null ? Results.Ok(donation) : Results.NotFound();
            //});
            //app.MapPost("/donations", async (Donation donation, IDonationService donationService) =>
            //{
            //    var createdDonation = await donationService.CreateDonationAsync(donation);
            //    return Results.Created($"/donations/{createdDonation.Id}", createdDonation);
            //});
            //app.MapPut("/donations/{id}", async (int id, Donation donation, IDonationService donationService) =>
            //{
            //    var updatedDonation = await donationService.UpdateDonationAsync(id, donation);
            //    return updatedDonation is not null ? Results.Ok(updatedDonation) : Results.NotFound();
            //});


            #endregion
        }
    }
}
