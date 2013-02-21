using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TH
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Screen.stop();
            //wait for the thread to finish it's work
            while (Program.game.artist.IsAlive) ;
        }

        private void Window_Paint(object sender, PaintEventArgs e)
        {
            //fill in the initial background
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, 800, 600);
        }
    }
}
