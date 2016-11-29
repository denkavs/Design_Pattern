using System;

namespace Patterns_Design.Creation.FactoryMethod_VirtualConstructor
{
    public class ConcreteIaMethodDocument:IAMethodDocument
    {
        public void Open()
        {
            Console.WriteLine("[ConcreteIaMethodDocument] Open document");
        }

        public void Close()
        {
            Console.WriteLine("Close document");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}