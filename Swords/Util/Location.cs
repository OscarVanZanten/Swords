using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Swords.Util
{
    public class Location
    {
        private Vector2 vector;
        private float rotation;

        public Vector2 Vector { get { return vector; } }
        public float Rotation { get { return rotation; } }

        public Location(Vector2 vec, float rot)
        {
            this.vector = vec;
            this.rotation = rot;
        }

        public Location(float x, float y, float rot) : this(new Vector2(x, y), rot) { }
        public Location(float x, float y) : this(new Vector2(x, y), 0) { }
        public Location(Vector2 vec) : this(vec, 0) { }
        public Location(float rot) : this(new Vector2(), rot) { }

        public void Add(Vector2 vec)
        {
            vector += vec;
        }

        public void IncRotation(float rot) {
            rotation += rot;
        }

        public void SetRotation(float rot)
        {
            rotation = rot;
        }

        public void SetRotation(Vector2 rot)
        {
            rot.Normalize();
            float d =(float) (Math.Atan(rot.X / rot.Y));
            if (d == d)
            {
                rotation = d;
            }
        }
    }
}
