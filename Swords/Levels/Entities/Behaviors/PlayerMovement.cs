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
        Entity entity;

        public void Start(Entity entity)
        {
            this.entity = entity;
        }

        public void Update()
        {
            Vector2 vec = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            vec.Y = -vec.Y;

            entity.Location.Add(vec * 3);
            entity.Location.SetRotation(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right);
        }

        public object Clone()
        {
            return new PlayerMovement();
        }

    }
}
