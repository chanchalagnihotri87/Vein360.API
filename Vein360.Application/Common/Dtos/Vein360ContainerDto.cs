namespace Vein360.Application.Common.Dtos
{
  public  class Vein360ContainerDto
    {
        public int ContainerTypeId { get; set; }
        public Vein360ContainerStatus Status { get; set; }
        public string ContainerCode { get; set; }
        public Vein360ContainerTypeDto ContainerType { get; set; }
    }
}
