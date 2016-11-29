namespace Patterns_Design.Behavioral.Visitor
{
    interface INode
    {
        void Accept(NodeVisitor visitor);
    }
}