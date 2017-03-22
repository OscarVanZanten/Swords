using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Util.Shapes;

using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class Collider : Component
    {
        public Shape Hitbox { get; set; }
        private GameObject entity;

        public Collider(Shape hitbox)
        {
            this.Hitbox = hitbox;
        }

        public delegate void Collision(GameObject entity);

        public object Clone()
        {
            return new Collider(Hitbox);
        }

        public void Start(GameObject entity)
        {
            this.entity = entity;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
