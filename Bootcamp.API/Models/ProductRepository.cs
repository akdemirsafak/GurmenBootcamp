namespace Bootcamp.API.Models
{
    public class ProductRepository : IProductRepository
    {
        Product p2 = new();
        private static List<Product> _products = new List<Product>()
        {
            new (){Id=1, Name="kalem 1", Price=100, Stock=200},
                 new (){Id=2, Name="kalem 2", Price=100, Stock=200},
                      new (){Id=3, Name="kalem 3", Price=100, Stock=200}

        };

        public List<Product> GetAll() => _products;

        public Product GetById(int id) => _products.FirstOrDefault(x => x.Id == id);
        public void Save(Product newProduct) => _products.Add(newProduct);


        public void Update(Product updateProduct)
        {
            //var product = _products.FirstOrDefault(x => x.Id == updateProduct.Id);

            //product.Name = updateProduct.Name;
            //product.Price = updateProduct.Price;
            //product.Stock = updateProduct.Stock;

            var productIndex = _products.FindIndex(x => x.Id == updateProduct.Id);

            _products[productIndex] = updateProduct;

        }
        public void Delete(int id)
        {
            //LinQ

            var product = _products.FirstOrDefault(x => x.Id == id);
            _products.Remove(product);



        }


    }
}
