using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Creation.FactoryMethod_VirtualConstructor
{
    public abstract class Creator
    {
        public void OpenDocument()
        {
            
        }
        public abstract IAMethodDocument CreateDocument();

    }
}
