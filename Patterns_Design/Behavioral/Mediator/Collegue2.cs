using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Mediator
{
    public class Collegue2
    {
        public void Inform(int res)
        {
            Console.WriteLine("Inform collegue 2 - {0}", res);
        }

        public int Processign()
        {
            Console.WriteLine("Processing collegue 2");
            return (new Random()).Next(100);
        }
    }
}
