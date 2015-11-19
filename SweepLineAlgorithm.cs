using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSegmentIntersection
{
    class SweepLineAlgorithm
    {
        private Queue<LineSegment> _lineSegmentsQueue = new Queue<LineSegment>();
        private LineIntersectionChecker _intersectionChecker = new LineIntersectionChecker();


        public Intersection GetFirstIntersection(IEnumerable<LineSegment> lineSegments)
        {
            var orderedByLeftMostX = OrderByLeftMostX(lineSegments);
            Intersection firstIntersection = null;

            foreach (var segment in orderedByLeftMostX)
            {
                var intersections = CheckIntersectionsAndAddToQueue(segment);
                if (intersections.Any())
                {
                    firstIntersection = intersections.First();
                    break;
                }
            }

            return firstIntersection;
        }

        public IEnumerable<Intersection> GetAllIntersections(IEnumerable<LineSegment> lineSegments)
        {
            var orderedByLeftMostX = OrderByLeftMostX(lineSegments);

            var intersections = new List<Intersection>();

            foreach (var segment in orderedByLeftMostX)
            {
                intersections.AddRange(CheckIntersectionsAndAddToQueue(segment));
            }

            return intersections;
        }

        private IEnumerable<Intersection> CheckIntersectionsAndAddToQueue(LineSegment lineSegment)
        {
            var intersections = new List<Intersection>();

            if (_lineSegmentsQueue.Count > 0)
            {
                var firstLineSegment = _lineSegmentsQueue.Peek();
                if (firstLineSegment.RightMostX < lineSegment.LeftMostX)
                {
                    _lineSegmentsQueue.Dequeue();
                }

                foreach (var segment in _lineSegmentsQueue)
                {
                    if (_intersectionChecker.DoIntersect(segment, lineSegment))
                    {
                        intersections.Add(new Intersection(segment, lineSegment));
                    }
                }
                _lineSegmentsQueue.Enqueue(lineSegment);
            }
            else
            {
                _lineSegmentsQueue.Enqueue(lineSegment);
            }

            return intersections;
        }

        private IEnumerable<LineSegment> OrderByLeftMostX(IEnumerable<LineSegment> lineSegments)
        {
            return lineSegments.OrderBy(ls => ls.LeftMostX)
                               .ThenBy(ls => ls.RightMostX);
        }
    }
}
