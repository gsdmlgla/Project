using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TH
{
    /// <summary>
    /// Key values will be true while key is being pressed. 
    /// </summary>
    class KeyCommandStream : CommandStream
    {
        /// <summary>
        /// This will be used for Decoding KeycommandStream.
        /// </summary>
        public Keys
            SkillAKey,
            SkillBKey,
            SkillCKey,
            SkillDKey,
            MoveUpKey,
            MoveDownKey,
            MoveRightKey,
            MoveLeftKey,
            ShiftKey;
        
        public bool Key_A;
        public bool Key_B;
        public bool Key_C;
        public bool Key_D;
        public bool Key_SHIFT;

        public bool Key_UP;
        public bool Key_DOWN;
        public bool Key_RIGHT;
        public bool Key_LEFT;
        /// <summary>
        /// Pause shouldn't be used.
        /// Players doesn't need to know the pause is pressed or not.
        /// Only the game, which will tell combat stage to tell that it is paused need to know.
        /// </summary>
        private bool Key_PAUSE;
        /// <summary>
        /// Escape also is a command that character doesn't need to know. 
        /// It should tell game to switch stage to something else or quit the game. 
        /// </summary>
        private bool Key_ESCAPE;

        /// <summary>
        /// Upon keypress, all players connected to this stream will be notified that a key is pressed. 
        /// </summary>
        public void keyPress(Keys key)
        {
            Command command = Command.Unknown; 
            if (key.Equals(SkillAKey))
            {
                command = Command.SkillAKeyDown;
                Key_A = true;
            }
            else if (key.Equals(SkillBKey))
            {
                command = Command.SkillBKeyDown;
                Key_B = true;
            }
            else if (key.Equals(SkillCKey))
            {
                command = Command.SkillCKeyDown;
                Key_C = true;
            }
            else if (key.Equals(SkillDKey))
            {
                command = Command.SkillDKeyDown;
                Key_D = true;
            }
            else if (key.Equals(MoveDownKey))
            {
                command = Command.MoveDownKeyDown;
                Key_DOWN = true;
            }
            else if (key.Equals(MoveLeftKey))
            {
                command = Command.MoveLeftKeyDown;
                Key_LEFT = true;
            }
            else if (key.Equals(MoveRightKey))
            {
                command = Command.MoveRightKeyDown;
                Key_RIGHT = true;
            }
            else if (key.Equals(MoveUpKey))
            {
                command = Command.MoveUpKeyDown;
                Key_UP = true;
            }

            foreach (Controller player in connectedPlayers)
            {
                player.command(command);
            }
        }
        /// <summary>
        /// Upon keyrelease, all players connected to this stream will be notified that a key is released.
        /// </summary>
        public void keyRelease(Keys key)
        {
            Command command = Command.Unknown;
            if (key.Equals(SkillAKey))
            {
                command = Command.SkillAKeyUp;
                Key_A = false;
            }
            else if (key.Equals(SkillBKey))
            {
                command = Command.SkillBKeyUp;
                Key_B = false;
            }
            else if (key.Equals(SkillCKey))
            {
                command = Command.SkillCKeyUp;
                Key_C = false;
            }
            else if (key.Equals(SkillDKey))
            {
                command = Command.SkillDKeyUp;
                Key_D = false;
            }
            else if (key.Equals(MoveDownKey))
            {
                command = Command.MoveDownKeyUp;
                Key_DOWN = false;
            }
            else if (key.Equals(MoveLeftKey))
            {
                command = Command.MoveLeftKeyUp;
                Key_LEFT = false;
            }
            else if (key.Equals(MoveRightKey))
            {
                command = Command.MoveRightKeyUp;
                Key_RIGHT = false;
            }
            else if (key.Equals(MoveUpKey))
            {
                command = Command.MoveUpKeyUp;
                Key_UP = false;
            }

            foreach (Controller player in connectedPlayers)
            {
                player.command(command);                
            }
        }
    }
}
