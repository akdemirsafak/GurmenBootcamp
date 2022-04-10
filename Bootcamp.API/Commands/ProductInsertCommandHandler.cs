using Bootcamp.API.DTOs;
using Bootcamp.API.Events;
using Bootcamp.API.Models;
using Bootcamp.API.Repositories;
using MediatR;

namespace Bootcamp.API.Commands
{
    public class ProductInsertCommandHandler : IRequestHandler<ProductInsertCommand, ResponseDto<NoContent>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator mediator;

        public ProductInsertCommandHandler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            this.mediator = mediator;
        }

        public Task<ResponseDto<NoContent>> Handle(ProductInsertCommand request, CancellationToken cancellationToken)
        {
            //_productRepository.Save(new Product() { Id = 20, Name = request.Name, Price = request.Price, Stock = request.Stock });

            //mediator.Publish(new ProductCreatedEvent() { ProductId = 20, ProductName = request.Name });
            return Task.FromResult(ResponseDto<NoContent>.Success(201));
        }
    }
}
