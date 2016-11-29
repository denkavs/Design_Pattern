using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Behavioral.Memento
{
    class ProspectMemory
    {
        private SalesProspect.Memento _memento;

        // Property
        public SalesProspect.Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }
}
