using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Swords.Util.Shapes
{
    interface Shape
    {
        Vector2[] Vertices { get; set; }
        Line[] Edges { get; set; }

        Vector2[] AbsoluteVertices { get;  }
        Line[] AbsoluteEdges { get;  }

        Location Location { get; set; }
        bool Contains(Vector2 p);
        bool Contains(Line l);
        bool Intersects(Line l);
        bool Intersects(Shape p);
    }
}
