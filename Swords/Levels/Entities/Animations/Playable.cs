using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Levels.Entities.Animations
{
    interface Playable
    {
        void Play();
        void Pause();
        void Stop();
        bool IsPlaying();
    }
}
