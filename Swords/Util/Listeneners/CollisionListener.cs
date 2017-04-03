using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.GameObjects;

namespace Swords.Util.Listeneners
{
    interface CollisionListener
    {
         void OnCollision(GameObject entity);

    }
}
