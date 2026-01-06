using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class PickupErrorResponseModel
    {
        //{"transactionId":"4a74a257-83fe-4a22-9b8d-eb2843a2fdb8","errors":[{"code":"PICKUPDATE.NOT.WORKINGDAY","message":"GENERIC.ERROR"}]}
        public string transactionId { get; set; }
        public List<PickupError> errors { get; set; }

        public bool IsNotWorkingDayError => errors.Any(x => x.code == PickupErrorCodes.PICKUPDATE_NOT_WORKINGDAY);

        public class PickupErrorCodes
        {
            public const string PICKUPDATE_NOT_WORKINGDAY = "PICKUPDATE.NOT.WORKINGDAY";
        }

    }

public class PickupError
{
    public string code { get; set; }
    public string message { get; set; }
}
}
