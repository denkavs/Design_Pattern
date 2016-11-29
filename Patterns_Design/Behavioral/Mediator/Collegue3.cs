using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Mediator
{
    public class Collegue3
    {
        public void Inform(int res)
        {
            Console.WriteLine("Inform collegue 3 - {0}", res);
        }

        public int Processign()
        {
            Console.WriteLine("Processing collegue 3");
            return (new Random()).Next(50);
        }
    }
}
