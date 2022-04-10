using Bootcamp.API.DTOs;
using MediatR;

namespace Bootcamp.API.Commands
{
    public class ProductUpdateCommmand : IRequest<ResponseDto<NoContent>>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
