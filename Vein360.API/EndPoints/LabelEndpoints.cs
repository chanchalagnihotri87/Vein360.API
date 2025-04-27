using MediatR;

namespace Vein360.API.EndPoints
{
    public static class LabelEndpoints
    {
        public static void MapLabelEndpoints(this WebApplication app)
        {
            app.MapGet("/label/{fileName}", async (string fileName, CancellationToken cancellationToken) =>
            {
                var mimeType = "application/pdf";
                var rootPath = System.IO.Directory.GetCurrentDirectory();
                var labelsPath = System.IO.Path.Combine(rootPath, "Labels");

                string filePath = System.IO.Path.Combine(labelsPath, fileName);
                if (!System.IO.File.Exists(filePath))
                    return Results.NotFound();

                return Results.File(filePath, contentType: mimeType);
            });
        }
    }
}
