using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Util;
using Swords.Content;
using Swords.Entities.Behaviors;

namespace Swords.Entities
{
    enum EntityType
    {
        PLAYER
    }

    class EntityFactory
    {
        public static Entity GetEntity(EntityType type, Location loc)
        {
            Entity entity = null;

            switch (type)
            {
                case EntityType.PLAYER:
                    entity = new Entity(loc, ContentRegistry.Textures.Get("Grass"));
                    entity.AddBehavior(new PlayerMovement(loc));
                    entity.AddChild(new Entity(new Location(10,10, (float)Math.PI), ContentRegistry.Textures.Get("Grass")));
                    break;
            }

            return entity;
        }

    }
}
