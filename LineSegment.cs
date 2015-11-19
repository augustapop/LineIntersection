using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersection
{
    class LineSegment
    {
        public Point EndPoint1 { get; private set; }
        public Point EndPoint2 { get; private set; }

        public int LeftMostX
        {
            get { return EndPoint1.X <= EndPoint2.X ? EndPoint1.X : EndPoint2.X; }
        }

        public int RightMostX
        {
            get { return EndPoint1.X >= EndPoint2.X ? EndPoint1.X : EndPoint2.X; }
        }

        public LineSegment(Point endPoint1, Point endPoint2)
        {
            EndPoint1 = endPoint1;
            EndPoint2 = endPoint2;
        }

        public override string ToString()
        {
            return string.Format("({0},{1}) - ({2},{3})", EndPoint1.X, EndPoint1.Y, EndPoint2.X, EndPoint2.Y);
        }
    }
}
