using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    class CharacterSelectStage:Stage
    {
        Layer background = new Layer();
        Layer menuitems  = new Layer();
        

        const int topmargin = 200;
        const int pad = 10;
        const int gap = 50;

        public CharacterSelectStage()
        {
            BackgroundDisplayable bg = new BackgroundDisplayable(null);
            background.Add(bg);

            MenuItem title = new MenuItem(null, 0, 0);
            MenuItem char1 = new MenuItem(null, pad, topmargin);
            MenuItem char2 = new MenuItem(null, pad, char1.currentLocation.Y + gap);
            MenuItem char3 = new MenuItem(null, pad, char2.currentLocation.Y + gap);
            MenuItem char4 = new MenuItem(null, pad, char3.currentLocation.Y + gap);
            MenuItem char5 = new MenuItem(null, pad, char4.currentLocation.Y + gap);
            MenuItem random = new MenuItem(null, pad, char5.currentLocation.Y + gap);
            MenuItem back = new MenuItem(null, pad, random.currentLocation.Y + gap * 2);

            menuitems.Add(title);
            menuitems.Add(char1);
            menuitems.Add(char2);
            menuitems.Add(char3);
            menuitems.Add(char4);
            menuitems.Add(char5);
            menuitems.Add(random);
            menuitems.Add(back);

            layers.Add(background);
            layers.Add(menuitems);
        }


        public override Stage nextStage()
        {
            throw new NotImplementedException();
        }
    }
}
