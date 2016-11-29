using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Mediator
{
    public class ConcreteMediator
    {
        private Collegue1 col1;
        private Collegue2 col2;
        private Collegue3 col3;

        public ConcreteMediator(Collegue1 col1, Collegue2 col2, Collegue3 col3)
        {
            this.col1 = col1;
            this.col2 = col2;
            this.col3 = col3;
        }

        public void Process1AndInform23()
        {
            int res = this.col1.Processign();
            this.col2.Inform(res);
            this.col3.Inform(res);
        }

        public void Process3AndInform1()
        {
            int res = this.col3.Processign();
            this.col1.Inform(res);
        }
    }
}
