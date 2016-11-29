using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Observer
{
    public class ConcreteObserver2 : Observer1
    {
        private int dectimenter = 100;
        public override void Notify()
        {
            dectimenter--;
            Console.WriteLine("Result observer 2 - {0}", dectimenter);
        }
    }
}
