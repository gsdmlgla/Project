using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    class MenuItem:Displayable
    {
        private Image img;
        public Image image
        {
            get { return img; }
            set { img = value; }
        }
        private Point loc;
        public Point currentLocation
        {
            get { return loc; }
            set { loc = value; }
        }

        /// <summary>
        /// Constructs a menu item. Could be a title, label, back button, etc.
        /// Use appropriate size!!
        /// </summary>
        /// <param name="img"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public MenuItem(Image img, int x, int y){
            image = img;
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

        public Point centerLocation
        {
            get { return new Point(loc.X + img.Width / 2, loc.Y - img.Height / 2); }
            set { loc = new Point(value.X - img.Width / 2, value.Y + img.Height / 2); }
        }

        public void draw(double Clockwise)
        {
            float w = img.Width, h = img.Height;
            float r = (float)Math.Sqrt((w * w) + (h * h));
            Bitmap returnBitmap = new Bitmap((int)(r), (int)(r));
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform(r / 2, r / 2);
            g.RotateTransform((float)Clockwise);
            g.TranslateTransform(-w / 2, -w / 2);
            g.DrawImage(img, new Point(0, 0));
            img = returnBitmap;
            returnBitmap.Dispose();
            g = Screen.g;
            g.DrawImage(img, centerLocation);
        }
    }
}
