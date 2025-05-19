namespace Vein360.Domain.Entities
{
    public class Vein360User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDonor { get; set; }
    }
}
