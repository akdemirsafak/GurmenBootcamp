using Bootcamp.API.Commands;
using Bootcamp.API.Commands.ProductDelete;
using Bootcamp.API.Models;
using Dapper;
using System.Data;

namespace Bootcamp.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<List<Product>> GetAll()
        {
            var query = "select * from products";

            var products = await _connection.QueryAsync<Product>(query);


            return products.ToList();
        }

        public async Task<List<Product>> GetAllWithPage(int page, int pageSize)
        {

            int offset = (page - 1) * pageSize;
            var query = "select * from products order by id desc limit @pagesize offset @offset";

            var products = await _connection.QueryAsync<Product>(query, new { pagesize = pageSize, offset = offset });

            return products.ToList();


        }

        public async Task<List<Product>> GetAllWithPageParameters(int page, int pageSize)
        {

            int offset = (page - 1) * pageSize;
            var query = "select * from products order by id desc limit @pagesize offset @offset";

            var parameters = new DynamicParameters();
            parameters.Add("pagesize", pageSize, DbType.Int32);
            parameters.Add("offset", offset, DbType.Int32);
            var products = await _connection.QueryAsync<Product>(query, parameters);

            return products.ToList();


        }

        public async Task<int> Save(ProductInsertCommand productInsertCommand)
        {




            //

            //(if)
            var command = "insert into products(name,price,stock,color,categoryid)values(@name,@price,@stock,@color,@categoryid) returning id";

            var id = await _connection.ExecuteScalarAsync<int>(command, productInsertCommand.newProduct);


            return id;

        }

        public async Task<bool> Update(ProductUpdateCommmand updateCommmand)
        {



            var command = "update products set name=@name, price=@price,stock=@stock,categoryid=@categoryid where id=@id";
            return await _connection.ExecuteAsync(command, updateCommmand) > 0;
        }



        public async Task<bool> Delete(ProductDeleteCommand productDeleteCommand)
        {
            var command = "delete from products where id=@id";


            return await _connection.ExecuteAsync(command, productDeleteCommand) > 0;
        }

    }
}
