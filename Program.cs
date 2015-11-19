using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersection
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input data
            var lineSegments = new List<LineSegment>()
            {
                new LineSegment(new Point(3, 7), new Point(7,13)),
                new LineSegment(new Point(7, 13), new Point(13,4)),
                new LineSegment(new Point(13, 4), new Point(4,11)),
                new LineSegment(new Point(4, 11), new Point(11,3)),
                new LineSegment(new Point(10,30),new Point(10,45)),
                new LineSegment(new Point(10,60),new Point(10,85)),
                new LineSegment(new Point(10,100),new Point(30,100)),
                new LineSegment(new Point(50,100),new Point(50,70)),
                new LineSegment(new Point(50,50),new Point(0,50)),
           
            };

            var algorithm = new SweepLineAlgorithm();
            var intersections = algorithm.GetAllIntersections(lineSegments);

            foreach (var intersection in intersections)
            {
                Console.WriteLine("Line {0} intersects with {1}", intersection.LineSegment1, intersection.LineSegment2);
            }

            Console.ReadKey();
        }
    }
}
