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
            new FedexPackage { Id = 1, Code = "YOUR_PACKAGING", Description = "Customer Packaging, FedEx Express Services", Weight=68 },
            new FedexPackage { Id = 2, Code = "YOUR_PACKAGING", Description = "FedEx Ground® and FedEx Home Delivery", Weight=32 },
            new FedexPackage { Id = 3, Code = "YOUR_PACKAGING", Description = "Customer Packaging, FedEx Ground Economy (Formerly known as FedEx SmartPost) Services", Weight=32 },
            new FedexPackage { Id = 4, Code = "FEDEX_ENVELOPE", Description = "FedEx Envelope",  Weight=0.5 },
            new FedexPackage{ Id = 5, Code = "FEDEX_BOX",  Description = "FedEx® Box", Weight=9},
            new FedexPackage{ Id = 6, Code = "FEDEX_SMALL_BOX", Description =  "FedEx® Small Box", Weight = 9},
            new FedexPackage{ Id = 7, Code = "FEDEX_MEDIUM_BOX",Description =  "FedEx® Medium Box", Weight = 9 },
            new FedexPackage{ Id = 8, Code = "FEDEX_LARGE_BOX",Description =  "FedEx® Large Box", Weight = 9},
            new FedexPackage{ Id = 9, Code = "FEDEX_EXTRA_LARGE_BOX",Description =  "FedEx® Extra Large Box", Weight = 9},
            new FedexPackage{ Id = 10, Code = "FEDEX_10KG_BOX", Description = "FedEx® 10kg Box", Weight = 10},
            new FedexPackage{ Id = 11, Code = "FEDEX_25KG_BOX",Description =  "FedEx® 25kg Box", Weight = 25},
            new FedexPackage{ Id = 12, Code = "FEDEX_PAK",Description =  "FedEx® Pak", Weight = 9},
            new FedexPackage{ Id = 13, Code = "FEDEX_TUBE",Description =  "FedEx® Tube", Weight = 9}
        };

        public static string GetFedexPackagingCode(int id)
        {
            var pack = FedexPackages.FirstOrDefault(p => p.Id == id);
            return pack?.Code;
        }

        public static double GetFedexPackageWeight(int id)
        {
            var pack = FedexPackages.FirstOrDefault(p => p.Id == id);
            return pack.Weight;
        }

    }

    public record FedexPackage
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
    }
}
