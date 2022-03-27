using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasAIsA.Good
{

    //public interface IVehicle
    //{
    //    public void Forward()
    //    {
    //        Console.WriteLine("Forward");
    //    }


    //}


    public class NoRightOrLeft : IRightOrLeftBehavior
    {
        public void Left()
        {
            throw new Exception("Sola dönemez");
        }

        public void Right()
        {
            throw new Exception("Sağa dönemez");
        }
    }

    public class NormalBackward : IBackwardBehavior
    {
        public void Back()
        {
            Console.WriteLine("Normal Backward");
        }
    }

    public class NoBackward : IBackwardBehavior
    {
        public void Back()
        {
            Console.WriteLine("Geriye dönemez");
        }
    }


    public class Normal2Backward : IBackwardBehavior
    {
        public void Back()
        {
            Console.WriteLine("Normal2 Backward");
        }
    }

    public class NormalRightOrLeft : IRightOrLeftBehavior
    {
        public void Left()
        {
            Console.WriteLine("Normal Left");
        }

        public void Right()
        {
            Console.WriteLine("Normal Right");
        }
    }



    public interface IRightOrLeftBehavior
    {

        void Right();
        void Left();
    }

    public interface IBackwardBehavior
    {

        void Back();
    }



    public abstract class BaseVehicle
    {
        protected readonly IRightOrLeftBehavior _rightOrLeftBehavior;
        protected IBackwardBehavior _backwardBehavior;
        protected BaseVehicle(IRightOrLeftBehavior rightOrLeftBehavior, IBackwardBehavior backwardBehavior)
        {
            _rightOrLeftBehavior = rightOrLeftBehavior;
            _backwardBehavior = backwardBehavior;
        }

        public void SetBehavior(IBackwardBehavior backwardBehavior)
        {

            _backwardBehavior = backwardBehavior;
        }


        public void Forward()
        {
            Console.WriteLine("Forward");
        }


        public void Back()
        {
            _backwardBehavior.Back();
        }

        public void Right()
        {
            _rightOrLeftBehavior.Right();
        }

        public void Left()
        {
            _rightOrLeftBehavior.Left();
        }

    }


    public class Car1 : BaseVehicle
    {
        public Car1(IRightOrLeftBehavior rightOrLeftBehavior, IBackwardBehavior backwardBehavior) : base(rightOrLeftBehavior, backwardBehavior)
        {
        }
    }

    public class Car2 : BaseVehicle
    {
        public Car2(IRightOrLeftBehavior rightOrLeftBehavior, IBackwardBehavior backwardBehavior) : base(rightOrLeftBehavior, backwardBehavior)
        {
        }
    }


    public class Train : BaseVehicle
    {
        public Train(IRightOrLeftBehavior rightOrLeftBehavior, IBackwardBehavior backwardBehavior) : base(rightOrLeftBehavior, backwardBehavior)
        {
        }
    }








}
