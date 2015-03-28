/*Problem 1. Shapes

    Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height.
    Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure
    (height * width for rectangle and height * width/2 for triangle).
    Define class Square and suitable constructor so that at initialization height must be kept equal to width and implement
    the CalculateSurface() method.
    Write a program that tests the behaviour of the CalculateSurface() method for different shapes (Square, Rectangle, Triangle)
    stored in an array.
*/

using System;
using System.Collections.Generic;

namespace Shapes
{
    class ShapeTester
    {
        static void Main()
        {
            IEnumerable<Shape> shapes = new List<Shape>(){
                new Triangle(2, 4),
                new Rectangle(2, 4),
                new Square(2)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0} surface: {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
