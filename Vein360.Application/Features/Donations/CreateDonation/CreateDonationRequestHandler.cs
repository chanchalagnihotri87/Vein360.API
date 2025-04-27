using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Factories;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vien360.Domain.Entities;
using Vien360.Domain.Enums;

namespace Vein360.Application.Features.Donations.CreateDonation
{
    public class CreateDonationRequestHandler : IRequestHandler<CreateDonationRequest>
    {
        private const int USER_ID = 1;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationRepository _donationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;

        public CreateDonationRequestHandler(IShipmentService shipmentService, IDonationRepository donationRepository, IUnitOfWork unitOfWork, IStorageService storageService)
        {
            _shipmentService = shipmentService;
            _donationRepository = donationRepository;
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        public async Task Handle(CreateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = DonationFactory.CreateDonation(request.ContainerType,
                                                               request.ContainerId,
                                                               request.Weight,
                                                               request.Products, USER_ID);

            _donationRepository.Create(donation);

            var shipmentInfo = await _shipmentService.CreateShipmentAsync(request.ContainerType, 
                                                                    request.ContainerId, 
                                                                    request.Weight);

            donation.FedexTransactionId = shipmentInfo.TransactionId;
            donation.MasterTrackingNumber = shipmentInfo.MasterTrackingNumber.ToLong();
            donation.TrackingNumber = shipmentInfo.TrackingNumber.ToLong();

            donation.LabelFileName = await _storageService.StoreLabelAsync(shipmentInfo.TrackingNumber.ToLong(), 
                                                                      shipmentInfo.EncodedLabel);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
