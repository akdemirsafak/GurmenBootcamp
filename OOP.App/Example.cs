using OOP.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.App;

//public class Helper

//{
//    public string Write(string FirstName, string LastName)
//    {
//        return FirstName + "" + LastName;
//    }
//}



public abstract class Base
{
    internal int KDV = 18;
    private string FirstName { get; set; }
    private string LastName { get; set; }
    public int Age { get; set; }

    private string Write()
    {
        return FirstName + "" + LastName;
    }

    public void ShowKDV()
    {
        Console.WriteLine($"KDV :{KDV}");
    }
}

public class Manager : Base
{
    public int Grade { get; set; }
}

public class Employee : Base
{
    public decimal Salary { get; set; }
}

public class SuperManager : Manager
{
    public SuperManager()
    {
        // Bridge DP
    }

    public void SetKDV(int kdv)
    {
        KDV = kdv;
    }
}

public class UltraManager : SuperManager
{
}

internal class Example
{
    public int Price { get; set; }  // Field
    public int Id { get; set; } // Property
    public string Name { get; set; }

    private int Calculate(int a, int b)
    {
        return a + b;
    }

    public int Calculate2()
    {
        return Calculate(2, 5);
    }
}