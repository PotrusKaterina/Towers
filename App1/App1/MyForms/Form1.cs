using App1.Controllers;
using App1.MyForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            Music();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Game game = new Game(new GameController());
            game.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void Music()
        {
            string fileMusic = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Resources\\HowardShore-MistyMountains.wav");
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = fileMusic;
            musicPlayer.Play();
        }
    }
}
