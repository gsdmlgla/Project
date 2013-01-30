using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    class Game
    {
        public mainForm window;
        public Game(mainForm window)
        {
            this.window = window;
            SoundPlayer.Init(window.Handle);
        }
    }
}
