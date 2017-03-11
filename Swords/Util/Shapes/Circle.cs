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
        public Vector2[] Vertices { get; set; }
        public Line[] Edges { get; set; }

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

        public Location Location { get; set; }

        private float radius;
        private static int BaseVerticesCount = 6;
        private static float BaseSize = 1;
        private static float VerticesIncrease = 0.25f;

        public Circle(Location location, float radius, int VerticesCount)
        {
            //calculate vertices and edges
            Vertices = new Vector2[VerticesCount];
            Edges = new Line[VerticesCount];

            Vector2 pointer = new Vector2(0, radius);
            float angle = (float)(Math.PI * 2 / VerticesCount);

            for (int i = 0; i < VerticesCount; i++)
            {
                Vertices[i] = new Vector2(pointer.X, pointer.Y);
                pointer = Vector2.Transform(pointer, Matrix.CreateRotationX(angle));
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                Edges[i] = new Line(Vertices[i], (i + 1 == VerticesCount) ? Vertices[0] : Vertices[i + 1]);
            }

            this.Location = location;
            this.radius = radius;

            Console.WriteLine("Vertex: " + Vertices.Length + " Edge: " + Edges.Length);
        }

        public Circle(Location location, float radius) : this(location, radius, (int)(BaseVerticesCount + (radius - BaseSize) / VerticesIncrease)) { }

        public bool Contains(Line l)
        {
            if (Contains(l.P1) && Contains(l.P2)) { return true; }
            return false;
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

            double AAngle = Math.Acos((AC * AC + AB * AB - BC * BC) / (2 * AC * AB));
            double AbAAngle = Math.Atan2(
               Location.Vector.Y - l.P1.Y,
                Location.Vector.X - l.P1.X);
            double BAngle = Math.PI - AAngle;
            double AbBAngle = AbAAngle + BAngle;

            double BD = Math.Sin(AAngle) * AB;

            if (BD > radius) { return false; };

            Vector2 D = new Vector2(0, (float)BD);
            D = Vector2.Transform(D, Matrix.CreateRotationX((float)AbBAngle));
            D += this.Location.Vector;

            Line BDLine = new Line(this.Location.Vector, D);

            if (l.Intersect(BDLine)) { return true; }
            return false;
        }

        private double RadiansToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
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

        private double Distance(Vector2 p1, Vector2 p2)
        {
            float x = Math.Abs(p2.X - p1.X);
            float y = Math.Abs(p2.Y - p1.Y);
            return Math.Sqrt(x * x + y * y);
        }
    }
}
