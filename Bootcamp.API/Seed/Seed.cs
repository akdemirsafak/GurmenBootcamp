using Dapper;
using System.Data;

namespace Bootcamp.API.Seed
{
    public class Seed
    {

        public static async Task Create(IDbConnection connection)
        {
            using (var transaction = connection.BeginTransaction())
            {

                var categoryId = await connection.ExecuteScalarAsync<int>("insert into categories(name) values('telefonlar') returning id");



                var command = "insert into products(name,price,stock,color,categoryid)values(@name,@price,@stock,@color,@categoryid) returning id";

                await connection.ExecuteScalarAsync<int>(command, new { name = "telefon 1", price = 10, stock = 20, color = "Red", categoryid = categoryId });
                await connection.ExecuteScalarAsync<int>(command, new { name = "telefon 1", price = 10, stock = 20, color = "Red", categoryid = categoryId });
                await connection.ExecuteScalarAsync<int>(command, new { name = "telefon 1", price = 10, stock = 20, color = "Red", categoryid = categoryId });


                transaction.Commit();
            }












        }

    }
}
