using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using Swords.Util;
using Swords.Content;
using Swords.Util.Component;
using Swords.Util.Animations;

namespace Swords.Levels.GameObjects
{
    class GameObjectFactory
    {
        public static GameObject GetEntity(string name, Location loc)
        {
            switch (name)
            {
                case "Player":
                    return new GameObject(loc,
                new AnimationPlayer(new List<Animation>() { ContentRegistry.Animations.Get("Grass-Animation") }), "Player")
                    .AddBehavior(new PlayerMovement(3))
                    .AddBehavior(new Collider(new Swords.Util.Shapes.Rectangle(32, 32), true))
                    .AddBehavior(new RigidBody(10, 0.05f, 0.001f, new Vector2(), 0.0f));
                case "Object":
                    return new GameObject(loc,
                    new AnimationPlayer(new List<Animation>() { ContentRegistry.Animations.Get("Grass-Animation") }), "Object")
                    .AddBehavior(new Collider(new Swords.Util.Shapes.Rectangle(32, 32), true))
                    .AddBehavior(new RigidBody(10, 0.05f, 0.001f, new Vector2(), 0.0f));
            }

            return null;
        }

    }
}
