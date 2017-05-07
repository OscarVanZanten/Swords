using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Swords.Util;
using Swords.Rendering;
using Swords.Levels.GameObjects;


namespace Swords.Util.Component
{
    class PlayerMovement : Component
    {
        private GameObject entity;
        private RigidBody rigidbody;

        private float Speed { get { return maxSpeed * slowdown; } }
        private float slowdown = 1f;
        private float maxSpeed;
        private float acceleration;
        private bool moving;
        private bool rotating;

        public PlayerMovement(float maxSpeed, float acceleration)
        {
            this.maxSpeed = maxSpeed;
            this.acceleration = acceleration;
        }

        public void Start(GameObject entity)
        {
            this.entity = entity;
            this.rigidbody = entity.GetBehavior<RigidBody>();
            this.moving = true;
            this.rotating = true;
        }

        public void Update(float time)
        {
            if (moving)
            {
                Vector2 vec = new Vector2(
                            (Keyboard.GetState().IsKeyDown(Keys.D) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.A) ? -1 : 0),
                            (Keyboard.GetState().IsKeyDown(Keys.S) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.W) ? -1 : 0));
                if (vec.Length() > 0)
                {
                    vec /= vec.Length();
                }
                if ((rigidbody.Velocity).Length() > Speed)
                {
                    this.rigidbody.Velocity /= rigidbody.Velocity.Length();
                    this.rigidbody.Velocity *= Speed;
                }
                this.rigidbody.AddForce(acceleration * time, vec);
            }

            if (rotating)
            {
                Vector2 rotation = (Mouse.GetState().Position.ToVector2() - Camera.Location * Camera.Zoom) - (entity.Location.Vector * Camera.Zoom);
                entity.Location.SetRotation(rotation);
            }
        }

        public void SetRotating(bool rotating)
        {
            this.rotating = rotating;
        }

        public void SetMoving(bool moving)
        {
            this.moving = moving;
        }

        public void SetSlowDown(float slowdown)
        {
            this.slowdown = slowdown;
        }
    }
}
