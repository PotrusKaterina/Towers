using App1.Models;
using App1.Services.Towers;
using System.Windows.Forms;

namespace App1.Controllers
{
    public interface IGameController
    {
        void NextTower();
        void PreviousTower();
        FirstSetupModel GetModel();
        void AddKnight(MyKnights knight);
        void ToFight();
        void GroupKnights(MyKnights knight, TextBox textBox);
    }
}
