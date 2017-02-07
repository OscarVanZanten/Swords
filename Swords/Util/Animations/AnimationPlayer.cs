using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;

namespace Swords.Util.Animations
{
    class AnimationPlayer : Playable
    {
        public Texture2D CurrentSprite { get { return sprite; } }

        private List<Animation> animations;
        private Animation animation;
        private Texture2D sprite;
        private bool playing;
        private int index;
        private int time;

        public AnimationPlayer(List<Animation> animations)
        {
            this.playing = true;
            this.animations = animations;
            this.animation = !IsEmpty() ? animations[0] : null;
            this.sprite = !IsEmpty() ? !animations[0].IsEmpty() ? animations[0].Textures[0] : null : null;
            this.index = 0;
            this.time = 0;
        }

        public bool IsPlaying()
        {
            return playing;
        }

        public void Pause()
        {
            playing = false;
        }

        public void Play()
        {
            playing = true;
        }

        public void Stop()
        {
            playing = false;
            index = 0;
            time = 0;
        }

        public void Update()
        {
            if (playing && !IsEmpty())
            {
                time++;
                if (time == animation.Time)
                {
                    time = 0;
                    index++;
                    if (index == animation.Length)
                    {
                        index = 0;
                    }
                    sprite = animation.Textures[index];
                }
            }
        }

        private bool IsEmpty()
        {
            if(animations == null)
            {
                return true;
            }
            if (animations.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
