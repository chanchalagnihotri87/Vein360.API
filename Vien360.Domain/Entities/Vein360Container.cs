namespace Vein360.Domain.Entities
{
    public class Vein360Container : BaseEntity
    {
        public int ContainerTypeId { get; set; }
        public Vein360ContainerStatus Status { get; set; }
        public string ContainerCode { get; set; }
        public Vein360ContainerType ContainerType { get; set; }

        public void MarkAsAssigned()
        {
            Status = Vein360ContainerStatus.Assigned;
        }

        public void MarkAsAvailable()
        {
            Status = Vein360ContainerStatus.Available;
        }

    }
}
