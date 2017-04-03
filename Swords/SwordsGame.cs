using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Swords.Util;
using Swords.Content;
using Swords.Rendering;
using Swords.Levels.GameObjects;
using Swords.Util.Animations;
using Swords.Util.Component;
using Swords.Util.Shapes;
using Swords.Levels;

namespace Swords
{
    public class SwordsGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //rendering
        public static Renderer Renderer;

        public SwordsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            Level.Instance.Init();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Renderer = new Renderer(graphics, spriteBatch, GraphicsDevice);

            ContentRegistry.Textures.Add("Grass", Content.Load<Texture2D>("Grass"));
            ContentRegistry.Textures.Add("Grass2", Content.Load<Texture2D>("Grass2"));
            ContentRegistry.Textures.Add("Grass3", Content.Load<Texture2D>("Grass3"));
            ContentRegistry.Textures.Add("Grass4", Content.Load<Texture2D>("Grass4"));
            ContentRegistry.Textures.Add("Grass5", Content.Load<Texture2D>("Grass5"));
            ContentRegistry.Textures.Add("Grass6", Content.Load<Texture2D>("Grass6"));
            ContentRegistry.Textures.Add("Grass7", Content.Load<Texture2D>("Grass7"));
            ContentRegistry.Textures.Add("Grass8", Content.Load<Texture2D>("Grass8"));
            ContentRegistry.Textures.Add("Grass9", Content.Load<Texture2D>("Grass9"));

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
                    }, 15));

            Level.Instance.SpawnEntity("Player", new Location(50, 100, 0));
            Level.Instance.SpawnEntity("Object", new Location(150, 100, 0));
            Level.Instance.SpawnEntity("Object", new Location(200, 100, 0));
             Level.Instance.SpawnEntity("Object", new Location(250, 100, 0));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Level.Instance.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Renderer.Render();
            base.Draw(gameTime);
        }
    }
}
