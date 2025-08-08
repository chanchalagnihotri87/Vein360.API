using Vein360.Application.Common.Dtos;
using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Persistence.Repository.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Vein360Context context) : base(context)
        {
        }

        public Task<ICollection<Product>> GetSaleProductsAsNoTrackingAsync()
        {
            return GetManyAsNoTrackingAsync(x => x.Trade == TradeType.Sale);
        }

        public Task<ICollection<Product>> GetSortProductsAsNoTrackingAsync(List<int> ids)
        {
            return GetManyAsNoTrackingAsync(x => ids.Contains(x.Id) &&  x.Trade == TradeType.Sort);
        }
    }
}
