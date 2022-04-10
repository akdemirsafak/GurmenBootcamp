using Bootcamp.API.Models;

namespace Bootcamp.API.DTOs
{
    public class ProductDto
    {




        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }
        public string Color { get; set; }
        public int CategoryId { get; set; }

        public ProductDto()
        {

        }

        public ProductDto(Product product) => (Id, Name, Price, Color, CategoryId) = (product.Id, product.Name, product.Price, product.Color, product.CategoryId);



    }
}
