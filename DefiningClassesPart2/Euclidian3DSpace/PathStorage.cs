/*Problem 4. Path

    Create a class Path to hold a sequence of points in the 3D space.
    Create a static class PathStorage with static methods to save and load paths from a text file.
    Use a file format of your choice.
*/

namespace Euclidian3DSpace
{
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class PathStorage
    {
        public static void SavePathToFile(string fileName, Path path)
        {
            StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8);

            using (writer)
            {
                writer.Write(path);
            }
        }

        public static Path LoadPathFromFile(string fileName)
        {
            string regex = @"X: (?<x>-?\d*\.?\d+([eE][-+]?\d+)?); Y: (?<y>-?\d*\.?\d+([eE][-+]?\d+)?); Z: (?<z>-?\d*\.?\d+([eE][-+]?\d+)?)";
            Path path = new Path();
            StreamReader reader = new StreamReader(fileName, Encoding.UTF8);

            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    Match match = Regex.Match(reader.ReadLine(), regex);
                    double x = double.Parse(match.Groups["x"].Value);
                    double y = double.Parse(match.Groups["y"].Value);
                    double z = double.Parse(match.Groups["z"].Value);
                    Point3D point = new Point3D(x, y, z);
                    path.AddPoint(point);
                }
            }

            return path;
        }
    }
}
