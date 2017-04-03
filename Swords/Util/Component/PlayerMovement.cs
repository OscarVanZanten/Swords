using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Swords.Util;
using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class PlayerMovement : Component
    {
        private GameObject entity;
        private RigidBody rigidbody;
        private float speed;

        public PlayerMovement(float speed)
        {
            this.speed = speed;
        }

        public void Start(GameObject entity)
        {
            this.entity = entity;
            this.rigidbody = entity.GetBehavior<RigidBody>();
        }

        public void Update()
        {
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                Vector2 vec = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
                vec.Y = -vec.Y;

                entity.Location.Add(vec * speed);
                entity.Location.SetRotation(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right);
            }
            else
            {
                Vector2 vec = new Vector2(
                        (Keyboard.GetState().IsKeyDown(Keys.D) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.A) ? -1 : 0),
                        (Keyboard.GetState().IsKeyDown(Keys.S) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.W) ? -1 : 0));

                if (this.rigidbody.Velocity.Length() >= speed)
                {
                    this.rigidbody.SetVelocity(vec);
                }
                else
                {
                    this.rigidbody.AddVelocity(vec);
                }
            }
        }

        public object Clone()
        {
            return new PlayerMovement(speed);
        }

    }
}
