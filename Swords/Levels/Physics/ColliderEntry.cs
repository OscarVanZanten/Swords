using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.Physics;
using Swords.Levels.GameObjects;
using Swords.Util.Component;
namespace Swords.Levels.Physics
{
    class ColliderEntry
    {
        private GameObject entity;
        private Collider collider;
        private RigidBody rigidbody;

        public GameObject Entity { get { return entity; } }
        public Collider Collider { get { return collider; } }
        public RigidBody Rigidbody { get { return rigidbody; } }

        public ColliderEntry(GameObject entity, Collider collider, RigidBody rigid)
        {
            this.entity = entity;
            this.collider = collider;
            this.rigidbody = rigid;
        }

    }
}
