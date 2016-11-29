namespace Patterns_Design.Behavioral.ChainOfResponsibility
{
    using System;

    /// <summary>
    /// The button chain.
    /// </summary>
    public class ButtonChain : Handler
    {
        public ButtonChain(Handler parent) : base(parent)
        {
            
        }

        public override void HandleRequest(IRequest param)
        {
            Request1 rq1 = param as Request1;
            if (rq1 != null)
            {
                Console.WriteLine("Processing Request in ButtonChain with parameters [{0}]", rq1.Value);    
            }

            if (successor != null)
            {
                successor.HandleRequest(param);
            }
        }
    }
}
