using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.ChainOfResponsibility
{
    public abstract class Handler
    {
        protected Handler successor;
        public Handler(Handler parent)
        {
            successor = parent;
        }

        public virtual void HandleRequest(IRequest param)
        {
            if (successor != null)
            {
                successor.HandleRequest(param);
            }
        }
    }
}
