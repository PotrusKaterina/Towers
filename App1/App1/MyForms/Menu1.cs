using App1.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App1.MyForms
{
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Game Game1 = new Game(new GameController());
            Game1.ShowDialog();
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //To go to menu
        {
            Game Game1 = new Game(new GameController());
            if (keyData == Keys.Escape) //if press esc
            {
                Game1.ShowDialog(); //show game
                this.Close(); //close window 
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
