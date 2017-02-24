using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class Line
    {
        public Vector2 P1 { get { return p1; } }
        public Vector2 P2 { get { return p2; } }

        private Vector2 p1;
        private Vector2 p2;

        public Line(Vector2 p1, Vector2 p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public bool Intersect(Line l)
        {
            float A1 = P1.Y - P2.Y;
            float B1 = P1.X - P2.X;
            float C1 = A1 * P2.X + B1 * P2.Y;

            float A2 = l.P1.Y - l.P2.Y;
            float B2 = l.P1.X - l.P2.X;
            float C2 = A1 * l.P2.X + B1 * l.P2.Y;

            float delta = A1 * B2 - A2 * B1;
            if (delta == 0)
            {
                return false;
                throw new ArgumentException("Lines are parallel");
            }
            else
            {
                return true;
            }

            float x = (B2 * C1 - B1 * C2) / delta;
            float y = (A1 * C2 - A2 * C1) / delta;

            return false;
        }
    }
}
