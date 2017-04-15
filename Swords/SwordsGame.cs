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
        public static Renderer Renderer;

        public SwordsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            this.IsFixedTimeStep = false;
            base.Initialize();
            Level.Instance.Init();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Renderer = new Renderer(graphics, spriteBatch, GraphicsDevice);
            ContentFactory.Init(Content);

            Level.Instance.SpawnEntity("Player", new Location(50, 100, 0));
            Level.Instance.SpawnEntity("Object", new Location(150, 100, 0));
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();

            }
            Level.Instance.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
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
