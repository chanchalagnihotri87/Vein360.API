using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Service.StorageService;

namespace Vein360.Storage.Service
{
    public class AzureLocalStorageService : IStorageService
    {
        private readonly IConfiguration _configuration;
        private const string containerName = "labels";

        public AzureLocalStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> StoreLabelAsync(long labelTrackingNumber, string encodedLabelData)
        {
            var blobName = $"{labelTrackingNumber}_{DateTime.Now.Ticks.ToString()}.pdf";


            var container = await GetBlobContainerClient();


            using var memoryStream = new MemoryStream(Convert.FromBase64String(encodedLabelData));


            //Main code to store blob in Azure Storage

            var blob = container.GetBlobClient(blobName);

            await blob.UploadAsync(memoryStream, true);

            //var client = await container.UploadBlobAsync(blobName, memoryStream);

            return blobName;
        }



        public async Task<byte[]> GetLabel(string labelFileName)
        {

            var container = await GetBlobContainerClient();

            var blob = container.GetBlobClient(labelFileName);


            if (blob.ExistsAsync().Result)
            {
                using (var ms = new MemoryStream())
                {
                    blob.DownloadTo(ms);
                    return ms.ToArray();
                }
            }
            return [];

        }

        private async Task<BlobContainerClient> GetBlobContainerClient()
        {
            try
            {
                var containerClient = new BlobContainerClient(_configuration["StorageConnectionString"], containerName);

                await containerClient.CreateIfNotExistsAsync();

                return containerClient;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
