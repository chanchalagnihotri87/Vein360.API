using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vein360.Application.Common.Dtos;

using Vein360.Application.Features.Donations.CreateDonation;
using Vein360.Application.Features.Donations.DeleteDonation;
using Vein360.Application.Features.Donations.ProcessDonation;
using Vein360.Application.Features.Donations.SortDonation;
using Vein360.Application.Features.Donations.Statistic;
using Vein360.Application.Features.Donations.UpdateContainerId;
using Vein360.Application.Features.Donations.UpdateDonation;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Features.DonationsFeatures.GetDonation;
using Vein360.Application.Features.DonationsFeatures.GetDonorDonations;
using Vein360.Application.Features.DonorPreferences.GetPreferenceByDonorId;
using Vein360.Application.Features.DonorPreferences.SavePreferences;

namespace Vein360.API.EndPoints
{

    public static class DonorPreferenceEndpoints
    {
        public record SaveDonorPreferenceRequestData(int DonorId, int? defaultClinicId);
        public static void MapDonorPreferenceEndpoints(this WebApplication app)
        {

            app.MapPost("/donorpreferences", [Authorize] async ([FromBody] SaveDonorPreferenceRequestData request, IMediator mediator) =>
            {
                await mediator.Send(new SaveDonorPreferenceRequest(request.DonorId, request.defaultClinicId));

                return Results.Ok();
            });

            app.MapGet("/donorpreferences/{donorId}", [Authorize] async (int donorId, IMediator mediator) =>
            {
                var preference = await mediator.Send(new GetPreferenceByDonorIdRequest(donorId));

                return Results.Ok(preference);
            });

        }
    }
}
