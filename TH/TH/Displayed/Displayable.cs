using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    interface Displayable
    {
        Image image
        {
            get;
            set;
        }
        Point currentLocation
        {
            get;
            set;
        }
        Point centerLocation
        {
            get;
            set;
        }

        /// <summary>
        /// to be overrided to be called in Displayer
        /// </summary>
        void draw();

        /// <summary>
        /// to be overrided to be called in Displayer
        /// </summary>
        /// <param name="Clockwise">the degrees clockwise to rotatae the image, the rotational axis depends on implemenation</param>
        void draw(double Clockwise);
    }
}
