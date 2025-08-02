namespace Vein360.Domain.Entities
{
    public class Vein360User : BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDonor { get; set; }
        public bool IsBuyer { get; set; }
        public bool IsApiUser { get;set; }
        public int Vein360CustomerId { get; set; }
        public bool FirstTimeLogin { get; set; } = true;

        public ICollection<DonorPreference> DonorPreferences { get; set; }
    }
}
