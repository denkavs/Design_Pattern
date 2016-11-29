using System;

namespace Patterns_Design.Creation.AbstractFactory
{
    public class PMButton : IWidgetButton
    {
        public void DrawButton()
        {
            Console.WriteLine("Draw PM Button");
        }

        public void SetLocation()
        {
            Console.WriteLine("Set location for PM Button");
        }
    }
}