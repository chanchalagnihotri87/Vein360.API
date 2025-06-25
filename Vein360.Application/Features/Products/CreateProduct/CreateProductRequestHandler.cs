using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vein360.Application.Repository;
using Vein360.Application.Repository.ProductRepository;
using Vein360.Application.Service.StorageService;
using Vein360.Domain.Entities;

namespace Vein360.Application.Features.Products.CreateProduct
{
    public class CreateProductRequestHandler(
        IProductRepository _productRepo, 
        IStorageService _storageService,
        IUnitOfWork _unitOfWork) 
        :
        IRequestHandler<CreateProductRequest>
    {

        public async Task Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Vein360ProductId=request.Vein360ProductId,
                Price = request.Price,
                Type = request.Type,
                Image = await _storageService.StoreProductImageAsync(request.ImageFile)
            };


            _productRepo.Create(product);

            await _unitOfWork.SaveAsync(cancellationToken);

        }
    }
}
