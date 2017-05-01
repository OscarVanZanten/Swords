using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swords.Levels.GameObjects;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Swords.Util.Component
{
    class PlayerCombat : Component
    {
        private GameObject player;
        private GameObject sword;

        private RigidBody playerBody;
        private PlayerMovement playerMove;

        private GamePadState last;

        private float dashForce = 80000000;
        private float timer = 0;
        private float maxTime = 0.33f;
        private bool dashing = false;

        public PlayerCombat(GameObject sword)
        {
            this.sword = sword;

            sword.Location.SetVector(new Vector2(0, 0));
        }

        public void Start(GameObject entity)
        {
            this.player = entity;
            this.playerBody = entity.GetBehavior<RigidBody>();
            this.playerMove = entity.GetBehavior<PlayerMovement>();
        }

        public void Update(float time)
        {
            GamePadState current = GamePad.GetState(PlayerIndex.One);
            if ((current.Triggers.Left > 0.8f || current.Triggers.Right > 0.8f) && last.Triggers.Left <  0.8f && last.Triggers.Right < 0.8f)
            {
                playerBody.SetVelocity(new Vector2());
                playerMove.SetMoving(false);
                dashing = true;
                Vector2 thumb = player.Location.GetRetotation();
                playerBody.AddForce(dashForce, player.Location.GetRetotation());
            }

            if (dashing)
            {
                timer += time;

            }

            if (timer > maxTime)
            {
                timer -= maxTime;
                playerBody.SetVelocity(new Vector2(0, 0));
                playerMove.SetMoving(true);
                dashing = false;
            }

            last = current;
        }
    }
}
