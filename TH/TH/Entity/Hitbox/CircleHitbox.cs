using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TH
{
    class CircleHitbox:Hitbox
    {
        /// <summary>
        /// Constructs a circlebox.
        /// Default color is green.
        /// Default is visible hitbox.
        /// </summary>
        /// <param name="own">The owner of the hitbox</param>
        /// <param name="cx">Center X of the hitbox relative to its owners X.</param>
        /// <param name="cy">Center Y of the hitbox relative to its owners Y.</param>
        /// <param name="size">Size of the hitbox. This will be the hitbox's Width and Height.</param>
        public CircleHitbox(Entity own, int cx, int cy, int size)
            : base(own, cx, cy, size, size)
        {
            outside = Color.Green;
            inside = Color.Green;
            x = own.X + cx - (size / 2);
            y = own.Y + cy - (size / 2);
            relativeCX = cx - own.X;
            relativeCY = cy - own.Y;
            relativeX = x - owner.X;
            relativeY = y - owner.Y;
        }

        /// <summary>
        /// Draws the hitbox. Not only draws the hitbox, this updates the x and y of the hitbox
        /// to follow its owners X and Y.
        /// If Hitbox's ShowHitBox property is false, it only updates the location of the hitbox.
        /// </summary>
        /// <param name="g">Graphics</param>
        public override void DrawHitbox(Graphics g)
        {
                              //just to make sure that circle is always a circle
            x = owner.X + relativeX;             //update the x relative to how it is setup before
            y = owner.Y + relativeY;             //same with y
            cx = x + (width / 2);                //update cx using x
            cy = y + (width / 2);               //same with y.. used for collision detection;
            if (show)
            {
                g.FillEllipse(new SolidBrush(inside), x, y, width, width);
                g.DrawArc(new Pen(new SolidBrush(outside), 2), x, y, width, width, 0, 360);
            }
        }

        /// <summary>
        /// Checks collision with the entity that was passed in the parameter.
        /// </summary>
        /// <param name="other">The entity to be checked</param>
        /// <returns>true if it collides, false otherwise.</returns>
        public override bool CollideWith(Hitbox other)
        {
            if (other == null)
            {
                return false;
            }
            double distance;
            //Square to circle collision
            if (other is SquareHitbox)
            {
                int rightx = other.X + other.Width;
                int boty = other.Y + other.Height;
                //((Stage1)(owner.CurrentStagePanel)).label1.Text = cx + " " + cy + " " + other.Y;
                if (rightx >= cx && other.X <= cx || other.Y <= cy && boty >= cy)
                {
                    if ((other.X <= x  + width && rightx >= X) &&
                    (boty >= y && other.Y <= y + width))
                    {
                        //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Black;
                        //((Stage1)(owner.CurrentStagePanel)).label1.Text = "SQUARE!!!";
                        return true;

                    }
                    else
                    {
                        //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Firebrick;
                        return false;
                    }
                }
                else if (getDistance(cx, cy, other.X, other.Y) < width / 2 ||
                         getDistance(cx, cy, rightx, other.Y) < width / 2 ||
                         getDistance(cx, cy, other.X, boty) < width / 2 ||
                         getDistance(cx, cy, rightx, boty) < width / 2)
                {
                    //((Stage1)(owner.CurrentStagePanel)).label1.Text = "sq!!!";
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Black;
                    return true;
                }
                else
                {
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Firebrick;
                    return false;
                }
            }

                //Circle to Circle collision
            else if(other is CircleHitbox)
            {
                double combinedradius = (other.Width / 2) + (width / 2);
                
                distance = getDistance(cx, cy, other.CX, other.CY);
                //((Stage1)(owner.CurrentStagePanel)).label1.Text = distance + " " + combinedradius + " " + (distance < combinedradius);
                if (distance < combinedradius)
                {
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Black;
                    //((Stage1)(owner.CurrentStagePanel)).label1.Text = "COLLIDE cir!!!";
                    return true;
                    
                }
                else
                {
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Firebrick;
                    return false;
                }
            }
            else if (other is PolyHitbox)
            {
                PolyHitbox h = (PolyHitbox)other;
                List<Hitbox> temp = h.getAllHitboxes();
                int size = h.getNumOfHitbox();
                for (int i = 0; i < size; i++)
                {
                    if (temp[i].CollideWith(this))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                throw new ArgumentException("What kind of hitbox is that?");
            }
        }

    }
}
