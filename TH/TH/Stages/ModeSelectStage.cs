using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    class ModeSelectStage:Stage
    {
        Layer background = new Layer();
        Layer menuitems  = new Layer();

        /// <summary>
        /// Top margin of the first item.
        /// </summary>
        const int topmargin = 200;
        /// <summary>
        /// Left margin of the labels.
        /// </summary>
        const int pad = 10;
        /// <summary>
        /// The gaps between items.
        /// </summary>
        const int gap = 50;

        /// <summary>
        /// Constructs a ModeSelectStage
        /// </summary>
        public ModeSelectStage()
        {
            BackgroundDisplayable bg = new BackgroundDisplayable(null);
            background.Add(bg);

            MenuItem title = new MenuItem(null, 0, 0);
            MenuItem story = new MenuItem(null, pad, topmargin);
            MenuItem pvp = new MenuItem(null, pad, story.currentLocation.Y + gap);
            MenuItem arena = new MenuItem(null, pad, pvp.currentLocation.Y + gap);
            MenuItem back = new MenuItem(null, pad, arena.currentLocation.Y + gap * 2);

            menuitems.Add(title);
            menuitems.Add(story);
            menuitems.Add(pvp);
            menuitems.Add(arena);
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
