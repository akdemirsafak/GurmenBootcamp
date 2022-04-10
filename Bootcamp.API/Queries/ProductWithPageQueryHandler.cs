using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Queries
{
    public class ProductWithPageQueryHandler : IRequestHandler<ProductWithPageQuery, ResponseDto<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;

        public ProductWithPageQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<ResponseDto<List<ProductDto>>> Handle(ProductWithPageQuery request, CancellationToken cancellationToken)
        {

            // page=1 pagesize=5 ilk  5 data    skip(0).Take(pageSize) skip((page-1)*pagesize) => 0
            // page=2 pagesize 5 ikinci 5 data  skip(5).Take(pageSize)  5
            // page=3 pagesize 5 üçüncü 5 data  skip(10).Take(pagesize) 10

            //var products = _productRepository.GetAll().Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);
            //var productDtos = new List<ProductDto>();
            //products.ToList().ForEach(x => productDtos.Add(new ProductDto(x)));
            //return Task.FromResult(ResponseDto<List<ProductDto>>.Success(productDtos, 200));


            return Task.FromResult(ResponseDto<List<ProductDto>>.Success(200));

        }
    }
}
