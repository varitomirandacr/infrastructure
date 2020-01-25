using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Structural.Composite
{
    public class Composite<T> where T : IChild
    {
        public List<T> Elements { get; set; }

        public Composite()
        {
            Elements = new List<T>();
        }

        public void Add(T item)
        {
            Elements.Add(item);
        }

        public void Remove(T item)
        {
            Elements.Remove(item);
        }

        public void Display()
        {
            foreach (var item in Elements)
            {
                // item.Display(indent + 2);
                Console.WriteLine(item);
            }
        }
    }

    public interface IChild { }
    public class ChildOne : IChild { }
    public class ChildTwo : IChild { }
    public class ChildThree : IChild { }

}
