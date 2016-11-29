using System;

namespace Patterns_Design.Behavioral.Command
{
    public class Receiver1
    {
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Receiver1"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public Receiver1(string name)
        {
            this.Name = name;
        }

        public void Action()
        {
            Console.WriteLine("Execute action inside receiver 1 - [{0}]", this.Name);
        }
    }
}