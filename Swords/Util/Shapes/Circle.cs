using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class Circle : Shape
    {
        public Location Location { get; set; }
        private float radius;

        public Circle(Location location, float radius)
        {
            this.Location = location;
            this.radius = radius;
        }

        public bool Contains(Line l)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2 p)
        {
            if (Distance(p, Location.Vector) > radius)
            {
                return false;
            }
            return true;
        }

        public bool Intersects(Line l)
        {
            if (Contains(l.P1) || Contains(l.P2)) { return true; }

            float lDeltaX = Math.Abs(l.P1.X - l.P2.X);
            float lDeltaY = Math.Abs(l.P1.Y - l.P2.Y);

            double AC = Distance(l.P1, l.P2);
            double AB = Distance(l.P1, Location.Vector);
            double BC = Distance(l.P2, Location.Vector);

            double AAngle = Math.Acos((AC * AC + AB * AB - BC *  BC) / (2 * AC * AB));
            double AbAAngle = Math.Atan2(
                l.P1.Y - Location.Vector.Y,
                l.P1.X - Location.Vector.X);
            double BAngle = Math.PI / 2 - AAngle;
            double AbBAngle = AbAAngle - (Math.PI - BAngle);

            double BD = Math.Sin(AAngle) * AB;

            if (BD > radius) { return false; };

            Vector2 D = new Vector2((float)Math.Cos(AbBAngle), (float)Math.Sin(AbBAngle));
            D.X *= (float)BD;
            D.Y *= (float)BD;

            return false;
        }

        public bool Intersects(Shape p)
        {
            throw new NotImplementedException();
        }

        private double Distance(Vector2 p1, Vector2 p2)
        {
            float x = Math.Abs(p2.X - p1.X);
            float y = Math.Abs(p2.Y - p1.Y);
            return Math.Sqrt(x * x + y * y);
        }
    }
}
