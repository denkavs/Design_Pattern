using System.Collections.Generic;

namespace Patterns_Design.Behavioral.Interpreter
{
    public class BooleanContext
    {
        Dictionary<string, bool> context;

        public BooleanContext()
        {
            context = new Dictionary<string, bool>();
            context.Add("true", true);
            context.Add("false", false);
        }

        public bool Lookup(string input)
        {
            return context[input];
        }
        public void Assign(string exp, bool value)
        {
            context[exp] = value;
        }
    }
}