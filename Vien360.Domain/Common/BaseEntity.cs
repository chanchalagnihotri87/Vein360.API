namespace Vein360.Domain.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            
        }
        public int Id { get; set; }
        public DateTimeOffset CreatedDate { get; set; } = DateTime.Now;
        public DateTimeOffset? UpdatedDate { get; set; } = null;
        public DateTimeOffset? DeletedDate { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }
}
