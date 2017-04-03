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
        private float rotationalDrag;

        private float rotationVelocity;
        private Vector2 velocity;

        public float Mass { get { return mass; } }
        public Vector2 Velocity { get { return velocity; } }

        public RigidBody(float mass, float drag, float rotationalDrag, Vector2 velocity, float rotationVelocity)
        {
            this.mass = mass;
            this.drag = drag;
            this.rotationalDrag = rotationalDrag;
            this.velocity = velocity;
            this.rotationVelocity = rotationVelocity;
        }

        public RigidBody(float mass, float drag, float rotationDrag) : this(mass, drag,rotationDrag, new Vector2(), 0) { }

        public void Start(GameObject entity)
        {
            this.entity = entity;
        }

        public void Update()
        {
            entity.Location.Add(velocity);
            entity.Location.IncRotation(rotationVelocity);

            rotationVelocity = rotationVelocity < 0 ?
                (Math.Abs(rotationVelocity) < rotationalDrag) ? 0 : rotationVelocity + rotationalDrag :
                (Math.Abs(rotationVelocity) < rotationalDrag) ? 0 : rotationVelocity - rotationalDrag;

            float length = velocity.Length();

            velocity.X = (length - drag > 0) ? velocity.X / length * (length - drag) : 0;
            velocity.Y = (length - drag > 0) ? velocity.Y / length * (length - drag) : 0;
        }

        public void AddVelocity(Vector2 vec)
        {
            velocity += vec;
        }

        public void SetVelocity(Vector2 vec)
        {
            velocity = vec;
        }

        public object Clone()
        {
            return new RigidBody(mass, drag, rotationalDrag, new Vector2(velocity.X, velocity.Y), rotationVelocity);
        }

    }
}
