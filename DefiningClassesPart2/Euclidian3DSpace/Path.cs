/*Problem 4. Path

    Create a class Path to hold a sequence of points in the 3D space.
    Create a static class PathStorage with static methods to save and load paths from a text file.
    Use a file format of your choice.
*/

namespace Euclidian3DSpace
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Path : IEnumerable
    {
        private List<Point3D> points;

        public Path(params Point3D[] points)
        {
            this.points = new List<Point3D>();

            foreach (Point3D point in points)
            {
                this.points.Add(point);
            }
        }

        public int PointsCount
        {
            get { return this.points.Count; }
        }

        public Point3D this[int index]
        {
            get { return this.points[index]; }
            set { this.points[index] = value; }
        }

        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Point3D point in this.points)
            {
                builder.AppendLine(point.ToString());
            }

            return builder.ToString();
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this.points);
        }

        // Private enumerator class.
        private class MyEnumerator : IEnumerator
        {
            private List<Point3D> points;
            private int position = -1;

            // Constructor.
            public MyEnumerator(List<Point3D> list)
            {
                this.points = list;
            }

            // IEnumerator
            public object Current
            {
                get
                {
                    try
                    {
                        return this.points[this.position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            // IEnumerator
            public bool MoveNext()
            {
                this.position++;
                return this.position < this.points.Count;
            }

            // IEnumerator
            public void Reset()
            {
                this.position = -1;
            }

            private IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
        }  // End nested class.
    }
}
