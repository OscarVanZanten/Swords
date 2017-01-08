using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Entities;
using Swords.Util;
using Swords.Rendering;

namespace Swords.Levels
{
    class Level : Renderable
    {
        private static Level instance;
        public static Level Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Level();
                }
                return instance;
            }
        }
     

        private List<Entity> entities = new List<Entity>();

        public void Init()
        {
            SwordsGame.Renderer.Register(this);
        }

        public void Update()
        {
            foreach (Entity entity in entities)
            {
              //  Console.WriteLine(entity.Childeren.Count);
                entity.Update();
            }
            //Console.WriteLine();
        }

        public Entity SpawnEntity(string name, Location location)
        {
            Entity entity = EntityFactory.GetEntity(name, location);
            entities.Add(entity);
            SwordsGame.Renderer.Register(entity);
            return entity;
        }

        public void RemoveEntity(Entity entity)
        {
            entities.Remove(entity);
            SwordsGame.Renderer.Remove(entity);
        }

        public ISprite[] GetSprites()
        {
            return new ISprite[] { };
        }
    }
}
