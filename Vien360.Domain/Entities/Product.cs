namespace Vein360.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Vein360ProductId { get; set; }
        public string Image { get; set; }
        
        public decimal Price { get; set; }
        public ProductType Type { get; set; }
        public TradeType Trade { get; set; }
    }
}
