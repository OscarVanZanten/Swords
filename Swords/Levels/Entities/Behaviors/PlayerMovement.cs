using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Swords.Util;

namespace Swords.Levels.Entities.Behaviors
{
    class PlayerMovement : Behavior
    {
        private Entity entity;
        private float speed;

        public PlayerMovement(float speed)
        {
            this.speed = speed;
        }

        public void Start(Entity entity)
        {
            this.entity = entity;
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
                     (Keyboard.GetState().IsKeyDown(Keys.D) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.A) ? -1 : 0)
                    , (Keyboard.GetState().IsKeyDown(Keys.S) ? 1 : 0) + (Keyboard.GetState().IsKeyDown(Keys.W) ? -1 : 0)
                    );

                entity.Location.Add(vec * speed);
            }
        }

        public object Clone()
        {
            return new PlayerMovement(speed);
        }

    }
}
