using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.GameObjects;
using Swords.Util.Component;
using Swords.Util.Shapes;

namespace Swords.Levels.Physics
{
    class CollisionManager
    {
        private static CollisionManager instance;
        public static CollisionManager Instance { get { if (instance == null) { instance = new CollisionManager(); } return instance; } }

        private Dictionary<GameObject, Collider> colliders = new Dictionary<GameObject, Collider>();

        public void Add(GameObject entity)
        {
            if (entity.HasBehavior<Collider>())
            {
                colliders.Add(entity, entity.GetBehavior<Collider>());
            }
        }

        public void Remove(GameObject entity)
        {
            if (colliders.ContainsKey(entity))
            {
                colliders.Remove(entity);
            }
        }

        public void Update()
        {
            Dictionary<GameObject, GameObject> possibilities = new Dictionary<GameObject, GameObject>();
            //broad pass
            foreach (KeyValuePair<GameObject, Collider> collider1 in colliders)
            {
                BoundingBox box1 = collider1.Value.Hitbox.BroadBoundingBox;
                foreach (KeyValuePair<GameObject, Collider> collider2 in colliders)
                {
                    BoundingBox box2 = collider2.Value.Hitbox.BroadBoundingBox;
                    if (box1.Intersects(box2))
                    {
                        if(!possibilities.Contains<KeyValuePair<GameObject,GameObject>>( new KeyValuePair<GameObject, GameObject>())
                    }
                }
            }


        }
    }
}
