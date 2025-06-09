using Microsoft.EntityFrameworkCore;

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
        public DbSet<DonorPreference> DonorPreferences  { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);


            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Vein360 Reprocessed ClosureFast Catheter (VEN-7-60B)", Description = "Description1", Price = 1000, Type = ProductType.ClosureFastCatheter, Image = "ven-7-60b.jpg", CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 2, Name = "Vein360 Complete Procedure Pack - 7F x 7 cm Introducer Kit", Description = "Description2", Price = 1800, Type = ProductType.IntroducerSheath, Image = "introducerkit.jpg", CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 3, Name = "Vein360 7F x 7 cm Introducer Sheath Kit", Description = "Description2", Price = 900, Type = ProductType.IntroducerSheath, Image = "sheathkit.jpg", CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 4, Name = "Vein360 Basic Procedure Pack", Description = "Description2", Price = 2000, Type = ProductType.ProcedurePack, Image = "procedurepack.jpg", CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 5, Name = "Vein360 Reprocessed ClosureFast Catheter (VEN-7-80B)", Description = "Description2", Price = 1200, Type = ProductType.ClosureFastCatheter, Image = "ven-7-80b.jpg", CreatedDate = new DateTime(2025, 4, 16) },
                new Product { Id = 6, Name = "Vein360 Reprocessed ClosureFast Catheter (VEN-7-100B)", Description = "Description2", Price = 1500, Type = ProductType.ClosureFastCatheter, Image = "ven-7-100b.jpg", CreatedDate = new DateTime(2025, 4, 16) }
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
                new DonationContainer { Id = 1, ContainerTypeId = 1, ClinicId = 1, RequestedUnits = 10, Status = DonationContainerStatus.Requested, ReplenishmentOrderId=1001, DonorId = Constants.UserId, CreatedDate = new DateTime(2025, 4, 16) },
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
                new Vein360User() { Id = 1, Name = "Chanchal Kumar", Email = "chanchalagnihotri1987@gmail.com", Password = "chanchal", CreatedDate = new DateTime(2025, 4, 16), IsAdmin = true, IsDonor = true });

            modelBuilder.Entity<Clinic>().HasData(
                new Clinic() { Id = 1, ClinicCode = "Clinic-0001", ClinicName = "ABC Clinic", Phone = "9876543210", StreetLine = "CLINIC STREET LINE 1", City = "HARRISON", State = "AR", Country = "US", PostalCode = "72601", UserId = 1, CreatedDate = new DateTime(2025, 4, 16) },
                new Clinic() { Id = 2, ClinicCode = "Clinic-0002", ClinicName = "XYZ Clinic", Phone = "9876543210", StreetLine = "CLINIC STREET LINE 1", City = "HARRISON", State = "AR", Country = "US", PostalCode = "72601", UserId = 1, CreatedDate = new DateTime(2025, 4, 16) });

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
