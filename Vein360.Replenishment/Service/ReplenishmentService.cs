using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Vein360.Application.Service.ReplenishmentService;
using Vein360.Domain.Entities;

namespace Vein360.Replenishment.Service
{
    public class ReplenishmentService : IReplenishmentService
    {
        private readonly IConfiguration _configuration;
        public ReplenishmentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int CreateReplenishmentOrder(int containerTypeId, int units, int clinicId, int donationContainerId, string approvedBy)
        {
            var localSystemApiUrl = _configuration["LocalSystemApiUrl"]!;

            var data = new
            {
                ClinicId = clinicId,
                ContainerType = containerTypeId,
                ApprovedQty = units,
                DonationContainerId = donationContainerId,
                ApprovedBy = approvedBy
            };

            string jsonContent = JsonSerializer.Serialize(data);

            using StringContent content = new(jsonContent, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(localSystemApiUrl);

            var res = client.PostAsync("/create-replenishment", content).Result;

            res.EnsureSuccessStatusCode();

            var replenishmentIdString = res.Content.ReadAsStringAsync().Result;

            return Convert.ToInt32(replenishmentIdString);
        }
    }
}
