using Microsoft.EntityFrameworkCore;
using Vein360.Application.Common.Helpers.PasswordHelper;

namespace Vein360.Persistence
{
    public class Vein360Context : DbContext
    {
        public Vein360Context(DbContextOptions<Vein360Context> options) : base(options)
        {
        }

        protected Vein360Context()
        {
        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vein360ContainerType> Vein360ContainerTypes { get; set; }
        public DbSet<Vein360Container> Vein360Containers { get; set; }
        public DbSet<DonationContainer> DonationContainers { get; set; }
        public DbSet<Vein360User> Vein360Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ShippingLabel> ShippingLabels { get; set; }
        public DbSet<DonorPreference> DonorPreferences { get; set; }
        public DbSet<UserProductRate> UserProductRates { get; set; }
        public DbSet<DonationPayment> DonationPayments { get; set; }
        public DbSet<Order> Orders { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Vein360ProductId = "CF7-3-60", Name = "ClosureFast Catheter", Type = ProductType.ClosureFast, Price = 1000, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 2, Vein360ProductId = "CF7-7-100", Name = "ClosureFast Catheter", Type = ProductType.ClosureFast, Price = 1800, Image = "reprocessed-closurefast-catheter-100B.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 3, Vein360ProductId = "CF7-7-60", Name = "ClosureFast Catheter, 60 cm", Type = ProductType.ClosureFast, Price = 900, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 4, Vein360ProductId = "86700", Name = "Clinically Soiled Visions PV 018", Type = ProductType.IVUS, Price = 2000, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 5, Vein360ProductId = "88901", Name = "Clinically Soiled Visions PV 035", Type = ProductType.IVUS, Price = 1200, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 6, Vein360ProductId = "89900", Name = "Clinically Soiled Refinity IVUS Catheter", Type = ProductType.IVUS, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 7, Vein360ProductId = "014R", Name = "Clinically Soiled Visions PV014P RX", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 8, Vein360ProductId = "85900P", Name = "Clinicially Soiled Eagle Eye Platinum", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-closurefast-catheter-100B.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 9, Vein360ProductId = "85900PST", Name = "Clinically Soiled Eagle Eye Platinum ST", Type = ProductType.IVUS, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 10, Vein360ProductId = "85910P", Name = "Clinically Soiled Visions 014 Platinum", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 11, Vein360ProductId = "600001000", Name = " Clinically Soiled Ambu® aScope™ 4 Cysto, Reverse Deflection", Type = ProductType.Urology, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 12, Vein360ProductId = "601001000", Name = " Clinically Soiled Ambu® aScope™ 4 Cysto, Standard Deflection", Type = ProductType.Urology, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 13, Vein360ProductId = "602001000", Name = "Clinically Soiled Ambu aScope 5 Cysto HD – Reverse Deflection", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 14, Vein360ProductId = "603001000", Name = "Clinically Soiled Ambu aScope 5 Cysto HD – Standard Deflection", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-closurefast-catheter-100B.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 15, Vein360ProductId = "AX20408", Name = "Dornier Axis II Model E Reverse Deflection", Type = ProductType.Urology, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 16, Vein360ProductId = "AX20409", Name = "Dornier Axis II Model E Standard Deflection", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 17, Vein360ProductId = "AX20411", Name = "Dornier Axis II Cystoscope", Type = ProductType.Urology, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 18, Vein360ProductId = "AX20413", Name = "Dornier Axis II Model D Reverse Deflection", Type = ProductType.Urology, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 19, Vein360ProductId = "AX20414", Name = "Dornier Axis II Model D Standard Deflection", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 20, Vein360ProductId = "AX93US31B", Name = "Dornier Axis Ureteroscope", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-closurefast-catheter-100B.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 21, Vein360ProductId = "M0067913500", Name = "LithoVue Standard Deflection", Type = ProductType.Urology, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 22, Vein360ProductId = "M0067913600", Name = "LithoVue Reverse Deflection", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 23, Vein360ProductId = "M0067919900", Name = "LithoVue Empower", Type = ProductType.Urology, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 24, Vein360ProductId = "M0067940000", Name = "LithoVue™ Elite Standard Deflection w/ pressure monitoring", Type = ProductType.Urology, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 25, Vein360ProductId = "M0067940500", Name = "LithoVue™ Elite Reverse Deflection w/ pressure monitoring", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 26, Vein360ProductId = "M0067941000", Name = "LithoVue™ Elite Standard Deflection w/o pressure monitoring", Type = ProductType.Urology, Price = 1500, Image = "reprocessed-closurefast-catheter-100B.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 27, Vein360ProductId = "M0067941500", Name = "LithoVue™ Elite Reverse Deflection w/o pressure monitoring", Type = ProductType.Urology, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sort, CreatedDate = new DateTime(2025, 4, 16) },

                new Product { Id = 28, Vein360ProductId = "VEN-PV-018", Name = "Visions PV 018 Digital IVUS Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 29, Vein360ProductId = "VEN-PV-035", Name = "Visions PV 035 Digital IVUS Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 30, Vein360ProductId = "VEN-PV-014R", Name = "Visions 014 Platinum RX Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 31, Vein360ProductId = "VEN-PV-EEP", Name = "Eagle Eye Platinum Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 32, Vein360ProductId = "VEN-PV-EEPST", Name = "Eagle Eye Platinum Short Tip Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 33, Vein360ProductId = "VEN-PV-014P", Name = "Visions 014 Platinum Catheter (Sterile Single)", Type = ProductType.IVUS, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 34, Vein360ProductId = "VEN-7-60B", Name = "Sterile case of 10 ClosureFast CF7-7-60 catheters: 7cm heating length x 60cm insertable length", Type = ProductType.ClosureFast, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 35, Vein360ProductId = "VEN-7-100B", Name = "Sterile case of 10 ClosureFast CF7-7-100 catheters: 7cm heating length x 100cm insertable length", Type = ProductType.ClosureFast, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 36, Vein360ProductId = "VEN-3-60B", Name = "Sterile case of 10 ClosureFast CF7-3-60 catheters: 3cm heating length x 60cm insertable length", Type = ProductType.ClosureFast, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 37, Vein360ProductId = "VEN-10142S", Name = "Merit Medical Basic Procedure Pack (single)", Type = ProductType.ProcedurePack, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 38, Vein360ProductId = "VEN-10144S", Name = "Merit Medical Premium Procedure Pack (single)", Type = ProductType.ProcedurePack, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 39, Vein360ProductId = "VEN-10152S", Name = "Merit Medical Complete Pack (w/ 7/11 introducer sheath) (single)", Type = ProductType.ProcedurePack, Price = 1500, Image = "basic-procedure-pack.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 40, Vein360ProductId = "VEN-10165S", Name = "Merit Procedure Pack Complete with Introducer Sheath 7Fx7cm w (single)", Type = ProductType.ProcedurePack, Price = 1500, Image = "reprocessed-eagle-eye-platinum-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 41, Vein360ProductId = "VEN-10130S", Name = "Introducer Sheath K15-00201 (single)", Type = ProductType.Introducer, Price = 1500, Image = "complete-procedure-pack-7f-x-7-cm-introducer-kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 42, Vein360ProductId = "VEN-10147S", Name = "Introducer Sheath 7Fx11cm with Stainless (single)", Type = ProductType.Introducer, Price = 1500, Image = "7F-x-7-cm-Introducer-Sheath-Kit.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 43, Vein360ProductId = "VEN-10171S", Name = "7Fx7 Introducer Sheath 0.018 SS with Echo Needle (single)", Type = ProductType.Introducer, Price = 1500, Image = "reprocessed-closurefast-catheter.jpg", Trade = TradeType.Sale, CreatedDate = new DateTime(2025, 4, 16) }
            );

            modelBuilder.Entity<Vein360ContainerType>().HasData(
                new Vein360ContainerType { Id = 1, Name = "Vein360 Kit", EstimatedWeight = 6, Length = 14, Width = 11, Height = 12, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360ContainerType { Id = 2, Name = "Customer Shipper", EstimatedWeight = 10, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360ContainerType { Id = 3, Name = "Urology Kit", EstimatedWeight = 20, Length = 24, Width = 18, Height = 8, CreatedDate = new DateTime(2025, 4, 16) });

            modelBuilder.Entity<Vein360Container>().HasData(
                new Vein360Container { Id = 1, ContainerTypeId = 1, ContainerCode = "CNT100001", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 2, ContainerTypeId = 2, ContainerCode = "CNT100002", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 3, ContainerTypeId = 3, ContainerCode = "CNT100003", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 4, ContainerTypeId = 2, ContainerCode = "CNT100004", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 5, ContainerTypeId = 1, ContainerCode = "CNT100005", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 6, ContainerTypeId = 2, ContainerCode = "CNT100006", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 7, ContainerTypeId = 3, ContainerCode = "CNT100007", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 8, ContainerTypeId = 2, ContainerCode = "CNT100008", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 9, ContainerTypeId = 1, ContainerCode = "CNT100009", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 10, ContainerTypeId = 2, ContainerCode = "CNT100010", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 11, ContainerTypeId = 3, ContainerCode = "CNT100011", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 12, ContainerTypeId = 1, ContainerCode = "CNT100012", Status = Vein360ContainerStatus.Assigned, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 13, ContainerTypeId = 1, ContainerCode = "CNT100013", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 14, ContainerTypeId = 2, ContainerCode = "CNT100014", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 15, ContainerTypeId = 3, ContainerCode = "CNT100015", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) },
                new Vein360Container { Id = 16, ContainerTypeId = 2, ContainerCode = "CNT100016", Status = Vein360ContainerStatus.Available, CreatedDate = new DateTime(2025, 4, 16) });


            modelBuilder.Entity<DonationContainer>().HasData(
                new DonationContainer { Id = 1, ContainerTypeId = 1, ClinicId = 1, RequestedUnits = 10, Status = DonationContainerStatus.Requested, ReplenishmentOrderId = 1001, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 2, ContainerTypeId = 2, ClinicId = 1, RequestedUnits = 9, ApprovedUnits = 9, Status = DonationContainerStatus.Approved, ReplenishmentOrderId = 1002, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 3, ContainerTypeId = 3, ClinicId = 1, RequestedUnits = 8, ApprovedUnits = 8, Status = DonationContainerStatus.Approved, ReplenishmentOrderId = 1003, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 4, ContainerTypeId = 2, ClinicId = 1, RequestedUnits = 7, ApprovedUnits = 7, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1004, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 5, ContainerTypeId = 1, ClinicId = 1, RequestedUnits = 6, ApprovedUnits = 6, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1005, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 6, ContainerTypeId = 2, ClinicId = 1, RequestedUnits = 5, ApprovedUnits = 5, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1006, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 7, ContainerTypeId = 3, ClinicId = 2, RequestedUnits = 4, ApprovedUnits = 4, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1007, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 8, ContainerTypeId = 2, ClinicId = 2, RequestedUnits = 3, ApprovedUnits = 3, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1008, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 9, ContainerTypeId = 1, ClinicId = 2, RequestedUnits = 4, ApprovedUnits = 4, Status = DonationContainerStatus.Shipped, ReplenishmentOrderId = 1009, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 10, ContainerTypeId = 2, ClinicId = 2, RequestedUnits = 5, ApprovedUnits = 5, Status = DonationContainerStatus.Approved, ReplenishmentOrderId = 1010, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 11, ContainerTypeId = 3, ClinicId = 2, RequestedUnits = 6, ApprovedUnits = 6, Status = DonationContainerStatus.Approved, ReplenishmentOrderId = 1011, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
                new DonationContainer { Id = 12, ContainerTypeId = 1, ClinicId = 2, RequestedUnits = 7, ApprovedUnits = 7, Status = DonationContainerStatus.Approved, ReplenishmentOrderId = 1012, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) });

            modelBuilder.Entity<Donation>().HasData(
                new Donation { Id = 1, ClinicId = 1, PackageType = PackageType.Vein360Container, ContainerTypeId = 1, TrackingNumber = 1234567890, LabelFileName = "label.pdf", Status = DonationStatus.Donated, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16), Products = [] },
                new Donation { Id = 2, ClinicId = 1, PackageType = PackageType.Vein360Container, ContainerTypeId = 2, TrackingNumber = 1234567891, LabelFileName = "label.pdf", Status = DonationStatus.Donated, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16), Products = [] },
                new Donation { Id = 3, ClinicId = 1, PackageType = PackageType.Vein360Container, ContainerTypeId = 3, TrackingNumber = 1234567892, LabelFileName = "label.pdf", Status = DonationStatus.Processed, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16), Products = [] },
                new Donation { Id = 4, ClinicId = 2, PackageType = PackageType.Vein360Container, ContainerTypeId = 1, TrackingNumber = 1234567893, LabelFileName = "label.pdf", Status = DonationStatus.Paid, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16), Products = [] },
                new Donation { Id = 5, ClinicId = 2, PackageType = PackageType.Vein360Container, ContainerTypeId = 2, TrackingNumber = 1234567894, LabelFileName = "label.pdf", Status = DonationStatus.Donated, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16), Products = [] });

            modelBuilder.Entity<DonationProduct>().HasData(
                new DonationProduct { Id = 1, DonationId = 1, ProductId = 1, Units = 1 }, new DonationProduct { Id = 2, DonationId = 1, ProductId = 2, Units = 1 }, new DonationProduct { Id = 3, DonationId = 1, ProductId = 3, Units = 1 },
                new DonationProduct { Id = 4, DonationId = 2, ProductId = 1, Units = 1 }, new DonationProduct { Id = 5, DonationId = 2, ProductId = 3, Units = 1 }, new DonationProduct { Id = 6, DonationId = 2, ProductId = 5, Units = 1 },
                new DonationProduct { Id = 7, DonationId = 3, ProductId = 1, Units = 1 }, new DonationProduct { Id = 8, DonationId = 3, ProductId = 4, Units = 1 }, new DonationProduct { Id = 9, DonationId = 3, ProductId = 5, Units = 1 },
                new DonationProduct { Id = 10, DonationId = 4, ProductId = 1, Units = 1 }, new DonationProduct { Id = 11, DonationId = 4, ProductId = 5, Units = 1 }, new DonationProduct { Id = 12, DonationId = 4, ProductId = 2, Units = 1 },
                new DonationProduct { Id = 13, DonationId = 5, ProductId = 1, Units = 1 }, new DonationProduct { Id = 14, DonationId = 5, ProductId = 2, Units = 1 }, new DonationProduct { Id = 15, DonationId = 5, ProductId = 4, Units = 1 });

            modelBuilder.Entity<Vein360User>().HasData(
                new Vein360User() { Id = 1, Name = "Chanchal Kumar", Username = "chanchalagnihotri1987@gmail.com", Password = "AQAAAAIAAYagAAAAEAws2AnjTEGbr+kBOKLA6qybchEzxQaAyJcdMDkIdeT3lopkhRdv4RYFKiIdaVid3g==", CreatedDate = new DateTime(2025, 4, 16), IsAdmin = true, IsDonor = true });

            modelBuilder.Entity<Clinic>().HasData(
                new Clinic() { Id = 1, ClinicName = "ABC Clinic", PrimaryContactPhone = "9876543210", AddressLine1 = "CLINIC STREET LINE 1", City = "HARRISON", State = "AR", Country = "US", PostalCode = "72601", UserId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new Clinic() { Id = 2, ClinicName = "XYZ Clinic", PrimaryContactPhone = "9876543210", AddressLine1 = "CLINIC STREET LINE 1", City = "HARRISON", State = "AR", Country = "US", PostalCode = "72601", UserId = 1, CreatedDate = new DateTime(2025, 4, 16) });

            modelBuilder.Entity<ShippingLabel>().HasData(
                new ShippingLabel { Id = 1, TrackingNumber = 9876543211, ClinicId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 2, TrackingNumber = 9876543212, ClinicId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 3, TrackingNumber = 9876543213, ClinicId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 4, TrackingNumber = 9876543214, ClinicId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 5, TrackingNumber = 9876543215, ClinicId = 1, CreatedDate = new DateTime(2025, 4, 16) },

                new ShippingLabel { Id = 6, TrackingNumber = 9876543216, ClinicId = 2, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 7, TrackingNumber = 9876543217, ClinicId = 2, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 8, TrackingNumber = 9876543218, ClinicId = 2, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 9, TrackingNumber = 9876543219, ClinicId = 2, CreatedDate = new DateTime(2025, 4, 16) },
                new ShippingLabel { Id = 10, TrackingNumber = 9876543220, ClinicId = 2, CreatedDate = new DateTime(2025, 4, 16) });
        }
    }
}
