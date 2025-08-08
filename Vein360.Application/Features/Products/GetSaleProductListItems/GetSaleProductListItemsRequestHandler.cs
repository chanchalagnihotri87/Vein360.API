using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Application.Features.Products.GetSaleProductListItems
{
    public class GetAllProductListItemsRequestHandler : IRequestHandler<GetAllProductListItemsRequest, ICollection<ListItemDto>>
    {
        private readonly IProductRepository _productRepo;
        public GetAllProductListItemsRequestHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<ICollection<ListItemDto>> Handle(GetAllProductListItemsRequest request, CancellationToken cancellationToken)
        {

            return _productRepo.GetManyAsNoTracking(x => x.Trade == TradeType.Sale,
                                                         x => new ListItemDto { Id = x.Id, Name = x.Name + " [" + x.Vein360ProductId + "]" },
                                                         cancellationToken);
        }
    }

}
