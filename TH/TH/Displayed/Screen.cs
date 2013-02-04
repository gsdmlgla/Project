using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TH
{
    class Screen
    {
        private static Graphics graphic;
        public static Graphics g
        {
            get 
            {
                if (graphic == null)
                {
                    throw new NullReferenceException("Please call init()");
                }
                return graphic; 
            }
        }

        private static List<Layer> layers;
        public static List<Layer> Layers
        {
            get { return layers; }
            set { layers = value; }
        }

        public static void Init(IntPtr hwnd)
        {
            graphic = Graphics.FromHwnd(hwnd);
        }

        public static void draw()
        {
            for (int i = 0; i < layers.Count; ++i)
            {
                layers[i].draw();
            }
        }
    }
}
