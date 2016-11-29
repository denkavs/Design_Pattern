namespace Patterns_Design.Behavioral.Interpreter
{
    public class VariableExp:BooleanExp
    {
        private string name;
        public VariableExp(string name)
        {
            this.name = name;
        }

        public bool Evaluate(BooleanContext context)
        {
            return context.Lookup(this.name);
        }

        public BooleanExp Copy()
        {
            return new VariableExp(this.name);
        }
    }
}