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


        public async Task<ResponseDto<NoContent>> Handle(ProductUpdateCommmand request, CancellationToken cancellationToken)
        {

            var result = await _repository.Update(request);

            if (!result)
            {

                return ResponseDto<NoContent>.Fail("update işlemi başarısız", 500);


            }

            return ResponseDto<NoContent>.Success(204);
        }
    }
}
