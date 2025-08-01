using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vein360.Application.Features.Products.GetSortProductListItems
{
    public record GetSortProductListItemsRequest : IRequest<ICollection<ListItemDto>>
    {
    }
}
