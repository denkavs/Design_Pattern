// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StrategyContext.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the StrategyContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Patterns_Design.Behavioral.Strategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StrategyContext
    {
        /// <summary>
        /// The state context.
        /// </summary>
        private string StateContext = "State Context";
        private IStrategy strategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="StrategyContext"/> class.
        /// </summary>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        public StrategyContext(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// The context operation one.
        /// </summary>
        public void ContextOperationOne()
        {
            if (this.strategy != null)
            {
                this.strategy.StrategyOperation1();
            }
            else
            {
                Console.WriteLine("Perform default operation 1 for context");
            }
        }

        /// <summary>
        /// The context operation two.
        /// </summary>
        public void ContextOperationTwo()
        {
            if (this.strategy != null)
            {
                this.strategy.StrategyOperation2(this.StateContext);
            }
            else
            {
                Console.WriteLine("Perform default operation 2 for context");
            }
        }

        /// <summary>
        /// Sets the strategy.
        /// </summary>
        public IStrategy Strategy 
        {   
            set { this.strategy = value; } 
        }
    }
}
