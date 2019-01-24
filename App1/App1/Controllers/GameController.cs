using App1.Models;
using App1.MyForms;
using App1.Services.Logger;
using App1.Services.Towers;
using System;
using System.Windows.Forms;

namespace App1.Controllers
{
    class GameController : IGameController
    {
        private FirstSetupModel model;
        private IGameFightController gameFightController;
        private ILogger logger;

        public GameController()
        {
            model = new FirstSetupModel();
            logger = new Logger();
        }

        public void AddKnight(MyKnights knight)
        {          
            if (model.GoldRest >= knight.GetPrice()) {
                model.GoldRest -= knight.GetPrice();
                model.Knights[knight]++;
            }           
        }

        public FirstSetupModel GetModel()
        {
            return model;
        }

        public void NextTower()
        {
            model.GoldRest += model.TowerType.GetPrice();
            model.TowerType = model.TowerType.Next();
            model.GoldRest -= model.TowerType.GetPrice();
        }

        public void PreviousTower()
        {
            model.GoldRest += model.TowerType.GetPrice();
            model.TowerType = model.TowerType.Previous();
            model.GoldRest -= model.TowerType.GetPrice();
        }

        public void ToFight()
        {
            gameFightController = new GameFightController(new GameModel(model.Knights) {
                myTower = model.TowerType, UsersGold = model.GoldRest
            });
            
            GameFight MyMenu1 = new GameFight(gameFightController);
            MyMenu1.ShowDialog();     
        }

        public void GroupKnights (MyKnights knight, TextBox textBox)
        {
            textBox.Visible = true;
            textBox.Text = (model.Knights[knight]).ToString();
        }
    }
}
