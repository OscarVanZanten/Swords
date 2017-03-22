using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class Triangle : Shape
    {

        public Triangle(Location location, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.Location = location;
            this.Vertices = new Vector2[3];
            this.Edges = new Line[3];
            this.Vertices[0] = p1;
            this.Vertices[1] = p2;
            this.Vertices[2] = p3;

            for (int i = 0; i < Vertices.Length; i++)
            {
                Edges[i] = new Line(Vertices[i], (i + 1 == Vertices.Length) ? Vertices[0] : Vertices[i + 1]);
            }

            this.UpdateBroadBoundingBox();
        }

        public override bool Contains(Vector2 p)
        {
            bool b1 = Sign(p, Vertices[0], Vertices[1])< 0.0f;
            bool b2 = Sign(p, Vertices[1], Vertices[2]) < 0.0f;
            bool b3 = Sign(p, Vertices[2], Vertices[0]) < 0.0f;

            return ((b1==b2) && (b2==b3));
        }

      
        private float Sign(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

    }
}
