using Bootcamp.API.Commands;
using Bootcamp.API.DTOs;
using Bootcamp.API.Filters;
using Bootcamp.API.Models;
using Bootcamp.API.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        private readonly IMediator _mediator;
        public ProductsController(ProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }


        [HttpGet]


        [CustomExceptionFilter]
        public IActionResult GetProducts([FromServices] ProductService service)
        {


            return service.GetAll();
        }


        [HttpGet("[action]/{page:int}/{pageSize:int}")]
        public async Task<IActionResult> GetProductsWithPage(int page, int pageSize)
        {

            return Ok(await _mediator.Send(new ProductWithPageQuery() { Page = page, PageSize = pageSize }));
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
        public async Task<IActionResult> SaveProduct(ProductRequestDto newProduct)
        {


            await _mediator.Send(new ProductInsertCommand() { Name = newProduct.Name, Price = newProduct.Price.Value, Stock = newProduct.Stock.Value });

            return Created("", null);
            //1.yol
            // return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);

            //2.yol
            //return Created($"api/products/{newProduct.Id}", newProduct);

        }
        [ServiceFilter(typeof(NotFoundProductFilter))]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product updateProduct)
        {
            var result = await _mediator.Send(new ProductUpdateCommmand() { Id = id, Name = updateProduct.Name, Price = updateProduct.Price.Value, Stock = updateProduct.Stock.Value });


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
