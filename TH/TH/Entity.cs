using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    abstract class Entity : NoiseMaker
    {
        private readonly List<Sound> effects = new List<Sound>();

        protected abstract List<Sound> getSoundEffects();
        public void play(Sound soundEffect)
        {
            SoundPlayer.play(soundEffect);
        }
        public void play(int soundEffectID)
        {
            SoundPlayer.play(effects[soundEffectID]);
        }
    }
}
