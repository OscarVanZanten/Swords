using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Swords.Util;

namespace Swords.Rendering
{
    public interface ISprite
    {
        Texture2D Texture { get; set; }
        Location Location { get; set; }
        Position Pos { get; set; }
    }
}
