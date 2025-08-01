using Vein360.Domain.Entities;

namespace Vein360.Application.Repository.ProductRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<ICollection<Product>> GetSaleProductsAsNoTrackingAsync();
        Task<ICollection<Product>> GetSortProductsAsNoTrackingAsync();
    }
    
}
