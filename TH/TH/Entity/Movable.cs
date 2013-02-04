using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    interface Movable
    {
        //Move will move and accelerate.
        void move();
        int xVel
        {
            get;
            set;
        }
        int yVel
        {
            get;
            set;
        }

        Point currentLocation
        {
            get;
            set;
        }
    }
}
