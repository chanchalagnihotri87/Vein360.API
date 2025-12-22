using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Domain.Entities;

namespace Vein360.Application.Common.Factories
{
    public class PickupFactory
    {
        public static Pickup CreatePickup(int clinicId, string pickupTransactionId, string pickupConfirmationCode, DateTime pickupDateTime)
        {
            return new Pickup
            {
                ClinicId = clinicId,
                PickupTransactionId = pickupTransactionId,
                PickupConfirmationCode = pickupConfirmationCode,
                PickupDateTime = pickupDateTime
            };
        }
    }
}
