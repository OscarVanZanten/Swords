using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Levels.Physics
{
    class CollisionPossibility
    {
        private ColliderEntry entry1;
        private ColliderEntry entry2;

        public ColliderEntry Entry1 { get { return entry1; } }
        public ColliderEntry Entry2 { get { return entry2; } }

        public CollisionPossibility(ColliderEntry entry1, ColliderEntry entry2)
        {
            this.entry1 = entry1;
            this.entry2 = entry2;
        }
    }
}
