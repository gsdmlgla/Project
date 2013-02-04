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
        public int currentLoopID;
        private void button1_Click(object sender, EventArgs e)
        {
            Sound s = new Sound("C:\\Users\\Cirno\\Downloads\\test1.wav");
            currentLoopID = SoundPlayer.playInLoop(s);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer.stopLoop(currentLoopID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sound s = new Sound("C:\\Users\\Cirno\\Desktop\\TH\\Project\\TH\\bowow.wav");
            SoundPlayer.play(s);
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void mainForm_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        
    }
}
