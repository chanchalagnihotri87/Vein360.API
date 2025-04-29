using MediatR;
using Microsoft.AspNetCore.Authorization;
using Vein360.Application.Service.StorageService;

namespace Vein360.API.EndPoints
{
    public static class LabelEndpoints
    {
        public static void MapLabelEndpoints(this WebApplication app)
        {
            app.MapGet("/label/{fileName}", [Authorize] async (string fileName, CancellationToken cancellationToken, IStorageService storageService) =>
            {
                var mimeType = "application/pdf";
                return Results.File(await storageService.GetLabel(fileName), contentType: mimeType);
            });
        }
    }
}
