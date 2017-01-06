using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Swords.Rendering;
using Swords.Util;
using Swords.Entities.Behaviors;

namespace Swords.Entities
{
    class Entity : IEntity, Renderable
    {
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
            int length = childeren.Count;
            if (texture != null) length++;
            ISprite[] sprites = new ISprite[length];

            int count = 0;
            if (texture != null)
            {
                sprites[count++] = new Sprite(location, texture);
            }
            foreach (Entity entity in childeren)
            {
            }

            return sprites;
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
