using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Util;
using Swords.Content;
using Swords.Util.Component;

namespace Swords.Levels.GameObjects
{
    class GameObjectFactory
    {
        private static Dictionary<string, GameObject> entities = new Dictionary<string, GameObject>();

        public static void Register(GameObject entity)
        {
            entities.Add(entity.Name, entity);
        }

        public static GameObject GetEntity(string name, Location loc)
        {
            GameObject entity = null;
            entities.TryGetValue(name, out entity);
            if (entity != null)
            {
                entity = (GameObject)entity.Clone();
                entity.Location.Vector = loc.Vector;
                entity.Location.SetRotation(loc.Rotation);
            }
            return entity;
        }

    }
}
