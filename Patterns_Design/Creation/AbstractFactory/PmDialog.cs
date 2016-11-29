using System;

namespace Patterns_Design.Creation.AbstractFactory
{
    public class PmDialog : IWidgetDialog
    {
        public void DrawWidget()
        {
            Console.WriteLine("Draw PMDialog");
        }

        public void SetTopMost()
        {
            Console.WriteLine("Set Top Most position for PMDialog");
        }
    }
}