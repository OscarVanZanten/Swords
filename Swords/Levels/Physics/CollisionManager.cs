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

        public void Update(float time)
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
                    GameObject fe = poss.Entry1.Entity;
                    RigidBody fr = poss.Entry1.Rigidbody;
                    GameObject se = poss.Entry2.Entity;
                    RigidBody sr = poss.Entry2.Rigidbody;

                    if (sr != null || fr != null)
                    {
                        Vector2 fNormal = ((fe.Location.Vector - se.Location.Vector) / (fe.Location.Vector - se.Location.Vector).Length());
                        float j = 0;
                        if (sr != null && fr != null)
                        {
                            Vector2 rv = (fr.Velocity - sr.Velocity);
                            float velAlongNormal = Vector2.Dot(rv, fNormal);
                            if (velAlongNormal > 0) { return; }
                            float e = Math.Min(fr.Restitution, sr.Restitution) * time;
                            j = (-(1 + e) * velAlongNormal) / (1 / fr.Mass + 1 / sr.Mass);
                        }
                        else if (sr != null)
                        {
                            Vector2 rv = (new Vector2() - sr.Velocity);
                            float velAlongNormal = Vector2.Dot(rv, fNormal);
                            if (velAlongNormal > 0) { return; }
                            float e = Math.Min(0, sr.Restitution) * time;
                            j = (-(1 + e) * velAlongNormal) / (1 / sr.Mass);
                        }
                        else if (fr != null)
                        {
                            Vector2 rv = (fr.Velocity - new Vector2());
                            float velAlongNormal = Vector2.Dot(rv, fNormal);
                            if (velAlongNormal > 0) { return; }
                            float e = Math.Min(fr.Restitution, 0) * time;
                            j = (-(1 + e) * velAlongNormal) / (1 / fr.Mass);
                        }
                        Vector2 impulse = j * fNormal;
                        if (fr != null)
                        {
                            fr.AddVelocity((1 / fr.Mass * impulse));
                        }
                    }
                }
            }
        }
    }
}
