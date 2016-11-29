using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Interpreter
{
    public class NotExp:BooleanExp
    {
        private string value;

        public NotExp(string input)
        {
            this.value = input;
        }

        public bool Evaluate(BooleanContext context)
        {
            return !context.Lookup(this.value);
        }

        public BooleanExp Copy()
        {
            return new NotExp(this.value);
        }
    }
}
