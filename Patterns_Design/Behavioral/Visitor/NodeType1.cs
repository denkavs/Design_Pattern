namespace Patterns_Design.Behavioral.Visitor
{
    public class NodeType1 : INode
    {
        public void Accept(NodeVisitor visitor)
        {
            visitor.VisitNoteType1(this);
        }

        public string Name { get; set; }
        public int Balance { get; set; }
    }
}