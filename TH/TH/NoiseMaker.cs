using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    interface NoiseMaker
    {
        void play(Sound effect);
        void play(int soundEffectID);
    }
}
