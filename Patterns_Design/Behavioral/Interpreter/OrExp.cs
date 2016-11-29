namespace Patterns_Design.Behavioral.Interpreter
{
    public class OrExp : BooleanExp
    {
        private BooleanExp operand1;
        private BooleanExp operand2;

        public OrExp(BooleanExp exp1, BooleanExp exp2)
        {
            this.operand1 = exp1;
            this.operand2 = exp2;
        }

        public bool Evaluate(BooleanContext context)
        {
            return this.operand1.Evaluate(context) || this.operand2.Evaluate(context);
        }

        public BooleanExp Copy()
        {
            return new OrExp(this.operand1.Copy(), this.operand2.Copy());
        }
    }
}