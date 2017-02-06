using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Levels.Entities.Behaviors
{
    interface Behavior : ICloneable
    {
        void Start(Entity entity);
        void Update();
    }
}
