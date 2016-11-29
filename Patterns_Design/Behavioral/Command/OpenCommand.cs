using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Patterns_Design.Behavioral.Command
{
    /// <summary>
    /// The open command.
    /// </summary>
    class OpenCommand : ICommand<Object>
    {
        /// <summary>
        /// The receiver 1.
        /// </summary>
        private Receiver1 receiver1;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCommand"/> class.
        /// </summary>
        /// <param name="receiver1">
        /// The receiver 1.
        /// </param>
        public OpenCommand(Receiver1 receiver1)
        {
            this.receiver1 = receiver1;
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        public void Execute(object obj)
        {
            this.receiver1.Action();
        }
    }
}
