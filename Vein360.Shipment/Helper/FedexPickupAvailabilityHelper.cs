using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Common.Extensions;
using Vein360.Shipment.Model;
using Vein360.Shipment.Service;

namespace Vein360.Shipment.Helper
{
    public class FedexPickupAvailabilityHelper
    {
        private readonly List<PickupAvailabilityOption> _options;

        private static readonly List<PickupTimeType> PickupTimes = new()
        {
            new PickupTimeType { TimeString = "09:00:00", TimeStringIn12HoursFormat = "09:00 AM", Time = new TimeOnly(9,0) },
            new PickupTimeType { TimeString = "09:30:00", TimeStringIn12HoursFormat = "09:30 AM", Time = new TimeOnly(9,30) },
            new PickupTimeType { TimeString = "10:00:00", TimeStringIn12HoursFormat = "10:00 AM", Time = new TimeOnly(10,0) },
            new PickupTimeType { TimeString = "10:30:00", TimeStringIn12HoursFormat = "10:30 AM", Time = new TimeOnly(10,30) },
            new PickupTimeType { TimeString = "11:00:00", TimeStringIn12HoursFormat = "11:00 AM", Time = new TimeOnly(11,0) },
            new PickupTimeType { TimeString = "11:30:00", TimeStringIn12HoursFormat = "11:00 AM", Time = new TimeOnly(11,30) },
            new PickupTimeType { TimeString = "12:00:00", TimeStringIn12HoursFormat = "12:00 PM", Time = new TimeOnly(12,0) },
            new PickupTimeType { TimeString = "12:30:00", TimeStringIn12HoursFormat = "12:30 PM", Time = new TimeOnly(12,30) },
            new PickupTimeType { TimeString = "13:00:00", TimeStringIn12HoursFormat = "01:00 PM", Time = new TimeOnly(13,0) },
            new PickupTimeType { TimeString = "13:30:00", TimeStringIn12HoursFormat = "01:30 PM", Time = new TimeOnly(13,30) },
            new PickupTimeType { TimeString = "14:00:00", TimeStringIn12HoursFormat = "02:00 PM", Time = new TimeOnly(14,0) },
            new PickupTimeType { TimeString = "14:30:00", TimeStringIn12HoursFormat = "02:30 PM", Time = new TimeOnly(14,30) },
            new PickupTimeType { TimeString = "15:00:00", TimeStringIn12HoursFormat = "03:00 PM", Time = new TimeOnly(15,0) },
            new PickupTimeType { TimeString = "15:30:00", TimeStringIn12HoursFormat = "03:30 PM", Time = new TimeOnly(15,30) },
            new PickupTimeType { TimeString = "16:00:00", TimeStringIn12HoursFormat = "04:00 PM", Time = new TimeOnly(16,0) },
            new PickupTimeType { TimeString = "16:30:00", TimeStringIn12HoursFormat = "04:30 PM", Time = new TimeOnly(16,30) },
            new PickupTimeType { TimeString = "17:00:00", TimeStringIn12HoursFormat = "05:00 PM", Time = new TimeOnly(17,0) },
            new PickupTimeType { TimeString = "17:30:00", TimeStringIn12HoursFormat = "05:30 PM", Time = new TimeOnly(17,30) },
            new PickupTimeType { TimeString = "18:00:00", TimeStringIn12HoursFormat = "06:00 PM", Time = new TimeOnly(18,0) }
        };
        private static PickupTimeType Morning_09_00_AM_PickupTime => PickupTimes.First(x => x.Time == new TimeOnly(9, 0));
        private static PickupTimeType Morning_10_30_AM_PickupTime => PickupTimes.First(x => x.Time == new TimeOnly(10, 30));
        private static PickupTimeType Afternoon_12_00_PM_PickupTime => PickupTimes.First(x => x.Time == new TimeOnly(12, 0));


        public FedexPickupAvailabilityHelper(List<PickupAvailabilityOption> options)
        {
            this._options = options;
        }

        public static PickupTimeType DefaultClinicCloseTime = new PickupTimeType { TimeString = "17:00:00", TimeStringIn12HoursFormat = "05:00 PM", Time = new TimeOnly(17, 0) };

        public IList<AvailableOption> GetSuitableAvailabilityOptions()
        {
            List<AvailableOption> suitableOptions = new List<AvailableOption>();

            if (_options == null || !_options.Any())
            {
                return suitableOptions;
            }
           

            foreach (var option in _options)
            {
                if (!option.available && !option.readyTimeOptions.HasItems())
                {
                    continue;
                }

                //Check if ready time option is available at 10:30 AM
                if (option.readyTimeOptions.Contains(Morning_10_30_AM_PickupTime.TimeString))
                {
                    suitableOptions.Add(new AvailableOption(option.pickupDate, Morning_10_30_AM_PickupTime.TimeString));
                    continue;
                }

                //Check if ready time option between 9AM to 12 PM is available
                foreach (var pickupTime in PickupTimes)
                {
                    if (pickupTime.Time >= Morning_09_00_AM_PickupTime.Time && pickupTime.Time <= Afternoon_12_00_PM_PickupTime.Time)
                    {
                        if (option.readyTimeOptions.Contains(pickupTime.TimeString))
                        {
                            suitableOptions.Add(new AvailableOption(option.pickupDate, pickupTime.TimeString));
                            break;
                        }
                    }
                }
            }

            return suitableOptions;
        }




    }

    public record PickupTimeType
    {
        public string TimeString { get; set; }
        public string TimeStringIn12HoursFormat { get; set; }
        public TimeOnly Time { get; set; }
    }

    public record AvailableOption
    {
        private readonly string pickupDate;
        private readonly string pickupTime;

        public AvailableOption(string pickupDate, string pickupTime)
        {
            this.pickupDate = pickupDate;
            this.pickupTime = pickupTime;
        }
        public string PickupDate => pickupDate;
        public string PickupDateTime => $"{pickupDate}T{pickupTime}";
    }
}
