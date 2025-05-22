using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ProductRepository;

namespace Vein360.Application.Features.Products.DeleteProduct
{
    public class DeleteProductRequestHandler(
        IProductRepository _productRepo,
        IUnitOfWork _unitOfWork) : IRequestHandler<DeleteProductRequest>
    {
        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id, cancellationToken);

            _productRepo.Delete(product);

            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}


