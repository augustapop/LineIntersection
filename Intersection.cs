using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersection
{
    class Intersection
    {
        public LineSegment LineSegment1 { get; private set; }
        public LineSegment LineSegment2 { get; private set; }

        public Intersection(LineSegment lineSegment1, LineSegment lineSegment2)
        {
            LineSegment1 = lineSegment1;
            LineSegment2 = lineSegment2;
        }
    }
}
