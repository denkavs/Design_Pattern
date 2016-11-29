using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Template_Method
{
    class ConcreteTemplateMethodClass1:TemplateMethodClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("Primitive operation 1 from ConcreteTemplateMethodClass1");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("Primitive operation 2 from ConcreteTemplateMethodClass1");
        }

        protected override void HookOperation()
        {
            Console.WriteLine("ConcreteTemplateMethodClass1 Hook Operation");   
        }
    }
}
