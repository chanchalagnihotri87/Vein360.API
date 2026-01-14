using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Model
{
    public class PickupAvailabilityResponseModel
    {
        public string transactionId { get; set; }
        public PickupAvailabilityOutput output { get; set; }
        public PickupAvailabilityOption earliestAvailabilityOption
        {
            get
            {
                if (output != null && output.options != null && output.options.Count > 0)
                {
                    return output.options[0];
                }

                return null;
            }
        }

        public PickupAvailabilityOption GetSuitableAvailabilityOption()
        {
            if (output != null && output.options != null && output.options.Count > 0)
            {
                foreach (var option in output.options)
                {
                    if (option.available)
                    {
                        //Check if ready time option is available at 10:30 AM
                            //If available, return this option
                            //If not, continue to next option
                                //Check if ready time option between 9AM to 12 PM is available


                        return option;
                    }
                }
            }


            //If no suitable option found, return null
            return null;

        }
    }

    public class PickupAvailabilityOutput
    {
        public DateTime requestTimestamp { get; set; }
        public List<PickupAvailabilityOption> options { get; set; }
    }

    public class AccessTime
    {
        public int hours { get; set; }
        public int minutes { get; set; }
    }

    public class PickupAvailabilityOption
    {
        public string carrier { get; set; }
        public bool available { get; set; }
        public string pickupDate { get; set; }
        public string cutOffTime { get; set; }
        public AccessTime accessTime { get; set; }
        public bool residentialAvailable { get; set; }
        public List<string> readyTimeOptions { get; set; }
        public string defaultReadyTime { get; set; }
        public List<string> latestTimeOptions { get; set; }
        public string defaultLatestTimeOptions { get; set; }
        public string scheduleDay { get; set; }

    }
}
