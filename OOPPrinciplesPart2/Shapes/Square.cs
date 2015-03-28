using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    //Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement
    //the CalculateSurface() method.
    public class Square : Rectangle
    {
        public Square(double side)
            : base(side, side)
        {
        }

        // Square inherits Rectangle so CalculateSurface() is already implemented.
    }
}
