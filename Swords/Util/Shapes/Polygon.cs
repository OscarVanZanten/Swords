using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    class Polygon : Shape
    {
        private Triangle[] triangles;

        public Polygon(Location location, Vector2[] vertices, Line[] outline, Triangle[] triangles )
        {
            this.Vertices = vertices;
            this.Edges = outline;
            this.triangles = triangles;

        }

        public override bool Contains(Vector2 p)
        {
            foreach (Triangle t in triangles)
            {
                if (t.Contains(p)) { return true; }
            }
            return false;
        }
    }
}
