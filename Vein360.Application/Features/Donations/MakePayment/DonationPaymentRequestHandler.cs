using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Exceptions;
using Vein360.Application.Repository;
using Vein360.Application.Repository.DonationsRepository;
using Vein360.Application.Repository.PaymentRepository;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Donations.MakePayment
{
    public class DonationPaymentRequestHandler : IRequestHandler<DonationPaymentRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDonationRepository _donationRepo;
        private readonly IDonationPaymentRepository _donationPaymentRepo;

        public DonationPaymentRequestHandler(
            IUnitOfWork unitOfWork,
            IDonationRepository donationRepo,
            IDonationPaymentRepository donationPaymentRepo
            )
        {
            _unitOfWork = unitOfWork;
            _donationRepo = donationRepo;
            _donationPaymentRepo = donationPaymentRepo;
        }



        public async Task Handle(DonationPaymentRequest request, CancellationToken cancellationToken)
        {
            var donation = await _donationRepo.GetAsync(x => x.ContainerId == request.ContainerId, cancellationToken);

            if (donation is null)
            {
                throw new NotFoundException($"Donation with container id {request.ContainerId} not found.");
            }

            if (donation.IsPaid)
            {
                throw new CustomValidationException("This donation is already paid.");
            }

            //Make donation payment
            var donationPayment = new DonationPayment
            {
                DonationId = donation.Id,
                Date = request.Date,
                TransactionType = request.TransactionType,
                Amount = request.Amount,
            };

            _donationPaymentRepo.Create(donationPayment);


            //Mark Donation paid
            donation.Status = DonationStatus.Paid;

            _donationRepo.Update(donation);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
