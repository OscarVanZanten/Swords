using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    abstract class Shape
    {
        public Vector2[] Vertices { get; set; }
        public Line[] Edges { get; set; }

        public Location Location { get; set; }

        public Vector2[] AbsoluteVertices
        {
            get
            {
                if (Vertices == null) { return null; }
                Vector2[] verts = new Vector2[Vertices.Length];
                for (int i = 0; i < Vertices.Length; i++)
                {
                    verts[i] = Location.Add(Location, Vertices[i]).Vector;
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
                    edges[i] = new Line(Location.Add(Location, Edges[i].P1).Vector, Location.Add(Location, Edges[i].P2).Vector);
                }
                return edges;
            }
        }

        public abstract bool Contains(Vector2 p);

        public virtual bool Contains(Line l)
        {
            if (Contains(l.P1) && Contains(l.P2)) { return true; }
            return false;
        }

        public virtual bool Intersects(Line l)
        {
            foreach (Line edge in AbsoluteEdges)
            {
                if (edge.Intersect(l))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Intersects(Shape p)
        {
            Vector2[] vertices = AbsoluteVertices;
            Line[] edges = AbsoluteEdges;
            foreach (Vector2 vertex in vertices)
            {
                if (p.Contains(vertex)) { return true; }
            }

            foreach (Line edge in edges)
            {
                if (p.Intersects(edge)) { return true; }
            }

            return false;
        }
    }
}
