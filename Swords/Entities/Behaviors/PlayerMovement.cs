using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Swords.Util;

namespace Swords.Entities.Behaviors
{
    class PlayerMovement : Behavior
    {
        private Location location;

        public PlayerMovement(Location location)
        {
            this.location = location;
        }

        public void Start()
        {

        }

        public void Update()
        {
            Vector2 vec = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            vec.Y = -vec.Y;

            location.Add(vec * 3);
            location.SetRotation(GamePad.GetState(PlayerIndex.One).ThumbSticks.Right);
        }
    }
}
