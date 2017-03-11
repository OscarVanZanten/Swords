using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class Rectangle : Shape
    {
        public Vector2[] AbsoluteVertices
        {
            get
            {
                if (Vertices == null) { return null; }
                Vector2[] verts = new Vector2[Vertices.Length];
                for (int i = 0; i < Vertices.Length; i++)
                {
                    verts[i] = Vertices[i] + Location.Vector;
                }
                return verts;
            }
        }

        public Line[] AbsoluteEdges
        {
            get
            {
                if (Edges == null) { return null; }
                Line[] edges = new Line[Edges.Length];
                for (int i = 0; i < Edges.Length; i++)
                {
                    edges[i] = new Line(Edges[i].P1 + Location.Vector, Edges[i].P2 + Location.Vector);
                }
                return edges;
            }
        }

        public Vector2[] Vertices { get; set; }
        public Line[] Edges { get; set; }

        public Location Location { get; set; }

        public Rectangle(Location location, int width, int height)
        {
            this.Location = location;
            this.Vertices = new Vector2[4];
            this.Edges = new Line[4];
        }


        public bool Contains(Line l)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2 p)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(Shape p)
        {
            throw new NotImplementedException();
        }

        public bool Intersects(Line l)
        {
            throw new NotImplementedException();
        }
    }
}
