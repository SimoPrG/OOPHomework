using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    // Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    public abstract class Shape
    {
        private double width;

        private double height;

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The value of Width cannot be 0 or negative.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The value of Height cannot be 0 or negative.");
                }

                this.height = value;
            }
        }

        public abstract double CalculateSurface();
    }
}
