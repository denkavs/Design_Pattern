namespace Patterns_Design.Behavioral.Visitor
{
    public class NodeType2 : INode
    {
        /// <summary>
        /// The accept.
        /// </summary>
        /// <param name="visitor">
        /// The visitor.
        /// </param>
        public void Accept(NodeVisitor visitor)
        {
            visitor.VisitNoteType2(this);
        }

        public string CarName { get; set; }
    }
}