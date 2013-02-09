using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    abstract class Boss : Entity
    {

        /// <summary>
        /// get and set the velocity y
        /// </summary>
        public int VelocityY
        {
            get { return YVel; }
            set { YVel = value; }
        }

        /// <summary>
        /// get and set the velocity x
        /// </summary>
        public int VelocityX
        {
            get { return XVel; }
            set { XVel = value; }
        }

        /// <summary>
        /// the direction indicators
        /// </summary>
        public bool up, right, left, down, shift;

        /// <summary>
        /// skill activation indicators
        /// </summary>
        protected bool A, B, C, D;

        public Boss(Image img)
            : base(img)
        {
        }

        public Boss(Image img, Point loc, Hitbox hb,bool collidable = false, int hp = 1, int mp = 0, int baseSpeed = 10, Team team = Team.NEUTRAL)
            : base(img, loc, hb, collidable ,hp, mp,baseSpeed, team)
        {
        }

        /// <summary>
        /// skill a button released
        /// </summary>
        public abstract void SkillAUp();

        /// <summary>
        /// skill b button released
        /// </summary>
        public abstract void SkillBUp();

        /// <summary>
        /// skill c button released
        /// </summary>
        public abstract void SkillCUp();

        /// <summary>
        /// skill d button released
        /// </summary>
        public abstract void SKillDUp();

        /// <summary>
        /// skill a button pressed
        /// </summary>
        public abstract void SkillADown();

        /// <summary>
        /// skill b button pressed
        /// </summary>
        public abstract void SkillBDown();

        /// <summary>
        /// skill c button pressed
        /// </summary>
        public abstract void SkillCDown();

        /// <summary>
        /// skill d button pressed
        /// </summary>
        public abstract void SKillDDown();

        /// <summary>
        /// up key pressed
        /// </summary>
        public virtual void UpPressed()
        {
            up = true;
            VelocityY = 10;
        }

        /// <summary>
        /// up key released
        /// </summary>
        public virtual void UpReleased()
        {
            up = false;
            if (down == true)
            {
                VelocityY = -10;
            }
            else if (down == false)
            {
                VelocityY = 0;
            }
        }

        /// <summary>
        /// down key pressed
        /// </summary>
        public virtual void DownPressed()
        {
            down = true;
            VelocityY = -10;
        }

        /// <summary>
        /// down key released
        /// </summary>
        public virtual void DownReleased()
        {
            down = false;
            if (up == true)
            {
                VelocityY = 10;
            }
            else if (up == false)
            {
                VelocityX = 0;
            }
        }

        /// <summary>
        /// left key pressed
        /// </summary>
        public virtual void LeftPressed()
        {
            left = true;
            VelocityX = -10;
        }

        /// <summary>
        /// left key released
        /// </summary>
        public virtual void LeftReleased()
        {
            left = false;
            if (right == true)
            {
                VelocityX = 10;
            }
            else if (right == false)
            {
                VelocityX = 0;
            }
        }

        /// <summary>
        /// right key pressed
        /// </summary>
        public virtual void RightPressed()
        {
            right = true;
            VelocityY = 10;
        }

        /// <summary>
        /// right ky released
        /// </summary>
        public virtual void RIghtReleased()
        {
            right = false;
            if (left == true)
            {
                VelocityX = -10;
            }
            else if (left == false)
            {
                VelocityX = 0;
            }
        }
    }
}
