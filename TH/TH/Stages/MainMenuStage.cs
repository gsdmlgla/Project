using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace TH
{
    class MainMenuStage:Stage
    {
        
        /// <summary>
        /// Displayables for background.
        /// </summary>
        Layer background = new Layer();

        /// <summary>
        /// Displayables for menu items.
        /// </summary>
        Layer menuitems = new Layer();

        /// <summary>
        /// Left margin.
        /// </summary>
        const int pad = 10;
        /// <summary>
        /// Top margin of the first item.
        /// </summary>
        const int topmargin = 200;
        /// <summary>
        /// Gap between menu items.
        /// </summary>
        const int gap = 50;

        /// <summary>
        /// Constructs a MainMenuStage.
        /// </summary>
        public MainMenuStage(){
        
            MenuItem Title = new MenuItem(null,0, 0);
            MenuItem Start = new MenuItem(null, pad, topmargin) ;
            MenuItem Options = new MenuItem(null, pad, Start.currentLocation.Y + gap) ;
            MenuItem Credits = new MenuItem(null, pad, Options.currentLocation.Y + gap) ;
            MenuItem Quit = new MenuItem(null, pad, Credits.currentLocation.Y + gap) ;
        
            menuitems.Add(Title);
            menuitems.Add(Start);
            menuitems.Add(Options);
            menuitems.Add(Credits);
            menuitems.Add(Quit);
        
            BackgroundDisplayable bg = new BackgroundDisplayable(null);
            background.Add(bg);

            layers.Add(background);
            layers.Add(menuitems);
        }

        public override Stage nextStage()
        {
            throw new NotImplementedException();
        }
    }
}
