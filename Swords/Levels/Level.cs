using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.Entities;
using Swords.Util;
using Swords.Rendering;

using Microsoft.Xna.Framework.Graphics;

namespace Swords.Levels
{
    class Level : Renderable
    {
        private static Level instance;
        public static Level Instance { get { if (instance == null) { instance = new Level(); } return instance; } }
        
        public Texture2D Background { get; set;}

        private List<Entity> entities = new List<Entity>();

        public void Init()
        {
            SwordsGame.Renderer.Register(this);
        }

        public void Update()
        {
            foreach (Entity entity in entities)
            {
                entity.Update();
            }
        }

        public Entity SpawnEntity(string name, Location location)
        {
            Entity entity = EntityFactory.GetEntity(name, location);
            entities.Add(entity);
            SwordsGame.Renderer.Register(entity);
            return entity;
        }

        public void Remove(Entity entity)
        {
            entities.Remove(entity);
            SwordsGame.Renderer.Remove(entity);
        }

        public ISprite[] GetSprites()
        {
            if (Background == null)
            {
                return new ISprite[] { };
            }
            else
            {
                return new ISprite[] { new Sprite(new Location(0, 0, 0), Background, Position.Absolute) };
            }
        }
    }
}
