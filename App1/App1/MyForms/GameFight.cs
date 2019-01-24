using App1.Controllers;
using App1.Models;
using App1.Services.Towers;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using App1.Services.Evils;
using App1.Services.Logger;
using System.IO;

namespace App1.MyForms
{
    public partial class GameFight : Form
    {
        private IGameFightController gameFightController;
        private GameModel gameModel;
        private bool isShopActive = false;
        private ILogger logger;


        public GameFight(IGameFightController gameFightController)
        {
            this.gameFightController = gameFightController;
            gameModel = gameFightController.GetModel();
            InitializeComponent();
            logger = new Logger();
            GetImages();
            GetOpenImageOfKnight();
            CurrentGold.Text = gameFightController.GetMyMoney().ToString();
            Music(false);
            SetLifes();
            SetTowerLife();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
        {
            if (keyData == Keys.Escape)
            {
                Menu1 MyMenu1 = new Menu1(); 
                MyMenu1.ShowDialog();
                //Hide(); 
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GameFight_Load(object sender, EventArgs e)
        {

        }

        private void Teen_Click(object sender, EventArgs e)
        {
            HandleKnightClick(MyKnights.JEALOUS_TEEN);
        }

        private void Barlog_Click(object sender, EventArgs e)
        {
            HandleKnightClick(MyKnights.BALROG_PARODY);
        }

        private void PrincessWith_Click(object sender, EventArgs e)
        {
            HandleKnightClick(MyKnights.PRINCESS_WITH_EGGS);
        }

        private void Ax_Click(object sender, EventArgs e)
        {
            HandleKnightClick(MyKnights.HOMELESS_WITH_AX);
        }

        private void Browed_Click(object sender, EventArgs e)
        {
            HandleKnightClick(MyKnights.BROWED_NINJA);
        }

        private void HandleKnightClick(MyKnights knight)
        {
            if (Loser.Visible == false)
            {
                if(!isShopActive)
                {
                    HandleKnightMoving(knight);
                    UpdateModel();
                    HandleEvilWhenKnightClicked(gameModel.Knight[knight].IsGoing, EvilOfKnight(knight));
                    UpdateModel();
                }
                ShopList(knight);
            }
        }

        private void HandleEvilWhenKnightClicked(bool isKnightMoving, MyEvil evil)
        {
            gameFightController.HandleEvilsMoving(evil, isKnightMoving);
        }

        private void HandleKnightMoving(MyKnights knight)
        {
            gameFightController.HandleKnightsMoving(knight);
        }

        private void GetImages()
        {
            TowerUser.Image = gameModel.myTower.GetImage(); 
        }

        private void timerEvilsMoving_Tick(object sender, EventArgs e)
        {
            TimerForEverybody(timerNinja, MyKnights.BROWED_NINJA, Browed, forNinja, MyEvil.EVIL1, evil1, forEvil1);
            if (Browed.Visible == true)
            {
                FightWithAll(MyKnights.BROWED_NINJA, Browed, 20, forNinja, 25);
            }
            else
            {
                FightWithAllEvil(MyEvil.EVIL1, evil1, forEvil1, 20, 25);
            }
        }

        private void timerPrincess_Tick(object sender, EventArgs e)
        {
            TimerForEverybody(timerPrincess, MyKnights.PRINCESS_WITH_EGGS, PrincessWith, forPrincess, MyEvil.EVIL2, evil2, forEvil2);
            if (PrincessWith.Visible == true)
            {
                FightWithAll(MyKnights.PRINCESS_WITH_EGGS, PrincessWith, 5, forPrincess, 35);
            }
            else
            {
                FightWithAllEvil(MyEvil.EVIL2, evil2, forEvil2, 5, 35);
            }
        }

        private void timerTeen_Tick(object sender, EventArgs e)
        {
            TimerForEverybody(timerTeen, MyKnights.JEALOUS_TEEN, Teen, forTeen, MyEvil.EVIL3, evil3, forEvil3);
            if (Teen.Visible == true)
            {
                FightWithAll(MyKnights.JEALOUS_TEEN, Teen, 25, forTeen, 10);
            }
            else
            {
                FightWithAllEvil(MyEvil.EVIL3, evil3, forEvil3, 25, 10);
            }
        }

        private void timerBalrog_Tick(object sender, EventArgs e)
        {
            TimerForEverybody(timerBalrog, MyKnights.BALROG_PARODY, Barlog, forBarlog, MyEvil.EVIL4, evil4, forEvil4);
            if (Barlog.Visible == true)
            {
                FightWithAll(MyKnights.BALROG_PARODY, Barlog, 10, forBarlog, 25);
            }
            else
            {
                FightWithAllEvil(MyEvil.EVIL4, evil4, forEvil4, 10, 25);
            }
        }

        private void timerAx_Tick(object sender, EventArgs e)
        {
            TimerForEverybody(timerAx, MyKnights.HOMELESS_WITH_AX, Ax, forAx, MyEvil.EVIL5, evil5, forEvil5);
            if (Ax.Visible == true)
            {
                FightWithAll(MyKnights.HOMELESS_WITH_AX, Ax, 25, forAx, 35);
            }
            else
            {
                FightWithAllEvil(MyEvil.EVIL5, evil5, forEvil5, 25, 35);
            }
        }
        private void StopAllTimers()
        {
            timerNinja.Stop();
            timerAx.Stop();
            timerBalrog.Stop();
            timerTeen.Stop();
            timerPrincess.Stop();
        }
        private void StartAllTimers()
        {
            timerNinja.Start();
            timerAx.Start();
            timerBalrog.Start();
            timerTeen.Start();
            timerPrincess.Start();
        }
        private void Music(bool Number)
        {
            string fileMusic = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Resources\\Fairy_Tail_OST_Dolly_theme.wav");
            SoundPlayer musicPlayer = new SoundPlayer(fileMusic);
            musicPlayer.Play();
            if (Number == true)
            {
                musicPlayer.Play();
            }
        }
        private void TimerForEverybody(Timer timer, MyKnights knight, PictureBox pictureBox, ProgressBar progressBar, MyEvil evil, PictureBox pictureEvil, ProgressBar progressEvil)
        {
            timer.Interval = 100;
            if(gameModel.Knight[knight].IsGoing)
            {
                gameFightController.MovePicture(knight);
                gameFightController.MoveHP(knight);
            }
            if(gameModel.Evil[evil].IsMoving)
            {
                 gameFightController.MovePictureEv(evil);
                 gameFightController.MoveHPEv(evil);
            }           
            UpdateModel();
            pictureBox.Location = gameModel.Knight[knight].PointForKnight;
            progressBar.Location = gameModel.Knight[knight].PointForHp;
            pictureEvil.Location = gameModel.Evil[evil].pointForEvil;
            progressEvil.Location = gameModel.Evil[evil].pointForHp;
        }
        private void GetOpenImageOfKnight()
        {
            VizibleKnight(Ax, lAx, MyKnights.HOMELESS_WITH_AX, forAx);
            VizibleKnight(Browed, lNinja, MyKnights.BROWED_NINJA, forNinja);
            VizibleKnight(Barlog, lParody, MyKnights.BALROG_PARODY, forBarlog);
            VizibleKnight(Teen, lTeen, MyKnights.JEALOUS_TEEN, forTeen);
            VizibleKnight(PrincessWith, lPrincess, MyKnights.PRINCESS_WITH_EGGS, forPrincess);
        }
        private void VizibleKnight(PictureBox pictureBox, Label label, MyKnights my, ProgressBar progressBar)
        {
            if (gameFightController.GetNumberOfKnight(my) <= 0)
            {
                pictureBox.Visible = false;
                progressBar.Visible = false;
            }
            else
            {
                progressBar.Visible = true;
            }
        }
        private void VizibleEvil(PictureBox pictureBox, MyEvil evil, ProgressBar progressBar)
        {
            if (gameModel.Evil[evil].NumberOfEvil <= 0)
            {
                pictureBox.Visible = false;
                progressBar.Visible = false;
            }
            else
            {
                progressBar.Visible = true;
            }
        }
        private void SetLifes()
        {
            Lifes(MyKnights.BALROG_PARODY, forBarlog, Barlog);
            Lifes(MyKnights.BROWED_NINJA, forNinja, Browed);
            Lifes(MyKnights.HOMELESS_WITH_AX, forAx, Ax);
            Lifes(MyKnights.JEALOUS_TEEN, forTeen, Teen);
            Lifes(MyKnights.PRINCESS_WITH_EGGS, forPrincess, PrincessWith);
        }
        private void Near(MyKnights knight, PictureBox evil, PictureBox pictureBox, int hit, ProgressBar progressBar, MyEvil evils, ProgressBar Forevil, int hitEvil)
        {
            if ((evil.Visible == true)&&(pictureBox.Visible == true))
            {
                if ((Math.Abs(gameModel.Knight[knight].PointForKnight.X - gameModel.Evil[evils].pointForEvil.X)) <= 1)
                {
                    gameFightController.MoveEnabling(knight);
                    gameFightController.MoveEnabling(evils);
                    UpdateModel();
                    gameFightController.FightEv(evils);
                    gameFightController.FightKnight(knight);
                    gameFightController.MoveHPEvFight(evils);
                    gameFightController.MoveHPKn(knight);
                    UpdateModel();
                    evil.Location = gameModel.Evil[evils].pointForEvil;
                    Forevil.Location = gameModel.Evil[evils].pointForHp;
                    pictureBox.Location = gameModel.Knight[knight].PointForKnight;
                    progressBar.Location = gameModel.Knight[knight].PointForHp;
                    Hit(knight, pictureBox, hit, progressBar);
                    EvilHP(Forevil, hitEvil, evil, evils);              
                }
            }
        }
        private void FightWithAll(MyKnights knight, PictureBox pictureBoxKnight, int hitKnight, ProgressBar progressBarKnight, int hitEvil)
        {
            Near(knight, evil1, pictureBoxKnight, hitKnight, progressBarKnight, MyEvil.EVIL1, forEvil1, hitEvil); BreakTower(MyEvil.EVIL1, evil1);
            Near(knight, evil2, pictureBoxKnight, hitKnight, progressBarKnight, MyEvil.EVIL2, forEvil2, hitEvil); BreakTower(MyEvil.EVIL2, evil2);
            Near(knight, evil3, pictureBoxKnight, hitKnight, progressBarKnight, MyEvil.EVIL3, forEvil3, hitEvil); BreakTower(MyEvil.EVIL3, evil3);
            Near(knight, evil4, pictureBoxKnight, hitKnight, progressBarKnight, MyEvil.EVIL4, forEvil4, hitEvil); BreakTower(MyEvil.EVIL4, evil4);
            Near(knight, evil5, pictureBoxKnight, hitKnight, progressBarKnight, MyEvil.EVIL5, forEvil5, hitEvil); BreakTower(MyEvil.EVIL5, evil5);
            BreakTower(knight, pictureBoxKnight);
        }
        private void FightWithAllEvil(MyEvil evil, PictureBox pictureBoxEvil, ProgressBar progressBarEvil, int hitKnight, int hitEvil)
        {
            Near(MyKnights.BALROG_PARODY, pictureBoxEvil, Barlog, hitKnight, forBarlog, evil, progressBarEvil, hitEvil); BreakTower(MyKnights.BALROG_PARODY, Barlog);
            Near(MyKnights.BROWED_NINJA, pictureBoxEvil, Browed, hitKnight, forNinja, evil, progressBarEvil, hitEvil); BreakTower(MyKnights.BROWED_NINJA, Browed);
            Near(MyKnights.HOMELESS_WITH_AX, pictureBoxEvil, Ax, hitKnight, forAx, evil, progressBarEvil, hitEvil); BreakTower(MyKnights.HOMELESS_WITH_AX, Ax);
            Near(MyKnights.JEALOUS_TEEN, pictureBoxEvil, Teen, hitKnight, forTeen, evil, progressBarEvil, hitEvil); BreakTower(MyKnights.JEALOUS_TEEN, Teen);
            Near(MyKnights.PRINCESS_WITH_EGGS, pictureBoxEvil, PrincessWith, hitKnight, forPrincess, evil, progressBarEvil, hitEvil); BreakTower(MyKnights.PRINCESS_WITH_EGGS, PrincessWith);
            BreakTower(evil, pictureBoxEvil);
        }
        private void AllPictures()
        {
            Ax.Visible = true;
            PrincessWith.Visible = true;
            Browed.Visible = true;
            Teen.Visible = true;
            Barlog.Visible = true;
        }
        private void Shop_Click(object sender, EventArgs e)
        { 
            Shop.Visible = false;
            ShopClose.Visible = true;
            StopAllTimers();
            AllPictures();
            isShopActive = true;
        }
        private void ShopClose_Click(object sender, EventArgs e)
        {
            ShopClose.Visible = false;
            Shop.Visible = true;
            SetLifes();
            GetImages();
            StartAllTimers();
            GetOpenImageOfKnight();
            isShopActive = false;
        }

        private void ShopList(MyKnights knight)
        {
            if (ShopClose.Visible == true)
            {
                gameFightController.AddKnight(knight);
                CurrentGold.Text = gameFightController.GetMyMoney().ToString();
            }
        }

        private void TowerUser_Click(object sender, EventArgs e)
        {
        
        }
        private void ShowTower()
        {
            TowerUser.Image = gameModel.myTower.GetImage();
            CurrentGold.Text = gameModel.myTower.GetPrice().ToString();
        }
        public void Lifes(MyKnights knights, ProgressBar progressBar, PictureBox picture)
        {
            int scheduledHP = gameModel.Knight[knights].PresentationHP;
            if (scheduledHP > 0)
            {
                progressBar.Value = scheduledHP;
            }
            else
            {
                progressBar.Visible = false;
                picture.Visible = false;
                gameFightController.MoveDisabling(knights);
            }
        }
        public void Lifes(MyEvil evil, ProgressBar progressBar, PictureBox picture)
        {
            int scheduledHP = gameModel.Evil[evil].HealthPoints;
            if (scheduledHP % 100 != 0)
            {
                progressBar.Value = gameModel.Evil[evil].PresentationHP;
            }
            else
            {                
                CurrentGold.Text = gameFightController.GetMyVictoryMoney().ToString();
            }
            if(scheduledHP == 0)
            {
                progressBar.Visible = false;
                picture.Visible = false;
                gameFightController.MoveDisabling(evil);
            }
        }

        public void Hit(MyKnights knight, PictureBox pictureBox, int hit, ProgressBar progressBar)
        {
            gameFightController.DecreaseKnightHP(knight, hit);
            UpdateModel();
            Lifes(knight, progressBar, pictureBox);
        }

        private void SetTowerLife()
        {
            forTower.Value = gameModel.TowersHealth;
        }

        private void BreakTower(MyEvil evil, PictureBox pictureEvil)
        {
            if (pictureEvil.Visible == true)
            {
                if (Math.Abs(TowerUser.Location.X + TowerUser.Width - gameModel.Evil[evil].pointForEvil.X) <= 1)
                {
                    gameFightController.FightEv(evil); gameFightController.MoveHPEvFight(evil);
                    if (forTower.Value > 5)
                    {
                        forTower.Value -= 5;
                    }
                    else
                    {
                        StopAllTimers();
                        Loser.Visible = true;
                        logger.LogUserLoses();
                    }
                }
            }
        }
        private void BreakTower(MyKnights knight, PictureBox pictureKnight)
        {
            if (pictureKnight.Visible == true)
            {
                if (Math.Abs(teleport.Location.X + teleport.Width - gameModel.Knight[knight].PointForKnight.X) <= 1)
                {
                    gameFightController.FightKnight(knight); gameFightController.MoveHPKn(knight);
                    if (forTeleport.Value > 5)
                    {
                        forTeleport.Value -= 5;
                    }
                    else
                    {
                        StopAllTimers();
                        ItsWin.Visible = true;
                        logger.LogUserWins();
                    }
                }
            }
        }

        private void EvilHP(ProgressBar evilBar, int hit, PictureBox evilPicture, MyEvil evil)
        {
            gameFightController.DecreaseEvilHP(evil, hit);
            UpdateModel();
            Lifes(evil, evilBar, evilPicture);
        }

        void UpdateModel()
        {
            gameModel = gameFightController.GetModel();
        }

        public MyEvil EvilOfKnight(MyKnights knight)
        {
            switch (knight) {
                case MyKnights.BALROG_PARODY: return MyEvil.EVIL4;
                case MyKnights.HOMELESS_WITH_AX: return MyEvil.EVIL5;
                case MyKnights.BROWED_NINJA: return MyEvil.EVIL1;
                case MyKnights.JEALOUS_TEEN: return MyEvil.EVIL3;
                case MyKnights.PRINCESS_WITH_EGGS: return MyEvil.EVIL2;
                default: return MyEvil.EVIL1;
            }
        }
    }
}
