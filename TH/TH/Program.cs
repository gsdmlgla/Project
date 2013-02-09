using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Window win = new Window();
            Game g = new Game(win);
            g.start();
            Application.Run(win);
        }
    }
}
