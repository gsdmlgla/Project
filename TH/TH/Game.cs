using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    class Game
    {
        /// <summary>
        /// Game has 2 players.
        /// </summary>
        private Controller Red, Blue;

        private NetworkCommandStream networkCommandStream;
        private KeyCommandStream keyCommandStream;
        private FileCommandStream fileCommandStream;

        /// <summary>
        /// the handle to the window
        /// </summary>
        private IntPtr hwnd;

        private Stage currentStage;
        private MenuStage mstage;
        public MenuStage menuStage
        {
            set { if (mstage == null) mstage = value; }
            get { return mstage; }
        }
        
        private CombatStage cstage;
        /// <summary>
        /// You only can have one combat stage at all time.
        /// That's why this is combat stage, not arena pvp or story.
        /// </summary>
        public CombatStage combatStage
        {
            set { cstage = value; }
            get { return cstage; }
        }
        private CharacterSelectStage csstage;
        public CharacterSelectStage characterSelectStage
        {
            set { if (csstage == null) csstage = value; }
            get { return csstage; }
        }
        private OptionStage ostage;
        public OptionStage optionStage
        {
            set { if (ostage == null) ostage = value; }
            get { return ostage; }
        }
        private ReplayStage rstage;
        public ReplayStage replayStage
        {
            set { if (rstage == null) rstage = value; }
            get { return rstage; }
        }
        private ScoreStage sstage;
        public ScoreStage scoreStage
        {
            set { if (sstage == null)  sstage = value; }
            get { return sstage; }
        }
        private PauseStage pstage;
        public PauseStage pauseStage
        {
            set { if (pstage == null)  pstage = value; }
            get { return pstage; }
        }
        private ModeSelectStage msstage;
        public ModeSelectStage modeSelectStage
        {
            set { if (msstage == null) msstage = value; }
            get { return msstage; }
        }
        /// <summary>
        /// constructs and intializes the game
        /// </summary>
        /// <param name="window"></param>
        public Game(Window window)
        {
            hwnd = window.Handle;
            SoundPlayer.Init(hwnd);
            Screen.Init(hwnd);
        }
        /// <summary>
        /// starts the game
        /// </summary>
        public void start()
        {
            currentStage = new MenuStage();
            while (currentStage != null)
            {
                currentStage = currentStage.nextStage();
            }
        }
        /// <summary>
        /// This should load settings from the file. 
        /// Option file will always be located in root and named option.data
        /// </summary>
        public void loadOption()
        {

        }
    }
}
