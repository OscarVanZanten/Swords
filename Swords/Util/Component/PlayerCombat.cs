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
        private enum DashingState { Ready, WindUp, Dashing, WindDown }

        private GameObject player;
        private GameObject sword;

        private RigidBody playerBody;
        private PlayerMovement playerMove;

        private MouseState lastMouse;

        private float dashVelocity = 100000;
        private float windUpTimer = 0;
        private float windUpTime = 0.2f;
        private float dashTimer = 0;
        private float dashTime = 0.15f;
        private float windDownTimer = 0;
        private float windDownTime = 0.05f;
        private float movementSlowDown = 0.3f;

        private DashingState state = DashingState.Ready;

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
            MouseState currentMouse = Mouse.GetState();
            if (CanDash(currentMouse))
            {
                StartWindUp();
            }

            switch (state)
            {
                case DashingState.WindUp:
                    UpdateWindUp(time);
                    break;
                case DashingState.Dashing:
                    UpdateDash(time);
                    break;
                case DashingState.WindDown:
                    UpdateWindDown(time);
                    break;
            }

            if (windUpTimer > windUpTime)
            {
                if ((currentMouse.LeftButton != ButtonState.Pressed && currentMouse.RightButton != ButtonState.Pressed))
                {
                    EndWindUp(false);
                }
            }
            else if (state == DashingState.WindUp)
            {
                if ((currentMouse.LeftButton != ButtonState.Pressed && currentMouse.RightButton != ButtonState.Pressed))
                {
                    EndWindUp(true);
                }
            }

            if (dashTimer > dashTime)
            {
                EndDash();
            }

            if (windDownTimer > windDownTime)
            {
                EndWindDown();
            }

            lastMouse = currentMouse;
        }

        private void StartWindUp()
        {
            playerBody.SetVelocity(new Vector2());
            playerMove.SetSlowDown(movementSlowDown);
            state = DashingState.WindUp;
        }

        private void UpdateWindUp(float time)
        {
            windUpTimer += time;
        }

        private void EndWindUp(bool cancel)
        {
            playerMove.SetSlowDown(1f);
            if (!cancel)
            {
                windUpTimer = 0;
                playerMove.SetMoving(false);
                StartDash();
            }
            else
            {
                state = DashingState.Ready;
            }
        }

        private void StartDash()
        {
            playerMove.SetRotating(false);
            state = DashingState.Dashing;
        }

        private void UpdateDash(float time)
        {
            dashTimer += time;
            Vector2 thumb = player.Location.GetRetotation();
            playerBody.SetVelocity( player.Location.GetRetotation() * dashVelocity * time);
        }

        private void EndDash()
        {
            dashTimer = 0;
            playerBody.SetVelocity(new Vector2(0, 0));
            StartWindDown();
        }

        private void StartWindDown()
        {
            state = DashingState.WindDown;
            playerMove.SetRotating(true);
        }

        private void UpdateWindDown(float time)
        {
            windDownTimer += time;
        }

        private void EndWindDown()
        {
            windDownTimer = 0;
            playerMove.SetMoving(true);
            state = DashingState.Ready;
        }

        private bool CanDash(MouseState currentMouse)
        {
            bool canDash = false;
            if ((currentMouse.LeftButton == ButtonState.Pressed || currentMouse.RightButton == ButtonState.Pressed) &&
                (lastMouse.LeftButton != ButtonState.Pressed && lastMouse.RightButton != ButtonState.Pressed))
            {
                canDash = true;
            }
            return canDash;
        }
    }
}