using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using Swords.Rendering;
using Swords.Util;
using Swords.Entities.Behaviors;
using Swords.Levels;

namespace Swords.Entities
{
    class Entity : IEntity, Renderable, ICloneable
    {
        public string Name { get { return name; } }
        public Location Location { get { return location; } set { location = value; } }

        private string name;
        private Location location;
        private Texture2D texture;
        private List<Behavior> behaviors;
        private List<Entity> childeren;

        private Entity(Location location, Texture2D texture, string name, List<Behavior> behaviors, List<Entity> childeren)
        {
            this.name = name;
            this.location = location;
            this.texture = texture;
            this.behaviors = behaviors;
            this.childeren = childeren;
            foreach (Behavior behavior in behaviors)
            {
                behavior.Start(this);
            }

        }

        public Entity(Location location, Texture2D texture, string name) : this(location, texture, name, new List<Behavior>(), new List<Entity>()) { }
        public Entity(Location location, string name) : this(location, null, name) { }
        public Entity(Location location) : this(location, null, "Undefined") { }

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

        public Entity AddBehavior(Behavior behavior)
        {
            behaviors.Add(behavior);
            behavior.Start(this);

            return this;
        }

        public Entity AddChild(Entity entity)
        {
            childeren.Add(entity);
            return this;
        }

        public Entity RemoveChild(string Name)
        {
            Entity entity = null;
            foreach (Entity child in childeren)
            {
                {
                    entity = child;
                    break;
                }
            }
            return entity;
        }

        public void Remove()
        {
            Level.Instance.RemoveEntity(this);
        }

        public object Clone()
        {
            List<Entity> childeren = new List<Entity>();
            List<Behavior> behaviors = new List<Behavior>();

            foreach (Entity child in this.childeren)
            {
                childeren.Add((Entity)child.Clone());
            }

            foreach (Behavior behavior in this.behaviors)
            {
                behaviors.Add((Behavior)behavior.Clone());
            }
            Entity entity = new Entity(new Location(location.Vector.X, location.Vector.Y), texture, name, behaviors, childeren);

            foreach (Behavior behavior in entity.behaviors)
            {
                behavior.Start(entity);
            }

            return entity;
        }
    }
}
