namespace Patterns_Design.Creation.FactoryMethod_VirtualConstructor
{
    public class ConcreteCreator : Creator
    {
        public override IAMethodDocument CreateDocument()
        {
            return new ConcreteIaMethodDocument();
        }
    }
}