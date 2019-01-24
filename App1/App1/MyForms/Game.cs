using App1.Controllers;
using App1.Models;
using App1.Services.Towers;
using System;
using System.Windows.Forms;

namespace App1.MyForms
{
    public partial class Game : Form
    {          
        private IGameController controller;
        private FirstSetupModel model;

        public Game(IGameController gameController)
        {
            controller = gameController;
            model = gameController.GetModel();
            InitializeComponent();
            InitView();
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) //To go to menu
        {
            if (keyData == Keys.Escape) //if press esc
            {
                Menu1 MyMenu1 = new Menu1();
                MyMenu1.ShowDialog(); //show menu
                this.Hide(); //this window hide
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void InitView()
        {
            ShowGoldRest();
            ShowTower();
        }

        private void ShowTower()
        {
            pictureBox1.Image = model.TowerType.GetImage();
            Price.Text = model.TowerType.GetPrice().ToString();
        }

        private void ShowGoldRest()
        {
            CurrentGold.Text = model.GoldRest.ToString();
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            controller.NextTower();
            model = controller.GetModel();
            ShowTower();
            ShowGoldRest();
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            controller.PreviousTower();
            model = controller.GetModel();
            ShowTower();
            ShowGoldRest();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Price_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            controller.AddKnight(MyKnights.BROWED_NINJA);
            model = controller.GetModel();
            ShowGoldRest();
            controller.GroupKnights(MyKnights.BROWED_NINJA, Ninja);
        }
        private void Knight35_Click(object sender, EventArgs e)
        {
            controller.AddKnight(MyKnights.HOMELESS_WITH_AX);
            model = controller.GetModel();
            ShowGoldRest();
            controller.GroupKnights(MyKnights.HOMELESS_WITH_AX, Ax);
        }
        private void Knight50_Click(object sender, EventArgs e)
        {
            controller.AddKnight(MyKnights.BALROG_PARODY);
            model = controller.GetModel();
            ShowGoldRest();
            controller.GroupKnights(MyKnights.BALROG_PARODY, Parody);
        }
        private void Knight10_Click(object sender, EventArgs e)
        {
            controller.AddKnight(MyKnights.JEALOUS_TEEN);
            model = controller.GetModel();
            ShowGoldRest();
            controller.GroupKnights(MyKnights.JEALOUS_TEEN, Teen);
        }
        private void Knight100_Click(object sender, EventArgs e)
        {
            controller.AddKnight(MyKnights.PRINCESS_WITH_EGGS);
            model = controller.GetModel();
            ShowGoldRest();
            controller.GroupKnights(MyKnights.PRINCESS_WITH_EGGS, Princess);
        }

        private void Ready_Click(object sender, EventArgs e)
        {
            this.Hide(); //this window hide    
            controller.ToFight();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
