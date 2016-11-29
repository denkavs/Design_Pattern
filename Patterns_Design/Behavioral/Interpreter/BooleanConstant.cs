namespace Patterns_Design.Behavioral.Interpreter
{
    public class BooleanConstant:BooleanExp
    {
        private string value;

        public BooleanConstant(string value)
        {
            this.value = value;
        }

        public bool Evaluate(BooleanContext context)
        {
            return context.Lookup(this.value);
        }

        public BooleanExp Copy()
        {
            return new BooleanConstant(this.value);
        }
    }
}