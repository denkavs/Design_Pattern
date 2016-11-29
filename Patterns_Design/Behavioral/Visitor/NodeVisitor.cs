using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Visitor
{
    /// <summary>
    /// The odeVisitor interface.
    /// </summary>
    public interface NodeVisitor
    {
        /// <summary>
        /// The visit note type 1.
        /// </summary>
        /// <param name="type1">
        /// The type 1.
        /// </param>
        void VisitNoteType1(NodeType1 type1);

        /// <summary>
        /// The visit note type 2.
        /// </summary>
        /// <param name="type2">
        /// The type 2.
        /// </param>
        void VisitNoteType2(NodeType2 type2);
    }
}
