using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Common.Dtos
{
    public class AvailableTimeDto : IPickupTime
    {
        public string ReadyDateString { get; set; } = string.Empty;
        public string ReadyDateTimeString { get; set; } = string.Empty;
        public string CloseTime { get; set; } = string.Empty;
        public DateTime ReadyDateTime => DateTime.Parse(ReadyDateTimeString);
    }

    public interface IPickupTime
    {
        string ReadyDateString { get; set; }
        string ReadyDateTimeString { get; set; }
        string CloseTime { get; set; }

        public DateTime ReadyDateTime { get; }
    }
}
