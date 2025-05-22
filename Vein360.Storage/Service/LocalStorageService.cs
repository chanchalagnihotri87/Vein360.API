using Microsoft.AspNetCore.Http;
using Vein360.Application.Common.Extensions;
using Vein360.Application.Service.StorageService;

namespace Vein360.Storage.Service
{
    public class LocalStorageService : IStorageService
    {
        public async Task<string> StoreLabelAsync(long labelTrackingNumber, string encodedLabelData)
        {

            if (encodedLabelData.IsNullOrEmpty())
            {
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

        public async Task<byte[]> GetLabel(string labelFileName)
        {
            var rootPath = System.IO.Directory.GetCurrentDirectory();
            var labelsPath = System.IO.Path.Combine(rootPath, "Labels");

            string filePath = System.IO.Path.Combine(labelsPath, labelFileName);
            if (System.IO.File.Exists(filePath))
            {
                return await File.ReadAllBytesAsync(filePath);
            }

            return [];
        }

        public async Task<string> StoreProductImageAsync(IFormFile formFile)
        {
            string fileName = $"{Guid.NewGuid().ToString()}_{DateTime.Now.Ticks.ToString()}{Path.GetExtension(formFile.FileName)}";

            var rootPath = Directory.GetCurrentDirectory();
            var productPath = Path.Combine(rootPath, "Product");

            if (!Directory.Exists(productPath))
            {
                Directory.CreateDirectory(productPath);
            }

            using (var fileStream = new System.IO.FileStream(System.IO.Path.Combine(productPath, fileName), System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public async Task<byte[]> GetProductImageAsync(string imageFileName)
        {
            var rootPath = System.IO.Directory.GetCurrentDirectory();
            var productsPath = System.IO.Path.Combine(rootPath, "Product");

            string filePath = System.IO.Path.Combine(productsPath, imageFileName);
            if (System.IO.File.Exists(filePath))
            {
                return await File.ReadAllBytesAsync(filePath);
            }

            return [];
        }

    }
}
