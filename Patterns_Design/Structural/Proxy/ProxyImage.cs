using System;
using System.Drawing;

namespace Patterns_Design.Structural.Proxy
{
    public class ProxyImage : IImage
    {
        /// <summary>
        /// The real image.
        /// </summary>
        private IImage realImage = null;

        /// <summary>
        /// The get size.
        /// </summary>
        /// <returns>
        /// The <see cref="Size"/>.
        /// </returns>
        public Size GetSize()
        {
            Console.WriteLine("Proxy image (RealImage) size is {0} - {1}", 20, 30);
            return new Size(20,30);
        }

        public void Draw()
        {
            if (realImage == null)
            {
                realImage = new RealImage();
            }

            realImage.Draw();
        }
    }
}