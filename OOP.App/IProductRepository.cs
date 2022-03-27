using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.App
{
    internal interface IRepository
    {
        void Save();

        List<string> GetAll();




        public string Show()
        {

            return "asp.net mvc";
        }
    }

    public class ProductRepository : IRepository
    {

        public void Public()
        {

        }

        public List<string> GetAll()
        {
            return new List<string>() { "ürün 1", "ürün 2" };
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    public class PersonRepository : IRepository
    {

        public void Public2()
        {

        }

        public List<string> GetAll()
        {
            return new List<string>() { "insan 1", "insan 2" };
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}

public class OCRLibrary
{
    public void Work1() { }
    public void Work2() { }
    public void Work3() { }
    public void Work4() { }

}

public interface IOCRLibrary
{
    void Work1();
}

public class OCRLibraryFacade : IOCRLibrary
{
    public void Work1()
    {
        new OCRLibrary().Work1();
    }
}
