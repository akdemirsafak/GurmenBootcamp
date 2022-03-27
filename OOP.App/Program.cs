// See https://aka.ms/new-console-template for more information
using OOP.App;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

var pencilProduct = new PencilProduct() { Id = 1, Name = "kalem 1", Price = 100 };

pencilProduct.Write();

var pencil2Product = new Pencil2Product() { Id = 2, Name = "Kurşun kalem", Price = 200 };


pencil2Product.Write();
public abstract class BaseProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public virtual void Write()
    {

        Console.WriteLine($"{Id} {Name} { Price}");
    }

}


public class PencilProduct : BaseProduct
{
    public override void Write()
    {

        Debug.Write($"{Id} {Name} { Price}");
        // base.Write();
    }



}

public class Pencil2Product : BaseProduct
{







}




