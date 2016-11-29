using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.ChainOfResponsibility
{
    public class DialogChain : Handler
    {
        public DialogChain(Handler parent)
            : base(parent)
        {

        }

        public override void HandleRequest(IRequest param)
        {
            Request2 rq2 = param as Request2;
            if (rq2 != null)
            {
                Console.WriteLine("Processing Request in DialogChain with parameters [{0}]", rq2.Value);
            }

            if (successor != null)
            {
                successor.HandleRequest(param);
            }
        }
    }
}
