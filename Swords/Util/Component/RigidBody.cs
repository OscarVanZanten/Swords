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
        private float restitution;

        private float rotationVelocity;
        private Vector2 velocity;

        public float Mass { get { return mass; } }
        public float Restitution { get { return restitution; } }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }

        public RigidBody(float mass, float restitution, float drag, float rotationalDrag, Vector2 velocity, float rotationVelocity)
        {
            this.mass = mass;
            this.restitution = restitution;
            this.drag = drag;
            this.rotationalDrag = rotationalDrag;
            this.velocity = velocity;
            this.rotationVelocity = rotationVelocity;
        }

        public RigidBody(float mass,float restitution, float drag, float rotationDrag) :
            this(mass, restitution, drag, rotationDrag, new Vector2(), 0)
        { }

        public void Start(GameObject entity)
        {
            this.entity = entity;
        }

        public void Update(float time)
        {
            entity.Location.Add(velocity * time);
            entity.Location.IncRotation(rotationVelocity * time);

            rotationVelocity = rotationVelocity < 0 ?
                (Math.Abs(rotationVelocity) < rotationalDrag) ? 0 : rotationVelocity + rotationalDrag :
                (Math.Abs(rotationVelocity) < rotationalDrag) ? 0 : rotationVelocity - rotationalDrag;

            float length = velocity.Length();
            float timeDrag = drag * time;
            velocity.X = (length - timeDrag > 0) ? velocity.X / length * (length - timeDrag) : 0;
            velocity.Y = (length - timeDrag > 0) ? velocity.Y / length * (length - timeDrag) : 0;
        }

        public void AddVelocity(Vector2 vec)
        {
            velocity += vec;
        }

        public void SetVelocity(Vector2 vec)
        {
            velocity = vec;
        }

        public void AddForce(float force, Vector2 direction)
        {
            if (direction.X == 0 && direction.Y == 0) { return; }

            direction /= direction.Length();
            float velocity = (float)Math.Sqrt(force / mass);
            direction *= velocity;
            this.Velocity += direction;
        }

        public float GetForce()
        {
            float force = 0.5f * mass * velocity.LengthSquared();
            return force;
        }

        public Vector2 GetNormal()
        {
            Vector2 normal = (velocity / velocity.Length());
            if (float.IsNaN(normal.X)) { normal.X = 0; }
            if (float.IsNaN(normal.Y)) { normal.Y = 0; }
            return normal;
        }
    }
}
