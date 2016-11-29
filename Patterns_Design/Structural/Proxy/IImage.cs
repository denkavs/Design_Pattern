using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns_Design.Structural.Proxy
{
    interface IImage
    {
        Size GetSize();

        /// <summary>
        /// The draw.
        /// </summary>
        void Draw();

    }
}
