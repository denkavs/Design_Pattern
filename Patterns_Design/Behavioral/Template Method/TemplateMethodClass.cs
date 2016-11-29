using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Template_Method
{
    public abstract class TemplateMethodClass
    {
        protected virtual void HookOperation()
        {
            Console.WriteLine("Parent Hook Operation");
        }

        public void SimpleOperation()
        {
            Console.WriteLine("Simple operation");
        }

        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            this.HookOperation();
            this.SimpleOperation();
            this.PrimitiveOperation1();
            this.PrimitiveOperation2();

        }
    }
}
