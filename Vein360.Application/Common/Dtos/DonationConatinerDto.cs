namespace Vein360.Application.Common.Dtos
{
    public class DonationConatinerDto
    {
        public int Id { get; set; }
        public int ContainerTypeId { get; set; }
        public int ClinicId { get; set; }
        public int RequestedUnits { get; set; }
        public int? ApprovedUnits { get; set; }
        public int DonorId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DonationContainerStatus Status { get; set; }
        public required Vein360ContainerTypeDto ContainerType { get; set; }
        public Vein360ContainerDto? Container { get; set; }
        public UserDto? Donor { get; set; }
        public ClinicDto? Clinic { get; set; }



    }
}
