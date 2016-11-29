using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Command
{
    internal class PasteCommand : ICommand<Object>
    {
        private Receiver2 receiver2;

        public PasteCommand(Receiver2 rc2)
        {
            receiver2 = rc2;
        }

        public void Execute(object param)
        {
            receiver2.Action();
        }
    }
}

