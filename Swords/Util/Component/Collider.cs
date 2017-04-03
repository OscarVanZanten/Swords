using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Util.Shapes;
using Swords.Util.Listeneners;
using Swords.Levels.GameObjects;

namespace Swords.Util.Component
{
    class Collider : Component
    {
        public Shape Hitbox { get; set; }
        public bool DrawHitbox { get { return draw; } }
        private bool draw;
        private GameObject entity;
        private List<CollisionListener> listeneners;

        public Collider(Shape hitbox, bool draw)
        {
            this.Hitbox = hitbox;
            this.draw = draw;
            this.listeneners = new List<CollisionListener>();
        }

        public void Collide()
        {
            foreach (CollisionListener listener in listeneners)
            {
                listener.OnCollision(entity);
            }
        }

        public void RegisterCollisionListenener(CollisionListener listenener)
        {
            listeneners.Add(listenener);
        }

        public object Clone()
        {
            return new Collider(Hitbox, draw);
        }

        public void Start(GameObject entity)
        {
            this.entity = entity;
            Hitbox.Location = entity.Location;
        }

        public void Update()
        {
        }
    }
}
