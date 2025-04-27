using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Shipment.Service
{
    public class FedexHelper
    {
        private static readonly List<FedexPackage> FedexPackages = new()
        {
            new FedexPackage { Id = 1, Code = "YOUR_PACKAGING", Description = "Customer Packaging, FedEx Express Services" },
            new FedexPackage { Id = 2, Code = "YOUR_PACKAGING", Description = "FedEx Ground® and FedEx Home Delivery" },
            new FedexPackage { Id = 3, Code = "YOUR_PACKAGING", Description = "Customer Packaging, FedEx Ground Economy (Formerly known as FedEx SmartPost) Services" },
            new FedexPackage { Id = 4, Code = "FEDEX_ENVELOPE", Description = "FedEx Envelope" },
            new FedexPackage{ Id = 5, Code = "FEDEX_BOX",  Description = "FedEx® Box"},
            new FedexPackage{ Id = 6, Code = "FEDEX_SMALL_BOX", Description =  "FedEx® Small Box"},
            new FedexPackage{ Id = 7, Code = "FEDEX_MEDIUM_BOX",Description =  "FedEx® Medium Box" },
            new FedexPackage{ Id = 8, Code = "FEDEX_LARGE_BOX",Description =  "FedEx® Large Box"},
            new FedexPackage{ Id = 9, Code = "FEDEX_EXTRA_LARGE_BOX",Description =  "FedEx® Extra Large Box"},
            new FedexPackage{ Id = 10, Code = "FEDEX_10KG_BOX", Description = "FedEx® 10kg Box"},
            new FedexPackage{ Id = 11, Code = "FEDEX_25KG_BOX",Description =  "FedEx® 25kg Box"},
            new FedexPackage{ Id = 12, Code = "FEDEX_PAK",Description =  "FedEx® Pak"},
            new FedexPackage{ Id = 13, Code = "FEDEX_TUBE",Description =  "FedEx® Tube"}
        };

        public static string GetFedexPackagingCode(int id)
        {
            var pack = FedexPackages.FirstOrDefault(p => p.Id == id);
            return pack?.Code;
        }

    }

    public record FedexPackage
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
