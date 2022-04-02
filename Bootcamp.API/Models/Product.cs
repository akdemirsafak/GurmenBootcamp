using System.ComponentModel.DataAnnotations;

namespace Bootcamp.API.Models
{

    public class Person
    {

    }
    public class Product
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }


    }
}
