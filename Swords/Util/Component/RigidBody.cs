using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class RigidBody : Component
    {
        private GameObject entity;

        private float mass;
        private float drag;
        private Vector2 velocity;

        public RigidBody(float mass, float drag, Vector2 velocity)
        {
            this.mass = mass;
            this.drag = drag;
            this.velocity = velocity;
        }

        public RigidBody(float mass, float drag) : this(mass, drag, new Vector2()) { }


        public void Start(GameObject entity)
        {
            this.entity = entity;
        }

        public void Update()
        {
            entity.Location.Add(velocity);

            float length = velocity.Length();

            velocity.X = (length - drag > 0) ? velocity.X / length * (length - drag) : 0;
            velocity.Y = (length - drag > 0) ? velocity.Y / length * (length - drag) : 0;
        }

        public object Clone()
        {
            return new RigidBody(mass, drag, new Vector2(velocity.X, velocity.Y));
        }

    }
}
