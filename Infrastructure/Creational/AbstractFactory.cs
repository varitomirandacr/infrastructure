using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Creational
{
    public interface IAbstractFactory
    {
        IAbstractA CreateA();
        IAbstractB CreateB();
    }

    public interface IAbstractA { }
    public interface IAbstractB { }

    public class ProductA1 : IAbstractA { }
    public class ProductA2 : IAbstractA { }

    public class ProductB1 : IAbstractB { }
    public class ProductB2 : IAbstractB { }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IAbstractA CreateA()
        {
            return new ProductA1(); 
        }

        public IAbstractB CreateB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IAbstractA CreateA()
        {
            return new ProductA2();
        }

        public IAbstractB CreateB()
        {
            return new ProductB2();
        }
    }
}
