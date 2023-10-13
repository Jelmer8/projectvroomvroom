using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectVroomVroom.TrackSegments
{
    public class TrackLineSegment
    {
        static double MARGIN = 200;
        static double CORNER_RADIUS = 100;

        public TrackLineSegment(int index, double milestone, Point point1, Point point2)
        {
            var p1 = new Point(point1.X + MARGIN, point1.Y + MARGIN);
            var p2 = new Point(point2.X + MARGIN, point2.Y + MARGIN);

            this.Index = index;
            this.Milestone = milestone;

            this.P1 = p1;
            this.P2 = p2;

            var dX = (p2.X - p1.X);
            var dY = (p2.Y - p1.Y);

            this.Coefficient = dY / dX;

            var h = Math.Sqrt(dX * dX + dY * dY);

            Length = h;

            var cos = dX / h;
            var sin = dY / h;
            var aCos = Math.Acos(cos);
            var aSin = Math.Asin(cos);
            var angle = 0.0;

            angle = 90.0 * (aCos / (Math.PI / 2));

            P3 = new Point(P1.X, P1.Y);
            P4 = new Point(P2.X, P2.Y);

            if (cos > 0.0 && sin > 0.0)
            {
                P3 = new Point(P1.X + cos * CORNER_RADIUS, P1.Y + sin * CORNER_RADIUS);
                P4 = new Point(P2.X - cos * CORNER_RADIUS, P2.Y - sin * CORNER_RADIUS);
                angle = 270.0 - angle;
            }
            else if (cos > 0.0 && sin < 0.0)
            {
                P3 = new Point(P1.X + cos * CORNER_RADIUS, P1.Y + sin * CORNER_RADIUS);
                P4 = new Point(P2.X - cos * CORNER_RADIUS, P2.Y - sin * CORNER_RADIUS);
                angle = 270.0 + angle;
            }
            else if (cos < 0.0 && sin > 0.0)
            {
                P3 = new Point(P1.X + cos * CORNER_RADIUS, P1.Y + sin * CORNER_RADIUS);
                P4 = new Point(P2.X - cos * CORNER_RADIUS, P2.Y - sin * CORNER_RADIUS);
                angle = 270.0 - angle;
            }
            else if (cos < 0.0 && sin < 0.0)
            {
                P3 = new Point(P1.X + cos * CORNER_RADIUS, P1.Y + sin * CORNER_RADIUS);
                P4 = new Point(P2.X - cos * CORNER_RADIUS, P2.Y - sin * CORNER_RADIUS);
                angle = 270.0 + angle;
            }

            //angle = Math.Abs(angle);

            if (angle < 0)
                angle = 360.0 + angle;

            angle = angle % 360.0;

            this.Angle = angle;
        }

        public Point P1 { get; set; }
        public Point P2 { get; set; }
        public Point P3 { get; set; }
        public Point P4 { get; set; }
        public double Coefficient { get; set; }
        public bool IsOutOfRange { get; set; }
        public double Angle { get; set; }
        public double Length { get; set; }
        public double Milestone { get; set; }
        public int Index { get; set; }
        public Point CurveCenter { get; set; }

        public Point GetNearestPoint(Point externalPoint)
        {
            var v = new Vector(externalPoint.X, externalPoint.Y);
            var v1 = new Vector(P1.X, P1.Y);
            var v2 = new Vector(P2.X, P2.Y);

            var closestVector = v1 + ((v2 - v1) * (v - v1)) * (v2 - v1) / ((v2 - v1) * (v2 - v1));

            return new Point(closestVector.X, closestVector.Y);
        }

        public double GetDistanceToPoint(Point externalPoint)
        {
            var x0 = externalPoint.X;
            var y0 = externalPoint.Y;
            var x1 = P1.X;
            var y1 = P1.Y;
            var x2 = P2.X;
            var y2 = P2.Y;
            var distance = Math.Abs((x2 - x1) * (y1 - y0) - (x1 - x0) * (y2 - y1)) /
                Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

    }
}
