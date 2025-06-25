using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Service.StorageService;

namespace Vein360.Application.Features.Products.UpdateProduct
{
    public class UpdateProductRequestHandler(
        IProductRepository _productRepo,
        IUnitOfWork _unitOfWork,
        IStorageService _storageService)
        :
        IRequestHandler<UpdateProductRequest>
    {

        public async Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepo.GetByIdAsync(request.Id, cancellationToken);

            product.Name = request.Name;
            product.Vein360ProductId = request.Vein360ProductId;
            product.Type = request.Type;
            product.Price = request.Price;
            

            if (request.ImageFile != null)
            {
                product.Image = await _storageService.StoreProductImageAsync(request.ImageFile);
            }

            _productRepo.Update(product);


            await _unitOfWork.SaveAsync(cancellationToken);
        }
    }
}
