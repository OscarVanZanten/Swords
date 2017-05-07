using Microsoft.Xna.Framework.Graphics;
using Swords.Util.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Swords.Content
{
    class ContentFactory
    {
        public static void Init(ContentManager Content)
        {
            InitTextures(Content);
            InitAnimations();
        }

        private static void InitTextures(ContentManager Content)
        {
            ContentRegistry.Textures.Add("Grass", Content.Load<Texture2D>("Grass"));
            ContentRegistry.Textures.Add("Grass2", Content.Load<Texture2D>("Grass2"));
            ContentRegistry.Textures.Add("Grass3", Content.Load<Texture2D>("Grass3"));
            ContentRegistry.Textures.Add("Grass4", Content.Load<Texture2D>("Grass4"));
            ContentRegistry.Textures.Add("Grass5", Content.Load<Texture2D>("Grass5"));
            ContentRegistry.Textures.Add("Grass6", Content.Load<Texture2D>("Grass6"));
            ContentRegistry.Textures.Add("Grass7", Content.Load<Texture2D>("Grass7"));
            ContentRegistry.Textures.Add("Grass8", Content.Load<Texture2D>("Grass8"));
            ContentRegistry.Textures.Add("Grass9", Content.Load<Texture2D>("Grass9"));
            ContentRegistry.Textures.Add("Sword", Content.Load<Texture2D>("Sword"));
            ContentRegistry.Textures.Add("Character-stand", Content.Load<Texture2D>("Character_stand"));

        }

        private static void InitAnimations()
        {
            ContentRegistry.Animations.Add(
                "Grass-Animation",
                new Animation(
                    new Texture2D[]
                    {
                        ContentRegistry.Textures.Get("Grass"),
                        ContentRegistry.Textures.Get("Grass2"),
                        ContentRegistry.Textures.Get("Grass3"),
                        ContentRegistry.Textures.Get("Grass4"),
                        ContentRegistry.Textures.Get("Grass5"),
                        ContentRegistry.Textures.Get("Grass6"),
                        ContentRegistry.Textures.Get("Grass7"),
                        ContentRegistry.Textures.Get("Grass8"),
                        ContentRegistry.Textures.Get("Grass9")
                    }, 0.2f));

            ContentRegistry.Animations.Add(
                "Player-Stand",
                new Animation(
                    new Texture2D[]
                    {
                         ContentRegistry.Textures.Get("Character-stand")
                    }, 0.2f));
                

            ContentRegistry.Animations.Add(
                "Sword-Animation",
                new Animation(
                    new Texture2D[]
                    {
                        ContentRegistry.Textures.Get("Sword"),
                    }, 0.2f));
        }

    }
}
