using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    interface Displayable
    {
        private Image img;
        /// <summary>
        /// the image of this displayable
        /// </summary>
        public Image image
        {
            get { return img; }
            set { img = value; }
        }

        /// <summary>
        /// gets the center location of the displayable
        /// </summary>
        /// <returns>a point that contains the x and y values of the location</returns>
        public Point getCentralLocation();
        
        /// <summary>
        /// gets the top left corner of the displayable
        /// </summary>
        /// <returns>a point that contains the x and y values of the location</returns>
        public Point getCurrentLocation();

        /// <summary>
        /// to be overrided to be called in Displayer
        /// </summary>
        public void draw();

        /// <summary>
        /// to be overrided to be called in Displayer
        /// </summary>
        /// <param name="Clockwise">the degrees clockwise to rotatae the image, the rotational axis depends on implemenation</param>
        public void draw(double Clockwise);
    }
}
