using Bootcamp.API.Controllers;
using Bootcamp.API.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Models
{
    public class ProductService
    {

        private readonly IProductRepository _respository;

        public ProductService(IProductRepository productRepository)
        {
            _respository = productRepository;
        }

        public IActionResult GetAll() => new OkObjectResult(_respository.GetAll());





        public ResponseDto<ProductDto> GetById(int id)
        {
            var hasProduct = _respository.GetById(id);



            return ResponseDto<ProductDto>.Success(new ProductDto(hasProduct), 200);

        }

        public IActionResult Save(Product newProduct)
        {




            _respository.Save(newProduct);
            return new CreatedAtActionResult(nameof(ProductsController.GetProducts), "Products", new { id = newProduct.Id }, newProduct);

        }


        public ResponseDto<NoContent> Update(Product updateProduct)
        {

            var hasProduct = _respository.GetById(updateProduct.Id);




            _respository.Update(updateProduct);
            return ResponseDto<NoContent>.Success(204);

        }
        public IActionResult Delete(int id)
        {
            var hasProduct = _respository.GetById(id);



            _respository.Delete(id);

            return new NoContentResult();



        }

    }
}
