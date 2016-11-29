using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Strategy
{
    /// <summary>
    /// The Strategy interface.
    /// </summary>
    public interface IStrategy
    {
        /// <summary>
        /// The strategy operation 1.
        /// </summary>
        void StrategyOperation1();

        /// <summary>
        /// The strategy operation 2.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        void StrategyOperation2(string data);
    }
}
