using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TH
{
    abstract class Hitbox
    {
        #region datamembers
        protected Entity owner;
        protected int cx;
        protected int cy;
        protected int x;
        protected int y;
        protected int width;
        protected int height;
        protected int relativeCX;
        protected int relativeCY;
        protected int relativeX;
        protected int relativeY;
        protected Color outside;
        protected Color inside;
        protected bool show = true;

        /// <summary>
        /// Gets the owner of the hitbox.
        /// </summary>
        public Entity Owner
        {
            get { return owner; }
        }
        /// <summary>
        /// Gets or Sets the X of the hitbox
        /// </summary>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Gets or Sets the Y of the hitbox
        /// </summary>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Gets the center x value of the hitbox.
        /// </summary>
        public int CX
        {
            get { return cx; }
        }

        /// <summary>
        /// Gets the center y value of the hitbox.
        /// </summary>
        public int CY
        {
            get { return cy; }
        }

        /// <summary>
        /// Gets or sets the width of the hitbox.
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Gets or sets the width of the hitbox.
        /// Changing this variable for circlehitboxes will not do anything.
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Gets or Sets whether the hitbox should be painted or not.
        /// </summary>
        public bool ShowHitBox
        {
            get { return show; }
            set { show = value; }
        }
        #endregion

        /// <summary>
        /// Constructs a hitbox.
        /// </summary>
        /// <param name="owner">The owner of the hitbox.</param>
        /// <param name="centerx">The centerX of the hitbox relative to the X of its owner.</param>
        /// <param name="centery">The centerY of the hitbox relative to the Y of its owner.</param>
        /// <param name="w">The width of the hitbox.</param>
        /// <param name="h">The height of the hitbox.</param>
        public Hitbox(Entity owner, int centerx, int centery, int w, int h)
        {
            this.owner = owner;
            centerx = owner.X + centerx;
            centery = owner.Y + centery;
            cx = centerx;
            cy = centery;
            width = w;
            height = h;
        }
        /// <summary>
        /// Sets the color of the hitbox.
        /// </summary>
        /// <param name="outline">Color of the outline of the hitbox.</param>
        /// <param name="fill">Color of the fill of the hitbox.</param>
        public virtual void setHitboxColor(Color outline, Color fill)
        {
            outside = outline;
            inside = fill;
        }
        /// <summary>
        /// Updates the hitbox. Not really used.. still thinking about it.. this is already
        /// happening in the drawhitbox..
        /// </summary>
        protected void updateHitbox()
        {
            x = owner.X + relativeX;             //update the x relative to how it is setup before
            y = owner.Y + relativeY;             //same with y
            cx = x + (width / 2);                //update cx using x
            cy = y + (height / 2); 
        }

        /// <summary>
        /// Must be implemented. Draws the hitbox. Make sure to handle if ShowHitbox is true/false.
        /// </summary>
        /// <param name="g"></param>
        public abstract void DrawHitbox(Graphics g);

        /// <summary>
        /// Must be implemented. Checks for collision with another entity.
        /// </summary>
        /// <param name="collide">Entity to collide with</param>
        /// <returns>True if they collide. False otherwise.</returns>
        public abstract bool CollideWith(Hitbox collide);

        /// <summary>
        /// Gets the distance between two points.
        /// </summary>
        /// <param name="x1">x of the first point.</param>
        /// <param name="y1">y of one first point.</param>
        /// <param name="x2">x of the second point.</param>
        /// <param name="y2">y of the second point.</param>
        /// <returns></returns>
        protected double getDistance(int x1, int y1, int x2, int y2)
        {
            double dx = (x2 - x1) * (x2 - x1);
            double dy = (y2 - y1) * (y2 - y1);

            return Math.Sqrt(dx + dy);
        }

        public void setVisible(bool visible)
        {
            if (this is PolyHitbox)
            {
                PolyHitbox x = (PolyHitbox)(this);
                int size = x.getNumOfHitbox();
                List<Hitbox> temp = x.getAllHitboxes();
                for (int i = 0; i < size; i++)
                {
                    temp[i].show = visible;
                }
            }
            else
            {
                show = visible;
            }
        }
    }
}
