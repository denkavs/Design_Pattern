using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Iterator
{
    class ConcreteAggregate : Aggregate
    {
        private ArrayList items = new ArrayList();

        public Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        // Gets item count
        public int Count
        {
            get { return this.items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return this.items[index]; }
            set { this.items.Insert(index, value); }
        }
    }
}
