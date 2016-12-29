using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Swords.Rendering;
using Swords.Util;

namespace Swords.Entities
{
    class Entity : IEntity, Renderable
    {
        private Location location;
        private Texture2D texture;


        public Entity(Location location, Texture2D texture)
        {
            this.location = location;
            this.texture = texture;
        }


        public ISprite[] GetSprites()
        {
            return new ISprite[] { new Sprite(location, texture) };
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
