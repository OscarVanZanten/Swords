using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class BoundingBox : Shape
    {
        public override Vector2[] AbsoluteVertices
        {
            get
            {
                if (Vertices == null) { return null; }
                Vector2[] verts = new Vector2[Vertices.Length];
                for (int i = 0; i < Vertices.Length; i++)
                {
                    verts[i] = Location.Vector + Vertices[i];
                }
                return verts;
            }
        }

        public override Line[] AbsoluteEdges
        {
            get
            {
                if (Edges == null) { return null; }
                Line[] edges = new Line[Edges.Length];
                for (int i = 0; i < Edges.Length; i++)
                {
                    edges[i] = new Line(Location.Vector + Edges[i].P1,Location.Vector + Edges[i].P2);
                }
                return edges;
            }
        }

        private float width, height;

        public BoundingBox(Location location, float width, float height)
        {
            this.Location = location;

            this.Vertices = new Vector2[4];
            this.Edges = new Line[4];

            this.Vertices[0] = new Vector2(-(width / 2), -(height / 2));
            this.Vertices[1] = new Vector2((width / 2), -(height / 2));
            this.Vertices[2] = new Vector2((width / 2), (height / 2));
            this.Vertices[3] = new Vector2(-(width / 2), (height / 2));

            for (int i = 0; i < Vertices.Length; i++)
            {
                Edges[i] = new Line(Vertices[i], (i + 1 == Vertices.Length) ? Vertices[0] : Vertices[i + 1]);
            }

            this.width = width/2;
            this.height = height/2;
        }

        public override bool Contains(Vector2 p)
        {
            bool containsX = p.X < width && p.X > -width;
            bool containsY = p.Y < height && p.Y > -height;

            return (containsX && containsY);
        }

        public override bool Intersects(Shape p)
        {
            Vector2[] vertices = AbsoluteVertices;
            foreach (Vector2 vertex in vertices)
            {
                if (p.Contains(vertex)) { return true; }
            }
            return false;
        }
    }
}
