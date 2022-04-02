using Bootcamp.API.DTOs;
using Bootcamp.API.Filters;
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


        [CustomExceptionFilter]
        public IActionResult GetProducts([FromServices] ProductService service)
        {

            throw new Exception("veri tabanına bağlanma problemi");
            return service.GetAll();
        }


        [HttpGet("[action]/{page:int}/{pageSize:int}")]
        public IActionResult GetProductsWithPage(int page, int pageSize)
        {

            return Ok();
        }
        [HttpGet("/api/[controller]/[action]/{id:int}")]
        public IActionResult AnyProduct(int id)
        {
            throw new Exception("hata var");
            return Ok();
        }




        [ServiceFilter(typeof(NotFoundProductFilter))]
        //api/products/10
        [HttpGet("{id:int}")]

        public IActionResult GetProducts(int id)
        {




            //gerçek iş

            var result = _productService.GetById(id);

            var resultObject = new ObjectResult(result) { StatusCode = result.StatusCode };

            return resultObject;
        }



        [HttpPost]
        public IActionResult SaveProduct(ProductRequestDto newProduct)
        {
            return _productService.Save(new Product() { Name = newProduct.Name, Price = newProduct.Price, Stock = newProduct.Stock });

            //1.yol
            // return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);

            //2.yol
            //return Created($"api/products/{newProduct.Id}", newProduct);

        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product updateProduct)
        {
            var result = _productService.Update(updateProduct);


            if (result.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = result.StatusCode };
            }
            else
            {
                return new ObjectResult(result) { StatusCode = result.StatusCode };
            }

        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return _productService.Delete(id);
        }


    }
}
