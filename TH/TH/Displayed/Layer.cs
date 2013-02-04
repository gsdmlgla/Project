using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TH
{
    class Layer
    {
        private List<Displayable> displayables = new List<Displayable>();
        public List<Displayable> Displayables
        {
            get { return displayables; }
            set { displayables = value; }
        }
        public void Add(Displayable d)
        {
            displayables.Add(d);
        }
        public void draw()
        {
            for (int i = 0; i < displayables.Count; ++i)
            {
                displayables[i].draw();
            }
        }
    }
}
