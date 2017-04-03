using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Swords.Levels.GameObjects;
using Swords.Util.Component;
using Swords.Util.Shapes;

namespace Swords.Levels.Physics
{
    class CollisionManager
    {
        private static CollisionManager instance;
        public static CollisionManager Instance { get { if (instance == null) { instance = new CollisionManager(); } return instance; } }

        private Dictionary<GameObject, KeyValuePair<Collider, RigidBody>> colliders = new Dictionary<GameObject, KeyValuePair<Collider, RigidBody>>();

        public void Add(GameObject entity)
        {
            if (entity.HasBehavior<Collider>())
            {
            Console.WriteLine(entity.Name);
                colliders.Add(entity, new KeyValuePair<Collider, RigidBody>(entity.GetBehavior<Collider>(), entity.GetBehavior<RigidBody>()));
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
           Console.WriteLine(colliders.Count);
            Dictionary<KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>,
                       KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>> possibilities = new Dictionary<KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>, KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>>();
            //broad pass
            foreach (KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>> collider1 in colliders)
            {
                foreach (KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>> collider2 in colliders)
                {
                    bool hit = collider1.Value.Key.Hitbox.BroadBoundingBox.Intersects(collider2.Value.Key.Hitbox.BroadBoundingBox);
                    Console.WriteLine(hit);
                    if (hit)
                    {
                        possibilities.Add(collider1, collider2);
                    }
                }
            }
            //narrow pass
            foreach (KeyValuePair<KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>, KeyValuePair<GameObject, KeyValuePair<Collider, RigidBody>>> poss in possibilities)
            {
                if (poss.Key.Value.Key.Hitbox.Intersects(poss.Value.Value.Key.Hitbox))
                {
                    poss.Key.Value.Value.AddVelocity(new Vector2(0, 10));
                }
            }
        }
    }
}
