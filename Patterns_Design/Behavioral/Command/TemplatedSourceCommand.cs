using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Command
{
    public class TemplatedSourceCommand<T>
    {
        private ICommand<T> cmd;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplatedSourceCommand{T}"/> class.
        /// </summary>
        /// <param name="cmd">
        /// The cmd.
        /// </param>
        public TemplatedSourceCommand(ICommand<T> cmd)
        {
            this.cmd = cmd;
        }

        public void ActionInvoke(T param)
        {
            if (this.cmd != null)
            {
                this.cmd.Execute(param);
            }
        }

    }
}
