using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Swords.Util;
using Swords.Rendering;
using Swords.Entities;

namespace Swords
{
    public class SwordsGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //rendering
        public static Renderer Renderer;

        private Entity test;

        private Texture2D grass;

        public SwordsGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
         
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            grass = Content.Load<Texture2D>("Grass");

            Renderer = new Renderer(graphics, spriteBatch);

            test = new Entity(new Location(100, 100, 0), grass);
            Renderer.Register(test);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            test.Update();


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
