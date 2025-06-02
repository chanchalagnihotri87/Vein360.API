using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Service.StorageService
{
    public interface IStorageService
    {
        Task<byte[]> GetLabel(string labelFileName);
        Task<string> StoreEncodedLabelAsync(long labelTrackingNumber, string encodedLabelData);
        Task<string> StoreUrlLabelAsync(long labelTrackingNumber, string labelUrl);
        Task<string> StoreProductImageAsync(IFormFile formFile);
        Task<byte[]> GetProductImageAsync(string imageFileName);

        string GetMimeType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();

            switch (extension)
            {
                case ".pdf":
                    return "application/pdf";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "text/plain";
            }

        }
    }
}
