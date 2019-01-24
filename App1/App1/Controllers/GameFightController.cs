using System.Windows.Forms;
using App1.Models;
using App1.Services.Towers;
using System.Drawing;
using System.Media;
using App1.Services.Evils;
using System;
using App1.Services.Logger;

namespace App1.Controllers
{
    class GameFightController : IGameFightController
    {
        private GameModel gameModel;
        private ILogger logger;
        
        public GameModel GetModel()
        {
            return gameModel;
        }
        public GameFightController(GameModel gameModel)
        {
            this.gameModel = gameModel;
            logger = new Logger();
        }
        public int GetNumberOfKnight (MyKnights knight)
        {
            return gameModel.Knight[knight].NumberOfKnights;           
        }
        public int GetMyMoney()
        {
            return gameModel.UsersGold;
        }
        public int GetMyVictoryMoney()
        {
            gameModel.UsersGold += 20;
            logger.LogCurrentGold(gameModel.UsersGold);
            return gameModel.UsersGold;
        }
        public Point MovePicture (MyKnights knight)
        {
            if (gameModel.Knight[knight].IsGoing)
            {
                gameModel.Knight[knight].PointForKnight.X += 3;
                logger.LogMovementOfKnight(gameModel.Knight[knight], knight);
            }
            return gameModel.Knight[knight].PointForKnight;
        }
        public Point MoveHP(MyKnights knight)
        {
            if(gameModel.Knight[knight].IsGoing)
            {
                gameModel.Knight[knight].PointForHp.X += 3;
            }
            return gameModel.Knight[knight].PointForHp;
        }
        public Point MovePictureEv(MyEvil evil)
        {
            gameModel.Evil[evil].pointForEvil.X-=3;
            logger.LogMovementOfEvil(gameModel.Evil[evil]);
            return gameModel.Evil[evil].pointForEvil;
        }
        public Point MoveHPEv(MyEvil evil)
        {
            gameModel.Evil[evil].pointForHp.X -=3;
            return gameModel.Evil[evil].pointForHp;
        }
        public Point FightEv(MyEvil evil)
        {
            gameModel.Evil[evil].pointForEvil.X += 9;
            logger.LogEvilFight(gameModel.Evil[evil]);
            return gameModel.Evil[evil].pointForEvil;
        }
        public Point FightKnight(MyKnights knight)
        {
            gameModel.Knight[knight].PointForKnight.X -= 9;
            logger.LogKnightFight(gameModel.Knight[knight], knight);
            return gameModel.Knight[knight].PointForKnight;
        }
        public Point MoveHPEvFight(MyEvil evil)
        {
            gameModel.Evil[evil].pointForHp.X += 9;
            return gameModel.Evil[evil].pointForHp;
        }
        public Point MoveHPKn(MyKnights knight)
        {
            gameModel.Knight[knight].PointForHp.X -= 9;
            return gameModel.Knight[knight].PointForHp;
        }
        public int HPshka (MyKnights knights)
        {
            return gameModel.Knight[knights].HealthPoints;
        }
        public void AddKnight(MyKnights knight)
        {
            if (gameModel.UsersGold >= knight.GetPrice())
            {
                gameModel.UsersGold -= knight.GetPrice();
                gameModel.Knight[knight].NumberOfKnights++;
                gameModel.Knight[knight].HealthPoints += 100;
            }
        }
        public void SelectTower()
        {
            gameModel.UsersGold += gameModel.myTower.GetPrice();
            gameModel.myTower = gameModel.myTower.Next();
            gameModel.UsersGold -= gameModel.myTower.GetPrice();
        }
        public int HPTower()
        {
            return gameModel.TowersHealth;
        }
        public Point StartPoints(MyKnights knight)
        {
            return gameModel.Knight[knight].PointForKnightStart;
        }
        public Point StartPointsBar(MyKnights knight)
        {
            return gameModel.Knight[knight].PointForHpStart;
        }

        public void HandleKnightsMoving(MyKnights knight)
        {
            gameModel.Knight[knight].IsGoing = !gameModel.Knight[knight].IsGoing;
        }

        public void MoveEnabling(MyKnights knight)
        {
            gameModel.Knight[knight].IsGoing = true;
        }

        public void MoveDisabling(MyKnights knight)
        {
            gameModel.Knight[knight].IsGoing = false;
        }

        public void HandleEvilsMoving(MyEvil evil, bool IsMoving)
        {
            gameModel.Evil[evil].IsMoving = IsMoving;
        }

        public void MoveEnabling(MyEvil evil)
        {
            gameModel.Evil[evil].IsMoving = true;
        }

        public void MoveDisabling(MyEvil evil)
        {
            gameModel.Evil[evil].IsMoving = false;
        }
        public void Draka()
        {

        }

        public void DecreaseKnightHP(MyKnights knight, int damage)
        {
            KnightInGame targetKnight = gameModel.Knight[knight];
            int scheduledHP = targetKnight.HealthPoints - damage;
            int edgeHP = (targetKnight.NumberOfKnights - 1) * 100;
            if(scheduledHP > 0)
            { 
                if (scheduledHP < edgeHP)
                {
                    targetKnight.NumberOfKnights--;
                }
                targetKnight.HealthPoints = scheduledHP;
                CountPresentationHP(knight);
            }
            else
            {
                targetKnight.NumberOfKnights = 0;
                targetKnight.HealthPoints = 0;
                targetKnight.PresentationHP = 0;
            }
        }

        private void CountPresentationHP(MyKnights knight)
        {
            KnightInGame targetKnight = gameModel.Knight[knight];
            int scheduledHP = targetKnight.HealthPoints - (targetKnight.NumberOfKnights - 1) * 100;
            int resultHP = scheduledHP;
            if(scheduledHP == 0)
            {
                if (targetKnight.NumberOfKnights != 0)
                {
                    resultHP = 100;
                }
                else
                {
                    resultHP = 0;
                }
            }
            targetKnight.PresentationHP = resultHP;
        }

        private void CountPresentationHP(MyEvil evil)
        {
            EvilInGame targetEvil = gameModel.Evil[evil];
            int scheduledHP = targetEvil.HealthPoints - (targetEvil.NumberOfEvil - 1) * 100;
            int resultHP = scheduledHP;
            if (scheduledHP == 0)
            {
                if (targetEvil.NumberOfEvil != 0)
                {
                    resultHP = 100;
                }
                else
                {
                    resultHP = 0;
                }
            }
            targetEvil.PresentationHP = resultHP;
        }

        public void DecreaseEvilHP(MyEvil evil, int damage)
        {
            EvilInGame targetEvil = gameModel.Evil[evil];
            int scheduledHP = targetEvil.HealthPoints - damage;
            int edgeHP = (targetEvil.NumberOfEvil - 1) * 100;
            if (scheduledHP > 0)
            {
                if (scheduledHP < edgeHP)
                {
                    targetEvil.NumberOfEvil--;
                }
                targetEvil.HealthPoints = scheduledHP;
                CountPresentationHP(evil);
            }
            else
            {
                targetEvil.NumberOfEvil = 0;
                targetEvil.HealthPoints = 0;
                targetEvil.PresentationHP = 0;
            }
        }

        public void stopAll()
        {
            foreach(EvilInGame evil in gameModel.Evil.Values)
            {
                evil.IsMoving = false;
            }
            foreach(KnightInGame knight in gameModel.Knight.Values)
            {
                knight.IsGoing = false;
            }
        }
    }
}
