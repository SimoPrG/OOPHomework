/*Problem 1. Structure

    Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space.
    Implement the ToString() to enable printing a 3D point.
*/
/*Problem 2. Static read-only field

    Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
    Add a static property to return the point O.
*/
/*Problem 3. Static class

    Write a static class with a static method to calculate the distance between two points in the 3D space.
*/
/*Problem 4. Path

    Create a class Path to hold a sequence of points in the 3D space.
    Create a static class PathStorage with static methods to save and load paths from a text file.
    Use a file format of your choice.
*/

namespace Euclidian3DSpace
{
    using System;
    class Euclidian3DSpaceMain
    {
        static void Main()
        {
            Point3D a = new Point3D(-3.65, 4.123, -1.7e-10);
            Console.WriteLine("Point A {0}", a);

            Console.WriteLine("Origin {0}", Point3D.Origin);

            Point3D b = new Point3D(1, 1, 1);
            Console.WriteLine("Point B {0}", b);

            Console.WriteLine("The distance between A and B is {0}", Distance.CalculateDistance(a, b));

            Path path = new Path(Point3D.Origin, a, b, a, b);
            path.AddPoint(Point3D.Origin);
            path.AddPoint(new Point3D(3.23, -123, 0));
            Console.WriteLine("The path is:\n{0}", path);

            PathStorage.SavePathToFile(@"..\..\path.txt", path);

            Path loadedPath = PathStorage.LoadPathFromFile(@"..\..\path.txt");
            Console.WriteLine("The loaded path is:\n{0}", loadedPath);
        }
    }
}
