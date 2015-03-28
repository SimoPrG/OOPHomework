using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // Define new class Rectangle that implements the virtual method and returns the surface of the figure
    // (height * width).
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
