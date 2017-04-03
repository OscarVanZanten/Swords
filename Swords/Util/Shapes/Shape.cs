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
        public Line[] Edges { get; set; }
        public Vector2[] Vertices { get; set; }
        public Location Location { get; set; }
        public BoundingBox BroadBoundingBox { get; set; }

        public virtual Vector2[] AbsoluteVertices
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

        public virtual Line[] AbsoluteEdges
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

        public virtual bool Intersects(Shape p)
        {
            foreach (Vector2 vertex in p.AbsoluteVertices)
            {
                if (Contains(vertex)) { return true; }
            }

           // foreach (Line edge in p.AbsoluteEdges)
           // {
           //    // if (Intersects(edge)) { return true; }
           // }
           //// Console.WriteLine
            return false;
        }

        public void UpdateBroadBoundingBox()
        {
            float distance = 0;

            foreach (Vector2 vec in Vertices)
            {
                float newDist = vec.Length();
                if (newDist > distance) { distance = newDist; }
            }
            distance *= 2;
            this.BroadBoundingBox = new BoundingBox(Location, distance, distance);

        }
    }
}
