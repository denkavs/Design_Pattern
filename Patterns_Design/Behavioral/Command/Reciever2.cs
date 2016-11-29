using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Command
{
    public class Receiver2
    {
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Receiver1"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Receiver2(string name)
        {
            this.Name = name;
        }

        public void Action()
        {
            Console.WriteLine("****** Execute action inside receiver 2 - [{0}] ******", this.Name);
        }
    }
}
