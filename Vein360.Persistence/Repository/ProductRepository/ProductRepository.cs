using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Persistence.Repository.ProductRepository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(Vein360Context context) : base(context)
        {
        }
    }
}
