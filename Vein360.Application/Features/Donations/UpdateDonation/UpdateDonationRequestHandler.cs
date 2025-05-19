using Microsoft.EntityFrameworkCore;
using Vein360.Application.Features.DonationsFeatures.GetAllDonations;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationContainerRepository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Service.AuthenticationService;
using Vein360.Application.Service.ShipmentService;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Donations.UpdateDonation
{
    public class UpdateDonationRequestHandler : IRequestHandler<UpdateDonationRequest, GetAllDonationsResponse>
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthInfoService _authInfo;
        private readonly IStorageService _storageService;
        private readonly IShipmentService _shipmentService;
        private readonly IDonationRepository _donationRepository;
        private readonly IDonationContainerRepository _donationContainerTypeRepo;

        public UpdateDonationRequestHandler(IUnitOfWork unitOfWork,
                                            IAuthInfoService authInfo,
                                            IStorageService storageService,
                                            IShipmentService shipmentService,
                                            IDonationRepository donationRepository,
                                            IDonationContainerRepository donationContainerTypeRepo)
        {
            _unitOfWork = unitOfWork;
            _authInfo = authInfo;
            _storageService = storageService;
            _shipmentService = shipmentService;
            _donationRepository = donationRepository;
            _donationContainerTypeRepo = donationContainerTypeRepo;
        }

        public async Task<GetAllDonationsResponse> Handle(UpdateDonationRequest request, CancellationToken cancellationToken)
        {
            Donation donation = await _donationRepository.GetAsync(x => x.Id == request.Id, cancellationToken, x => x.Include(x => x.Products).ThenInclude(x => x.Product));

            donation.ContainerType = request.ContainerType;
            donation.DonationContainerId = request.ContainerId;
            donation.Length = request.length;
            donation.Width = request.width;
            donation.Height = request.height;

            foreach (var donationProduct in donation.Products)
            {
                var requestProduct = request.Products.FirstOrDefault(x => x.Id == donationProduct.Id);

                if (requestProduct == null)
                {
                    donation.Products.Remove(donationProduct);
                    continue;
                }

                donationProduct.ProductId = requestProduct.ProductId;
                donationProduct.Units = requestProduct.Units;
                donationProduct.Accepted = requestProduct.Accepted;
                donationProduct.Rejected = requestProduct.Rejected;

            }

            foreach (var requestProduct in request.Products.Where(x => x.Id == 0))
            {
                donation.Products.Add(new DonationProduct
                {
                    ProductId = requestProduct.ProductId,
                    Units = requestProduct.Units,
                    Accepted = requestProduct.Accepted,
                    Rejected = requestProduct.Rejected
                });
            }



            await _unitOfWork.SaveAsync(cancellationToken);


            return donation.Adapt<GetAllDonationsResponse>();
        }
    }
}
