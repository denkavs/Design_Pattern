using System;

namespace Patterns_Design.Behavioral.Strategy
{
    public class ConcreteStrategy : IStrategy
    {
        public void StrategyOperation1()
        {
            Console.WriteLine("Strategy operation 1 [concrete strategy]");
        }

        public void StrategyOperation2(string data)
        {
            Console.WriteLine("Strategy operation 1 - with data {0} [concrete strategy]", data);
        }
    }
}