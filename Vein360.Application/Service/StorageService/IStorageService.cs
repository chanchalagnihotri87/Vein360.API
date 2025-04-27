using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Service.StorageService
{
    public interface IStorageService
    {
        Task<string> StoreLabelAsync(long labelTrackingNumber, string encodedLabelData);
    }
}
