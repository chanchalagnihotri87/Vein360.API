namespace Vein360.Application.Common.Dtos
{
    public class DonationConatinerDto
    {
        public int Id { get; set; }
        public int ContainerTypeId { get; set; }
        public int? ContainerId { get; set; }
        public long? TrackingNumber { get; set; }
        public string? LabelFileName { get; set; }
        public int DonorId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DonationContainerStatus Status { get; set; }
        public required Vein360ContainerTypeDto ContainerType { get; set; }
        public Vein360ContainerDto? Container { get; set; }
        public UserDto? Donor { get; set; }



    }
}
