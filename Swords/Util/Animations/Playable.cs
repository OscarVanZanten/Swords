using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swords.Util.Animations
{
    interface Playable
    {
        void Play();
        void Pause();
        void Stop();
        bool IsPlaying();
    }
}
