using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Mediator
{
    public class Collegue1
    {
        public void Inform(int res)
        {
            Console.WriteLine("Inform collegue 1 - {0}", res);
        }

        public int Processign()
        {
            Console.WriteLine("Processing collegue 1");
            return (new Random()).Next(10);
        }
    }
}
