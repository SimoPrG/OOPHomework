/*Problem 3. Static class

    Write a static class with a static method to calculate the distance between two points in the 3D space.
*/

namespace Euclidian3DSpace
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D a, Point3D b)
        {
            double distance = Math.Sqrt(
                ((a.X - b.X) * (a.X - b.X)) +
                ((a.Y - b.Y) * (a.Y - b.Y)) +
                ((a.Z - b.Z) * (a.Z - b.Z)));

            return distance;
        }
    }
}
