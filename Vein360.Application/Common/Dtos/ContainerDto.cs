namespace Vein360.Application.Common.Dtos
{
    public class ContainerDto
    {
        public int Id { get; set; }
        public int ContainerTypeId { get; set; }
        public Vein360ContainerStatus Status { get; set; }
        public string ContainerCode { get; set; }
        public ContainerTypeDto ContainerType { get; set; }
    }
}
