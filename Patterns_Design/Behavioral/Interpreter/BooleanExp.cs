namespace Patterns_Design.Behavioral.Interpreter
{
    public interface BooleanExp
    {
        bool Evaluate(BooleanContext context);
        BooleanExp Copy();
    }
}