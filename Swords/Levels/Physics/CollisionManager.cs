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

        private List<ColliderEntry> colliders = new List<ColliderEntry>();

        public void Add(GameObject entity)
        {
            if (entity.HasBehavior<Collider>())
            {
                colliders.Add(new ColliderEntry(entity, entity.GetBehavior<Collider>(), entity.GetBehavior<RigidBody>()));
            }
        }

        public void Remove(GameObject entity)
        {
            foreach (ColliderEntry entry in colliders)
            {
                if (entry.Entity.Equals(entity))
                {
                    colliders.Remove(entry);
                    return;
                }
            }
        }

        public void Update()
        {
            List<CollisionPossibility> possibilties = new List<CollisionPossibility>();
            //update boundingboxes
            foreach (ColliderEntry collider in colliders)
            {
                collider.Collider.Hitbox.UpdateBroadBoundingBox();
            }
            //broad pass
            foreach (ColliderEntry collider1 in colliders)
            {
                foreach (ColliderEntry collider2 in colliders)
                {
                    if (collider1 == collider2) { continue; }
                    if (collider1.Collider.Hitbox.BroadBoundingBox.Intersects(collider2.Collider.Hitbox.BroadBoundingBox))
                    {
                        possibilties.Add(new CollisionPossibility(collider1, collider2));
                    }
                }
            }
            //narrow pass
            foreach (CollisionPossibility poss in possibilties)
            {
                if (poss.Entry1.Collider.Hitbox.Intersects(poss.Entry2.Collider.Hitbox))
                {
                    poss.Entry1.Collider.Collide();

                    //first entity
                    GameObject fe = poss.Entry1.Entity;
                    RigidBody fr = poss.Entry1.Rigidbody;
                    Collider fc = poss.Entry1.Collider;

                    //second entity
                    GameObject se = poss.Entry2.Entity;
                    RigidBody sr = poss.Entry2.Rigidbody;
                    Collider sc = poss.Entry2.Collider;

                    ////collision
                    Vector2 fNormal = (fe.Location.Vector - se.Location.Vector) / (fe.Location.Vector - se.Location.Vector).Length();
                    Console.WriteLine(fNormal);
                    fr.AddForce(30, fNormal);
                   // if(fe.Location.Vector - se.Location.Vector) { }

                }
            }
        }
    }
}
