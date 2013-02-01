using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    class Game
    {
        private Stage 
            currentStage, menuStage, replayStage, 
            characterSelectionStage, pauseStage, 
            arenaStage, PvPStage, storyStage, 
            scoreStage, optionStage, modeSelectionStage;
        
        public Game(mainForm window)
        {
            SoundPlayer.Init(window.Handle);
        }
        public void start()
        {
            
        }
    }
}
