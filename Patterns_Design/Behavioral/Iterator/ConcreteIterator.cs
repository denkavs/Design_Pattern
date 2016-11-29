using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Iterator
{
    class ConcreteIterator:Iterator
    {
        private ConcreteAggregate aggregate;
        private int index;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public object First()
        {
            if (this.aggregate.Count == 0)
            {
                this.index = -1;
                return null;
            }
            else
            {
                this.index = 0;
                return this.aggregate[0];
            }
        }

        public object Next()
        {
            if (++index < this.aggregate.Count)
            {
                return this.aggregate[index];
            }
            else
            {
                return null;
            }
        }

        public bool IsDone()
        {
            return this.aggregate.Count <= this.index;
        }

        public object CurrentItem()
        {
            return this.aggregate[index];
        }
    }
}
