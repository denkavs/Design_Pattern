using System;
using System.Drawing;

namespace Patterns_Design.Structural.Proxy
{
    public class RealImage:IImage
    {
        public Size GetSize()
        {
            Console.WriteLine("RealImage size is {0} - {1}", 20, 30);
            return new Size(20, 30);
        }

        public void Draw()
        {
            Console.WriteLine("Draw RealImage ....");
        }
    }
}