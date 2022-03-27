using Bootcamp.API.Controllers;
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





        public IActionResult GetById(int id)
        {
            var hasProduct = _respository.GetById(id);

            if (hasProduct == null) return new NotFoundResult();
            else return new OkObjectResult(hasProduct);



        }
        public IActionResult Save(Product newProduct)
        {



            _respository.Save(newProduct);
            return new CreatedAtActionResult(nameof(ProductsController.GetProducts), "Products", new { id = newProduct.Id }, newProduct);

        }


        public IActionResult Update(Product updateProduct)
        {

            var hasProduct = _respository.GetById(updateProduct.Id);

            if (hasProduct == null) return new NotFoundResult();


            _respository.Update(updateProduct);
            return new NoContentResult();

        }
        public IActionResult Delete(int id)
        {
            var hasProduct = _respository.GetById(id);

            if (hasProduct == null) return new NotFoundResult();

            _respository.Delete(id);

            return new NoContentResult();



        }

    }
}
