using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    class BackgroundDisplayable:Displayable
    {
        private Image img;
        /// <summary>
        /// gets and sets the image of the background
        /// </summary>
        public Image image
        {
            get { return img; }
            set { img = value; }
        }
        private Point loc;
        /// <summary>
        /// gets and sets the location, given the top left corner
        /// </summary>
        public Point currentLocation
        {
            get { return loc; }
            set { loc = value; }
        }
        /// <summary>
        /// gets and sets the location, given the center
        /// </summary>
        public Point centerLocation
        {
            get
            { return new Point(loc.X + img.Width / 2, loc.Y - img.Height / 2); }
            set
            { loc = new Point(value.X - img.Width / 2, value.Y + img.Height / 2); }
        }
        /// <summary>
        /// Constructs a background displayable.
        /// Image to fill the background should be 400 x 600.
        /// </summary>
        /// <param name="bg">The image to use.</param>
        /// <param name="x">OPTIONAL: The X coordinate of the image. 0 will be used if not set.</param>
        /// <param name="y">OPTIONAL: The Y coordinate of the image. 0 will be used if not set.</param>
        public BackgroundDisplayable(Image bg, int x = 0, int y = 0){
                image = bg;
                loc.X = x;
                loc.Y = y;
        }
        /// <summary>
        /// Overrides the draw method. Draws the image of the entity specified by its X and Y);
        /// </summary>
        public void draw()
        {
            Graphics g = Screen.g;
            g.DrawImage(image, currentLocation.X, currentLocation.Y);
        }
        /// <summary>
        /// draw the background with degree rotation
        /// </summary>
        /// <param name="Clockwise">the degrees to rotate</param>
        public void draw(double Clockwise)
        {
            float w = img.Width, h = img.Height;
            float r = (float)Math.Sqrt((w * w) + (h * h));
            Bitmap returnBitmap = new Bitmap((int)(r), (int)(r));
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform(r / 2, r / 2);
            g.RotateTransform((float)Clockwise);
            g.TranslateTransform(-w / 2, -w /2);
            g.DrawImage(img, new Point(0, 0));
            img = returnBitmap;
            returnBitmap.Dispose();
            g = Screen.g;
            g.DrawImage(img,centerLocation);
        }
    }
}
