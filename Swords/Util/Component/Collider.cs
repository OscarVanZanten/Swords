using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class Collider : Component
    {

        public Collider()
        {

        }
        

        public delegate void Collision(GameObject entity);

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public void Start(GameObject entity)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
