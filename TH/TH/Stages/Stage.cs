using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    abstract class Stage
    {
        protected List<Layer> layers = new List<Layer>();

        public List<Layer> Layers
        {
            get { return layers; }
        }

        public abstract Stage nextStage();
    }
}
