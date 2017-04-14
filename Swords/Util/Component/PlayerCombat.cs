using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class PlayerCombat : Component
    {
        GameObject sword;

        public PlayerCombat(GameObject sword)
        {
            this.sword = sword;
        }

        public void Start(GameObject entity)
        {

        }

        public void Update(float time)
        {
            sword.Location.IncRotation((float)(Math.PI / 8 * time));
        }
    }
}
