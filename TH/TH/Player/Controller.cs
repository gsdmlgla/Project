using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    abstract class Controller
    {
        private Boss boss;
        private CommandStream commandStream;
        protected Controller(CommandStream commandStream)
        {
            this.commandStream = commandStream;
            commandStream.connect(this);
        }
        ~Controller()
        {
            commandStream.disconnect(this);
        }
        /// <summary>
        /// Depends on the input command, execute according function in the boss. 
        /// </summary>
        /// <param name="inputCommand"></param>
        public void command(Command inputCommand)
        {
           switch(inputCommand) 
           {
               case Command.MoveDownKeyDown:
                   boss.down = true;
                   break;
               case Command.MoveDownKeyUp:
                   boss.down = false;
                   break;
               case Command.MoveLeftKeyDown:
                   boss.left = true;
                   break;
               case Command.MoveLeftKeyUp:
                   boss.left = false;
                   break;
               case Command.MoveRightKeyDown:
                   boss.right = true;
                   break;
               case Command.MoveRightKeyUp:
                   boss.right = false;
                   break;
               case Command.MoveUpKeyDown:
                   boss.up = true;
                   break;
               case Command.MoveUpKeyUp:
                   boss.up = false;
                   break;
               case Command.ShiftKeyDown:
                   boss.shift = true;
                   break;
               case Command.ShiftUp:
                   boss.shift = false;
                   break;
               case Command.SkillAKeyDown:
                   boss.SkillADown();
                   break;
               case Command.SkillBKeyDown:
                   boss.SkillBDown();
                   break;
               case Command.SkillCKeyDown:
                   boss.SkillCDown();
                   break;
               case Command.SkillDKeyDown:
                   boss.SKillDDown();
                   break;
               case Command.SkillAKeyUp:
                   boss.SkillAUp();
                   break;
               case Command.SkillBKeyUp:
                   boss.SkillBUp();
                   break;
               case Command.SkillCKeyUp:
                   boss.SkillCUp();
                   break;
               case Command.SkillDKeyUp:
                   boss.SKillDUp();
                   break;
               case Command.Unknown:
               default:
                   return;
           }
        }
    }
}
