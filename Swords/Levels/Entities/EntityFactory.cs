using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Util;
using Swords.Content;
using Swords.Levels.Entities.Behaviors;

namespace Swords.Levels.Entities
{
    class EntityFactory
    {
        private static Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public static void Register(Entity entity)
        {
            entities.Add(entity.Name, entity);
        }

        public static Entity GetEntity(string name, Location loc)
        {
            Entity entity = null;
            entities.TryGetValue(name, out entity);
            if (entity != null)
            {
                entity = (Entity)entity.Clone();
                entity.Location = loc;
            }

            return entity;
        }

    }
}
