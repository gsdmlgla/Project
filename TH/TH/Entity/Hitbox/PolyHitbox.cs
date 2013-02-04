using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    /// <summary>
    /// not really finished.. still thinking..
    /// </summary>
    class PolyHitbox:Hitbox
    {
        public const int CIRCLE = 41;
        public const int SQUARE = 12;
        /// <summary>
        /// The hitboxes
        /// </summary>
        List<Hitbox> hitboxes = new List<Hitbox>();

        /// <summary>
        /// Creates a polyhitbox. At first
        /// </summary>
        /// <param name="owner">this si the</param>
        public PolyHitbox(Entity owner)
            : base(owner, 0, 0, 1, 1)
        {
           // hitboxes.Add(new CircleHitbox(owner, owner.Width / 2, owner.Height / 2, 10));
        }

        /// <summary>
        /// Adds a new hitbox to this polyhitbox
        /// </summary>
        /// <param name="type">Square or Cirle. use PolyHitbox.CIRCLE or PolyHitbox.SQUARE</param>
        /// <param name="cx">CenterX of the hitbox relative to the X of the owner.</param>
        /// <param name="cy">CenterY of the hitbox relative to the Y of the owner.</param>
        /// <param name="width">Width of the hitbox.</param>
        /// <param name="height">Height of the hitbox. If the type is circle, the value here is ignored.</param>
        public void addHitbox(int type, int cx, int cy, int width, int height)
        {
            if (type == CIRCLE)
            {
                hitboxes.Add(new CircleHitbox(owner, cx, cy, width));
            }
            else if (type == SQUARE)
            {
                hitboxes.Add(new SquareHitbox(owner, cx, cy, width, height));
            }
            else
            {
                throw new ArgumentException("PolyHitbox.CIRCLE or PolyHitbox.SQUARE only");
            }
        }

        /// <summary>
        /// Gets the list of all the hitboxes for this entity.
        /// </summary>
        /// <returns></returns>
        public List<Hitbox> getAllHitboxes()
        {
            return hitboxes;
        }

        /// <summary>
        /// Sets hitbox color for each hitbox this entity has.
        /// </summary>
        /// <param name="outline"></param>
        /// <param name="fill"></param>
        public override void setHitboxColor(Color outline, Color fill)
        {
            for (int i = 0; i < hitboxes.Count; i++)
            {
                hitboxes[i].setHitboxColor(outline, fill);
            }
        }

        /// <summary>
        /// Check if all the hitbox collides with the other hitbox.
        /// </summary>
        /// <param name="collide">The hitbox of the other entity to check collision with.</param>
        /// <returns>True if it collides, false otherwise.</returns>
        public override bool CollideWith(Hitbox collide)
        {
            int size = hitboxes.Count;
            if (size == 0)
            {
                return false;
            }
            //poly to poly, needs to check everything
            if (collide is PolyHitbox)
            {
                int size2 = ((PolyHitbox)collide).getNumOfHitbox();
                if (size2 == 0)
                {
                    return false;
                }
                List<Hitbox> others = ((PolyHitbox)collide).hitboxes;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        if(hitboxes[i].CollideWith(others[j]))
                        {
                            return true;
                        }
                    }

                }
                return false;

            }

            //poly to single
            for (int i = 0; i < size; i++)
            {
                if (hitboxes[i].CollideWith(collide))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Draws the all the hitboxes.
        /// </summary>
        /// <param name="g">Graphics</param>
        public override void DrawHitbox(Graphics g)
        {
            int size = hitboxes.Count;
            for (int i = 0; i < size; i++)
            {
                hitboxes[i].DrawHitbox(g);
            }
        }

        public int getNumOfHitbox()
        {
            return hitboxes.Count;
        }
    }
}
