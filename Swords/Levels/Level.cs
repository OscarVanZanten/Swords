using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.GameObjects;
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

        private List<GameObject> entities = new List<GameObject>();

        public void Init()
        {
            SwordsGame.Renderer.Register(this);
        }

        public void Update()
        {
            foreach (GameObject entity in entities)
            {
                entity.Update();
            }
        }

        public GameObject SpawnEntity(string name, Location location)
        {
            GameObject entity = GameObjectFactory.GetEntity(name, location);
            entities.Add(entity);
            SwordsGame.Renderer.Register(entity);
            return entity;
        }

        public void Remove(GameObject entity)
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
