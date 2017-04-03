using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.GameObjects;
using Swords.Util.Component;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Swords.Rendering
{
    public class Renderer
    {
        private List<Renderable> renderables;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spritebatch;
        private GraphicsDevice device;

        public Renderer(GraphicsDeviceManager graphics, SpriteBatch spritebatch, GraphicsDevice device)
        {
            this.renderables = new List<Renderable>();
            this.graphics = graphics;
            this.spritebatch = spritebatch;
            this.device = device;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.PreferMultiSampling = true;
            graphics.ToggleFullScreen();
            graphics.ApplyChanges();
            Camera.Zoom = 2;
        }

        public void Render()
        {
            spritebatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            foreach (Renderable render in renderables)
            {
                foreach (ISprite sprite in render.GetSprites())
                {
                    Vector2 pos = new Vector2(0, 0);

                    switch (sprite.Pos)
                    {
                        case Position.Absolute:
                            pos = sprite.Location.Vector;
                            break;
                        case Position.Relative:
                            pos = sprite.Location.Vector * Camera.Zoom + Camera.Location;
                            break;
                        default:
                            pos = sprite.Location.Vector;
                            break;
                    }
                    spritebatch.Draw(sprite.Texture, pos, new Rectangle(0, 0, sprite.Texture.Width, sprite.Texture.Height), Color.White, sprite.Location.Rotation, new Vector2(sprite.Texture.Width / 2, sprite.Texture.Height / 2), Camera.Zoom, SpriteEffects.None, 0);
                }
                if (render is GameObject)
                {
                    GameObject go = (GameObject)render;
                    Collider c = go.GetBehavior<Collider>();

                    if (c != null)
                    {
                        if (c.DrawHitbox)
                        {
                            c.Hitbox.UpdateBroadBoundingBox();
                            Swords.Util.Shapes.Rectangle box = (Swords.Util.Shapes.Rectangle) c.Hitbox;
                            Texture2D bound = new Texture2D(device, (int)box.Width, (int)box.Height);
                            Color[] color = new Color[(int)(box.Width * box.Height)];
                            for (int i = 0; i < color.Length; i++)
                            {
                                color[i] = Color.Black;
                            }
                            bound.SetData(color);

                           //Console.WriteLine(box.Width);                          

                            spritebatch.Draw(bound, box.Location.Vector * Camera.Zoom + Camera.Location, 
                                new Rectangle(0, 0, (int)box.Width, (int)box.Height), Color.White, 0, new Vector2(box.Width / 2, box.Height / 2), Camera.Zoom, SpriteEffects.None, 0);
                        }
                    }
                }
            }
            spritebatch.End();
        }

        public void Register(Renderable renderable)
        {
            renderables.Add(renderable);
        }

        public void Remove(Renderable renderable)
        {
            renderables.Remove(renderable);
        }
    }
}
