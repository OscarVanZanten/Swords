using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

using Swords.Rendering;
using Swords.Util.Animations;
using Swords.Util.Component;
using Swords.Util;

namespace Swords.Levels.GameObjects
{
    class GameObject : IGameObject, Renderable, ICloneable
    {
        public string Name { get { return name; } }
        public Location Location { get { return location; } set { location = value; } }

        private string name;
        private Location location;
        private AnimationPlayer animations;
        private List<Component> behaviors;
        private List<GameObject> childeren;

        private GameObject(Location location, AnimationPlayer animations, string name, List<Component> behaviors, List<GameObject> childeren)
        {
            this.name = name;
            this.location = location;
            this.animations = animations;
            this.behaviors = behaviors;
            this.childeren = childeren;
            foreach (Component behavior in behaviors)
            {
                behavior.Start(this);
            }

        }

        public GameObject(Location location, AnimationPlayer animations, string name) : this(location, animations, name, new List<Component>(), new List<GameObject>()) { }
        public GameObject(Location location, string name) : this(location, null, name) { }
        public GameObject(Location location) : this(location, null, "Undefined") { }

        public ISprite[] GetSprites()
        {
            List<ISprite> sprites = new List<ISprite>();

            if (animations != null)
            {
                sprites.Add(new Sprite(location, animations.CurrentSprite, Position.Relative));
            }

            foreach (GameObject child in childeren)
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
            animations.Update();
            foreach (GameObject child in childeren)
            {
                child.Update();
            }
            foreach (Component behavior in behaviors)
            {
                behavior.Update();
            }
        }

        public GameObject AddBehavior(Component behavior)
        {
            if (!HasBehavior(behavior.GetType()))
            {
                behaviors.Add(behavior);
                behavior.Start(this);
            }
            return this;
        }

        public bool HasBehavior<T>() where T : Component
        {
            return GetBehavior<T>() != null ? true : false;
        }

        private bool HasBehavior(Type type) {
            foreach (Component b in behaviors)
            {
                if (b.GetType() == type)
                {
                    return true;
                }
            }
            return false;
        }

        public T GetBehavior<T>() where T : Component
        {
            foreach (Component b in behaviors)
            {
                if (b is T)
                {
                    return (T) b;
                }
            }
            return default(T);
        }

        public GameObject AddChild(GameObject entity)
        {
            childeren.Add(entity);
            return this;
        }

        public GameObject RemoveChild(string Name)
        {
            GameObject entity = null;
            foreach (GameObject child in childeren)
            {
                if (child.Name.Equals(Name))
                {
                    entity = child;
                    break;
                }
            }
            childeren.Remove(entity);
            return entity;
        }

        public void Remove()
        {
            Level.Instance.Remove(this);
        }

        public object Clone()
        {
            List<GameObject> childeren = new List<GameObject>();
            List<Component> behaviors = new List<Component>();

            foreach (GameObject child in this.childeren)
            {
                childeren.Add((GameObject)child.Clone());
            }

            foreach (Component behavior in this.behaviors)
            {
                behaviors.Add((Component)behavior.Clone());
            }
            GameObject entity = new GameObject(new Location(location.Vector.X, location.Vector.Y), animations, name, behaviors, childeren);

            foreach (Component behavior in entity.behaviors)
            {
                behavior.Start(entity);
            }

            return entity;
        }
    }
}
