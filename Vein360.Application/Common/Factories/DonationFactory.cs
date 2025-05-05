using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Dtos;
using Vein360.Application.Features.Donations.CreateDonation;
using Vien360.Domain.Entities;
using Vien360.Domain.Enums;

namespace Vein360.Application.Common.Factories
{
    public class DonationFactory
    {
        public static Donation CreateDonation(ContainerType containerType, int containerId, int weight, List<DonationProductItemDto> products, int userId)
        {
            return new Donation
            {
                ContainerType = containerType,
                DonationContainerId = containerType == ContainerType.Vien360Container ? containerId : null,
                FedexContainerId = containerType == ContainerType.FedexContainer ? containerId : null,
                Weight = weight,
                Status = DonationStatus.Pending,
                DonorId = userId,
                Products = products.Select(product => new DonationProduct { ProductId = product.ProductId, Units = product.Units }).ToHashSet(),
            };
        }
    }
}
