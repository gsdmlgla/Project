using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    class SquareHitbox:Hitbox
    {
        /// <summary>
        /// Constructs a square hitbox
        /// </summary>
        /// <param name="own">Owner of the hitbox</param>
        /// <param name="cx">CenterX of the hitbox relative to its owner's X</param>
        /// <param name="cy">CenterY of the hitbox relative to its owner's Y</param>
        /// <param name="w">The Width of the hitbox.</param>
        /// <param name="h">The height of the hitbox.</param>
        public SquareHitbox(Entity own, int cx, int cy, int w, int h)
            : base(own, cx, cy, w, h)
        {
            outside = Color.Green ;
            inside = Color.Green ;
            x = own.X + cx - (w / 2);
            y = own.Y + cy - (h / 2);
            relativeCX = cx - own.X;
            relativeCY = cy - own.Y;
            relativeX = x - own.X;
            relativeY = y - own.Y;
        }


        /// <summary>
        /// Updates the x and y of the hitbox and paints itself.
        /// </summary>
        /// <param name="g"></param>
        public override void DrawHitbox(Graphics g)
        {
            x = owner.X + relativeX;             //update the x relative to how it is setup before
            y = owner.Y + relativeY;             //same with y
            cx = x + (width / 2);                //update cx using x
            cy = y + (height / 2);               //same with y.. used for collision detection;
            if (show)
            {
                g.FillRectangle(new SolidBrush(inside), x, y, width, height);
                g.DrawRectangle(new Pen(new SolidBrush(outside), 1), x, y, width, height);
            }

        }

        /// <summary>
        /// Check if this hitbox will collide to the other entity's hitbox.
        /// </summary>
        /// <param name="other">The other entity to check collision.</param>
        /// <returns>True if they collide. Otherwise, false.</returns>
        public override bool CollideWith(Hitbox other)
        {
            if (other == null)
            {
                return false;
            }
            if (other is CircleHitbox)
            {
                int rightx = x + width;
                int boty = y + height;
                int othercx = other.CX;
                int othercy = other.CY;
                //((Stage1)(owner.CurrentStagePanel)).label1.Text = cx + " " + cy + " " + other.Y;
                if (rightx >= othercx && x <= othercx || y <= othercy && boty >= othercy)
                {
                    if ((x <= other.X + other.Width && rightx >= other.X) &&
                    (boty >= other.Y && y <= other.Y + other.Width))
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
                else if (getDistance(othercx, othercy, x, y) < other.Width / 2 ||
                         getDistance(othercx, othercy, rightx, y) < other.Width / 2 ||
                         getDistance(othercx, othercy, x, boty) < other.Width / 2 ||
                         getDistance(othercx, othercy, rightx, boty) < other.Width / 2)
                {
                    //((Stage1)(owner.CurrentStagePanel)).label1.Text = "sq!!!";
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Black;
                   // Random rand = new Random();
                   // candidate.ChangeHitbox(new CircleHitbox(candidate, candidate.Width / 2, candidate.Height / 2, rand.Next(50)+1));
                    return true;
                }
                else
                {
                    //owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Firebrick;
                    return false;
                }
            }

            
            else if (other is SquareHitbox)
            {
                int myrightx = x + width;
                int myboty = y + height;
                int otherrightx = other.X + other.Width;
                int otherboty = other.Y + other.Height;

                if ((other.X <= myrightx && otherrightx >= X) &&
                    (otherboty >= y && other.Y <= myboty))
                {
                   // owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Black;
                    //((Stage1)(owner.CurrentStagePanel)).label1.Text = "SQUARE!!!";
                    return true;

                }
                else
                {
                   // owner.CurrentStagePanel.PanelBgPanel.BackColor = Color.Firebrick;
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
                throw new ArgumentException("What hitbox is that?!");
            }
        }

    }
}
