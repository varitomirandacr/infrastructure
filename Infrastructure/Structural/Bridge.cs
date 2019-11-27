using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Structural.Bridge
{
    public interface IImplementation
    {
        string Operation();
    }

    public class Bridge
    {
        protected IImplementation implementation;

        public Bridge(IImplementation implementation)
        {
            this.implementation = implementation;
        }

        public virtual string Operation()
        {
            return $"Base operation:\n {this.implementation.Operation()}";
        }
    }

    public class ExtendedBridge : Bridge
    {
        public ExtendedBridge(IImplementation implementation)
            : base(implementation)
        {
        }

        public override string Operation()
        {
            return $"Extended operation with:\n {base.implementation.Operation()}";
        }
    }

    public class ConcreteImplementationA : IImplementation
    {
        public string Operation()
        {
            return $"Implementation A";
        }
    }

    public class ConcreteImplementationB : IImplementation
    {
        public string Operation()
        {
            return "Implementation B";
        }
    }
}
