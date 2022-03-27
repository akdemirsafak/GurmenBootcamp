using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasAIsA.Bad;



public abstract class BaseVehicle
{
    public abstract void Right();

    public abstract void Left();

    public abstract void Backward();
    public void Forward()
    {


    }

}


public interface IVehicle
{



    void Backward();
    void Forward()
    {


    }
}


public interface IRightOrLeft
{
    void Right();
    void Left();

}


public class Car2 : BaseVehicle
{
    public override void Backward()
    {
        throw new NotImplementedException();
    }

    public override void Left()
    {
        throw new NotImplementedException();
    }

    public override void Right()
    {
        throw new NotImplementedException();
    }
}




public class Car : IVehicle
{
    public void Backward()
    {


        Console.WriteLine("Geriye gitme Method1");
        Console.WriteLine("Geriye gitme Method2");
        Console.WriteLine("Geriye gitme Method3");
    }



    public void Left()
    {
        throw new NotImplementedException();
    }

    public void Right()
    {
        throw new NotImplementedException();
    }
}

public class MiniCar : IVehicle
{
    public void Backward()
    {
        Console.WriteLine("Geriye gitme");
    }

    public void Left()
    {
        throw new NotImplementedException();
    }

    public void Right()
    {
        throw new NotImplementedException();
    }
}

public class SuperCar : IVehicle, IRightOrLeft
{
    public void Backward()
    {
        throw new NotImplementedException();
    }

    public void Left()
    {
        throw new NotImplementedException();
    }

    public void Right()
    {
        throw new NotImplementedException();
    }
}





public class Train : IVehicle
{
    public void Backward()
    {
        throw new NotImplementedException();
    }

    public void Forward()
    {
        throw new NotImplementedException();
    }


}
