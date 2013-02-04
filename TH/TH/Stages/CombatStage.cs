using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    abstract class CombatStage : Stage
    {
        public override Stage nextStage() { return null; }
    }
}
