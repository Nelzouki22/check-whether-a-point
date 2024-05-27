using System;

namespace PointInTriangle
{
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Program
    {
        // Function to calculate the area of a triangle given its vertices
        static double TriangleArea(Point A, Point B, Point C)
        {
            return Math.Abs((A.X * (B.Y - C.Y) + B.X * (C.Y - A.Y) + C.X * (A.Y - B.Y)) / 2.0);
        }

        // Function to check if point P lies within the triangle formed by points A, B, and C
        static bool IsPointInTriangle(Point A, Point B, Point C, Point P)
        {
            // Calculate area of the triangle ABC
            double areaABC = TriangleArea(A, B, C);

            // Calculate area of the triangle PAB
            double areaPAB = TriangleArea(P, A, B);

            // Calculate area of the triangle PBC
            double areaPBC = TriangleArea(P, B, C);

            // Calculate area of the triangle PCA
            double areaPCA = TriangleArea(P, C, A);

            // Check if sum of PAB, PBC and PCA is same as ABC
            return (areaABC == areaPAB + areaPBC + areaPCA);
        }

        static void Main(string[] args)
        {
            // Input coordinates of the triangle vertices
            Console.WriteLine("Enter coordinates of point A (x y):");
            var aCoordinates = Console.ReadLine().Split();
            Point A = new Point(double.Parse(aCoordinates[0]), double.Parse(aCoordinates[1]));

            Console.WriteLine("Enter coordinates of point B (x y):");
            var bCoordinates = Console.ReadLine().Split();
            Point B = new Point(double.Parse(bCoordinates[0]), double.Parse(bCoordinates[1]));

            Console.WriteLine("Enter coordinates of point C (x y):");
            var cCoordinates = Console.ReadLine().Split();
            Point C = new Point(double.Parse(cCoordinates[0]), double.Parse(cCoordinates[1]));

            // Input coordinates of point P
            Console.WriteLine("Enter coordinates of point P (x y):");
            var pCoordinates = Console.ReadLine().Split();
            Point P = new Point(double.Parse(pCoordinates[0]), double.Parse(pCoordinates[1]));

            // Check if point P lies within the triangle ABC
            if (IsPointInTriangle(A, B, C, P))
            {
                Console.WriteLine("Point P lies within the triangle.");
            }
            else
            {
                Console.WriteLine("Point P does not lie within the triangle.");
            }
        }
    }
}

