﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Swords.Util;

namespace Swords.Rendering
{
    class Sprite : ISprite
    {
        public Location Location { get; set; }
        public Texture2D Texture { get; set; }

        public Sprite(Location location, Texture2D texture)
        {
            this.Location = location;
            this.Texture = texture;
        }
    }
}
