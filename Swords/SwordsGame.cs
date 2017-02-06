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
using Swords.Levels.Entities;
using Swords.Levels.Entities.Behaviors;
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
            Renderer = new Renderer(graphics, spriteBatch);

            ContentRegistry.Textures.Add("Grass", Content.Load<Texture2D>("Grass"));

            EntityFactory.Register(
                new Entity(new Location(0, 0), ContentRegistry.Textures.Get("Grass"), "Player")
                    .AddBehavior(new PlayerMovement(3))
                    .AddChild(new Entity(new Location(32, 32, 0), ContentRegistry.Textures.Get("Grass"), "Child")));



            Level.Instance.SpawnEntity("Player", new Location(100, 100, 0));


            Entity entity = Level.Instance.SpawnEntity("Player", new Location(300, 100, 0));
             Console.WriteLine( entity.RemoveChild("Child").Name);
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
