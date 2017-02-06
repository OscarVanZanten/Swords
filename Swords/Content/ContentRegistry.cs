using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using Swords.Util;
using Swords.Levels.Entities.Animations;

namespace Swords.Content
{
    class ContentRegistry
    {
        private static Registry<Texture2D> textures = new Registry<Texture2D>();
        private static Registry<Animation> animations = new Registry<Animation>();

        public static Registry<Texture2D> Textures { get { return textures; } }
        public static Registry<Animation> Animations { get { return animations; } }

    }
}
