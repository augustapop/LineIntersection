using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersection
{
    class LineIntersectionChecker
    {
        public bool DoIntersect(LineSegment lineSegment1, LineSegment lineSegment2)
        {
            // Find the four orientations needed for general and special cases
            int o1 = DetermineOrientation(lineSegment1.EndPoint1, lineSegment1.EndPoint2, lineSegment2.EndPoint1);
            int o2 = DetermineOrientation(lineSegment1.EndPoint1, lineSegment1.EndPoint2, lineSegment2.EndPoint2);
            int o3 = DetermineOrientation(lineSegment2.EndPoint1, lineSegment2.EndPoint2, lineSegment1.EndPoint1);
            int o4 = DetermineOrientation(lineSegment2.EndPoint1, lineSegment2.EndPoint2, lineSegment1.EndPoint2);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are colinear and p2 lies on segment p1q1
            if (o1 == 0 && IsOnSegment(lineSegment1.EndPoint1, lineSegment2.EndPoint1, lineSegment1.EndPoint2)) return true;

            // p1, q1 and p2 are colinear and q2 lies on segment p1q1
            if (o2 == 0 && IsOnSegment(lineSegment1.EndPoint1, lineSegment2.EndPoint2, lineSegment1.EndPoint2)) return true;

            // p2, q2 and p1 are colinear and p1 lies on segment p2q2
            if (o3 == 0 && IsOnSegment(lineSegment2.EndPoint1, lineSegment1.EndPoint1, lineSegment2.EndPoint2)) return true;

            // p2, q2 and q1 are colinear and q1 lies on segment p2q2
            if (o4 == 0 && IsOnSegment(lineSegment2.EndPoint1, lineSegment1.EndPoint2, lineSegment2.EndPoint2)) return true;

            return false; // Doesn't fall in any of the above cases
        }

        /// <summary>
        ///  Given three colinear points p, q, r, the function checks if point q lies on line segment 'pr'
        /// </summary>
        /// <returns></returns>
        private bool IsOnSegment(Point p, Point q, Point r)
        {
            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
               return true;
 
            return false;
        }

        /// <summary>
        ///  To find orientation of ordered triplet (p, q, r).
        /// The function returns following values
        /// 0 --> p, q and r are colinear
        /// 1 --> Clockwise
        /// 2 --> Counterclockwise
        /// </summary>
        private int DetermineOrientation(Point p, Point q, Point r)
        {
            int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);
 
            if (val == 0) return 0;  // colinear
 
             return (val > 0)? 1: 2; // clock or counterclock wise
        }
    }
}

