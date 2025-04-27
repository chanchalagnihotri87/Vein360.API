using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vien360.Domain.Enums
{
    public enum DonationContainerStatus
    {
        Requested = 1,
        Approved = 2,
        Dispatched = 3,
        Received = 4,
        Filled = 5,
        Donated = 6,
        Processed = 7,
        Rejected = 8
    }
}
