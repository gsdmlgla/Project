using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TH
{
    enum Command
    {
        SkillAKeyDown, SkillAKeyUp,
        SkillBKeyDown, SkillBKeyUp,
        SkillCKeyDown, SkillCKeyUp,
        SkillDKeyDown, SkillDKeyUp,
        MoveUpKeyDown, MoveUpKeyUp,
        MoveDownKeyDown, MoveDownKeyUp,
        MoveRightKeyDown, MoveRightKeyUp,
        MoveLeftKeyDown, MoveLeftKeyUp,
        ShiftKeyDown, ShiftUp,
        Unknown
    }
}
