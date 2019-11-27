using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Infrastructure.Creational.Prototype
{
    public interface IPrototype
    {
        IPrototype DeepClone();
        IPrototype ShallowCopy();
        string GetDetails();
    }

    [Serializable]
    public abstract class ParentBase : IPrototype
    {
        public string Name { get; set; }

        public IPrototype ShallowCopy()
        {
            // Shallow Copy of current object
            // Only top-level objects are duplicated
            return (IPrototype)MemberwiseClone();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Use simple 'using' statement", Justification = "<Pending>")]
        public IPrototype DeepClone()
        {
            using (var ms = new MemoryStream())
            {
                if (!typeof(IPrototype).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", "source");
                }

                // Don't serialize a null object, simply return the default for that object
                if (this is null)
                {
                    return default;
                }

                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new MemoryStream())
                {
                    formatter.Serialize(stream, this);
                    stream.Seek(0, SeekOrigin.Begin);
                    return (IPrototype)formatter.Deserialize(stream);
                }
            }
        }

        public virtual string GetDetails()
        {
            return $"Current name is {Name}";
        }
    }

    public class Child : ParentBase
    {
        public int Id { get; set; }

        public override string GetDetails()
        {
            return $"ID: {Id} \n {base.GetDetails()}";
        }
    }
}
