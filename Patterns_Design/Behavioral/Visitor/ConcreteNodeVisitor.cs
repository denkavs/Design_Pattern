using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Visitor
{
    /// <summary>
    /// The concrete node visitor.
    /// </summary>
    class ConcreteNodeVisitor : NodeVisitor
    {
        /// <summary>
        /// The visit note type 1.
        /// </summary>
        /// <param name="type1">
        /// The type 1.
        /// </param>
        public void VisitNoteType1(NodeType1 type1)
        {
            Console.WriteLine("Balance for person {0} is {1}", type1.Balance, type1.Name);
        }

        /// <summary>
        /// The visit note type 2.
        /// </summary>
        /// <param name="type2">
        /// The type 2.
        /// </param>
        public void VisitNoteType2(NodeType2 type2)
        {
            Console.WriteLine("Car brend is - {0}", type2.CarName);
        }
    }
}
