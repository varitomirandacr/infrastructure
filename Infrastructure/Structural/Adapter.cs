using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Structural.Adapter
{
    public interface ITarget
    {
        string ExecuteRequest();
    }

    public class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public string ExecuteRequest()
        {
           return $"... Status: {this.adaptee.ExecuteSpecific()}";
        }
    }

    public class Adaptee
    {
        public string ExecuteSpecific()
        {
            return "Executing one";
        }
    }
}
