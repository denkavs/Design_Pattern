using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Observer
{
    public class ConcreteObserver1:Observer1
    {
        private int incrementer = 0;
        public override void Notify()
        {
            incrementer++;
            Console.WriteLine("Result observer 1 - {0}", incrementer);
        }
    }
}
