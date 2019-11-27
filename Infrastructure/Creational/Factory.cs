using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Creational.Factory
{    
    public interface IFactory
    {
        void Do(string text);
    }

    public class ChildOne : IFactory
    {
        // Implemented IFactory
        public void Do(string text)
        {
            Console.WriteLine($"Child one: {text}");
        }
    }

    public class ChildTwo : IFactory
    {
        // Implemented IFactory
        public void Do(string text)
        {
            Console.WriteLine($"Child two: {text}");
        }
    }

    public abstract class ChildFactory
    {
        public abstract IFactory GetChild(string name);
    }

    public class ConcreteChildFactory : ChildFactory
    {
        public override IFactory GetChild(string name)
        {
            switch (name)
            {
                case "one":
                    return new ChildOne();
                case "two":
                    return new ChildTwo();
                default:
                    throw new ApplicationException("Invalid child");
            }
        }
    }
}
