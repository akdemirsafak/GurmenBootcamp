// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("Hello, World!");


IDAL dal = null;

int type = 2;

if (type == 1)
{
    dal = new DALFactory().GetInstance();
}
else
{
    dal = new DALCacheFactory().GetInstance();
}



var bl = new BL(dal);

Console.WriteLine(String.Join(",", bl.Products()));
