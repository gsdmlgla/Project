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

        private void Window_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = new SolidBrush(Color.PowderBlue);
            g.FillRectangle(b,200,0,400,600);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Screen.stop();
        }
    }
}
