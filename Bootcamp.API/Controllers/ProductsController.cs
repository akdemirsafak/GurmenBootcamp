using Bootcamp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]

        public IActionResult GetProducts([FromServices] ProductService service)
        {
            return service.GetAll();
        }




        //api/products/10
        [HttpGet("{isActive:bool}")]

        public IActionResult GetProducts(bool isActive)
        {

            return Ok();
            // return _productService.GetById(id);
        }



        [HttpPost]
        public IActionResult SaveProduct(Product newProduct)
        {
            return _productService.Save(newProduct);

            //1.yol
            // return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);

            //2.yol
            //return Created($"api/products/{newProduct.Id}", newProduct);

        }

        [HttpPut]
        public IActionResult UpdateProduct(Product updateProduct)
        {
            return _productService.Update(updateProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return _productService.Delete(id);
        }


    }
}
