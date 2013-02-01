using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    abstract class Entity : NoiseMaker, Displayable
    {
        #region data members
        #region displayable

        /// <summary>
        /// the co-ordinate pair of the entity
        /// </summary>
        private Point xy;

        /// <summary>
        /// the x location of the entity
        /// </summary>
        public int X
        {
            get { return xy.X; }
            set { xy.X = value; }
        }

        /// <summary>
        /// the y locatin of the enitity
        /// </summary>
        public int Y
        {
            get { return xy.Y; }
            set { xy.Y = value; }
        }

        #endregion
        #region noise maker

        /// <summary>
        /// the readonly list of all the sounds that the entity can play.
        /// </summary>
        private readonly List<Sound> effects = new List<Sound>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract List<Sound> getSoundEffects();
        #endregion

        #endregion
        #region methods
        #region noise maker
        /// <summary>
        /// plays the sound with the given soundeffect
        /// </summary>
        /// <param name="soundEffect">the sound effect to play</param>
        public void play(Sound soundEffect)
        {
            SoundPlayer.play(soundEffect);
        }
        /// <summary>
        /// palys the sound with the given ID
        /// ID is the index of the list of sounds
        /// </summary>
        /// <param name="soundEffectID">the ID of the sound effect to play</param>
        public void play(int soundEffectID)
        {
            SoundPlayer.play(effects[soundEffectID]);
        }
        #endregion
        #region displayable
        #endregion
        #endregion
    }
}
