using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using Swords.Util;

namespace Swords.Content
{
    class ContentRegistry
    {
        private static Registry<Texture2D> textures = new Registry<Texture2D>();

        public static Registry<Texture2D> Textures { get { return textures; } }

    }
}
