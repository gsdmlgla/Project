using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace TH
{
    class Screen
    {
        #region datamembers
        /// <summary>
        /// flag to signal a quit;
        /// </summary>
        private static bool quit = false;
        /// <summary>
        /// is the thread running flag
        /// </summary>
        public static bool running
        {
            get { return !quit; }
            set { quit = !value; }
        }
        /// <summary>
        /// holds the window's graphics object
        /// </summary>
        private static Graphics graphic;
        /// <summary>
        /// graphics object getter
        /// </summary>
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
        #endregion

        /// <summary>
        /// screen constructor that gets the window's graphics object
        /// </summary>
        /// <param name="hwnd">window's handle</param>
        public Screen(IntPtr hwnd)
        {
            graphic = Graphics.FromHwnd(hwnd);
        }

        #region methods
        /// <summary>
        /// stops the thread
        /// </summary>
        public static void stop()
        {
            quit = true;
        }

        /// <summary>
        /// draw the screen in a separate thread
        /// </summary>
        public void thread()
        {
            Brush b = new SolidBrush(Color.BlueViolet);
            Brush d = new SolidBrush(Color.Chartreuse);
            System.Diagnostics.Stopwatch wait = new System.Diagnostics.Stopwatch();

            Font f = new Font(FontFamily.GenericMonospace, 20, FontStyle.Bold);
            Image img = new Bitmap(600,600);

            //how big are the gridsquares
            int gridSquareSize = 1;

            //the rectangle array to draw stuff on (the number of gridsqares is total screen units / gridsquaressize ^ 2)
            Rectangle[] rects = new Rectangle[240000 / (gridSquareSize * gridSquareSize)];

            //populate the rectangles
            int index = -1;
            for (int x = 0; x < 400; x += gridSquareSize)
            {
                for (int y = 0; y < 600; y += gridSquareSize)
                {
                    rects[++index] = new Rectangle(x + 200, y, gridSquareSize-0, gridSquareSize-0);
                }
            }
            Graphics g = Graphics.FromImage(img);
            wait.Start();
            int R = 0;
            int G = 0;
            int B = 0;
            while (!quit)
            {
                g.FillRectangles(new SolidBrush(Color.FromArgb(R,G,B)), rects);
                graphic.DrawImage(img,new Point(0,0));

                //diagnostic displaying
                graphic.FillRectangle(b, 0, 0, 100, 100);
                graphic.DrawString(wait.ElapsedMilliseconds.ToString(), f, d, new Point(0, 0));
                //end of diagnostic displaying

                //make pretty colors
                
                R += 10;
                G += 100;
                B += 7;
                R %= 255;
                G %= 255;
                B %= 255;
                
                //pretty colors made
                wait.Restart();
            }
        #endregion
        }
    }
}
