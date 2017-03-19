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
        private float width;
        private float height;

        public Rectangle(Location location, float width, float height)
        {
            this.Location = location;
            this.width = width;
            this.height = height;

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
        } 

        public override bool Contains(Vector2 p)
        {
            Vector2 target = p - Location.Vector;
            target = Location.Rotate(target, -Location.Rotation);

            float width = this.width / 2;
            float height = this.height / 2;

            bool containsX = target.X < width && target.X > -width;
            bool containsY = target.Y < height && target.Y > -height;

            return (containsX && containsY);
        }

        public override String ToString()
        {
            String message = "Rectangle: \n";
            for (int i = 0; i < Vertices.Length; i++)
            {
                message += "P" + i + " " + AbsoluteVertices[i] + "\n";
            }
            return message;
        }
    }
}
