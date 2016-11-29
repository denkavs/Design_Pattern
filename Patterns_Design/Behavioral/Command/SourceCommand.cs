using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Command
{
    public class SourceCommand
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        public ICommand<Object> Command { get; set; }

        /// <summary>
        /// The invoke command.
        /// </summary>
        public void InvokeCommand()
        {
            if (this.Command != null)
            {
                this.Command.Execute(null);
            }
        }
    }
}
