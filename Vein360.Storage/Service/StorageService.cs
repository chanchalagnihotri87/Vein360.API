using Vein360.Application.Extensions;
using Vein360.Application.Service.StorageService;

namespace Vein360.Storage.Service
{
    public class StorageService : IStorageService
    {
        public async Task<string> StoreLabelAsync(long labelTrackingNumber, string encodedLabelData)
        {

            if (encodedLabelData.IsNullOrEmpty()) {
                return null;
            }

            var rootPath = Directory.GetCurrentDirectory();
            var labelsPath = Path.Combine(rootPath, "Labels");

           string fileName = $"{labelTrackingNumber}_{DateTime.Now.Ticks.ToString()}.pdf";

            if (!Directory.Exists(labelsPath))
            {
                Directory.CreateDirectory(labelsPath);
            }

            using (var fileStream = new System.IO.FileStream(System.IO.Path.Combine(labelsPath, fileName), System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var fileData = Convert.FromBase64String(encodedLabelData);
                await fileStream.WriteAsync(fileData, 0, fileData.Length);
            }

            return fileName;
        }
    }
}
