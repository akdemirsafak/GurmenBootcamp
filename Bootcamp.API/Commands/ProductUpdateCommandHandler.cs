using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Commands
{


    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommmand, ResponseDto<NoContent>>
    {

        private readonly IProductRepository _repository;

        public ProductUpdateCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }


        public Task<ResponseDto<NoContent>> Handle(ProductUpdateCommmand request, CancellationToken cancellationToken)
        {

            //var hasProduct = _repository.GetAll().Any(x => x.Id == request.Id);

            //if (!hasProduct)
            //{
            //    return Task.FromResult(ResponseDto<NoContent>.Fail($"Güncellenecek ürün({request.Id}) bulunamamıştır."));
            //}

            //_repository.Update(new Product() { Id = request.Id, Name = request.Name, Price = request.Price, Stock = request.Stock });


            return Task.FromResult(ResponseDto<NoContent>.Success(204));
        }
    }
}
