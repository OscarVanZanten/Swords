using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using Swords.Rendering;
using Swords.Util;
using Swords.Entities.Behaviors;

namespace Swords.Entities
{
    class Entity : IEntity, Renderable
    {
        public Location Location { get { return location; } }

        private Location location;
        private Texture2D texture;
        private List<Behavior> behaviors;
        private List<Entity> childeren;

        public Entity(Location location, Texture2D texture)
        {
            this.location = location;
            this.texture = texture;
            this.behaviors = new List<Behavior>();
            this.childeren = new List<Entity>();

            foreach (Behavior behavior in behaviors)
            {
                behavior.Start();
            }
        }

        public Entity(Location location) : this(location, null) { }

        public ISprite[] GetSprites()
        {
            List<ISprite> sprites = new List<ISprite>();

            if (texture != null)
            {
                sprites.Add(new Sprite(location, texture));
            }

            foreach (Entity child in childeren)
            {
                foreach (Sprite sprite in child.GetSprites())
                {
                    sprite.Location = Location.Add(location, sprite.Location);
                    sprites.Add(sprite);
                }
            }
            return sprites.ToArray();
        }

        public void Update()
        {
            foreach (Entity child in childeren)
            {
                child.Update();
            }
            foreach (Behavior behavior in behaviors)
            {
                behavior.Update();
            }
        }

        public void AddBehavior(Behavior behavior)
        {
            behaviors.Add(behavior);
            behavior.Start();
        }

        public void AddChild(Entity entity)
        {
            childeren.Add(entity);
        }
    }
}
