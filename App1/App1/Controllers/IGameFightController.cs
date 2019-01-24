using App1.Models;
using App1.Services.Evils;
using App1.Services.Towers;
using System.Drawing;
using System.Windows.Forms;

namespace App1.Controllers
{
    public interface IGameFightController
    {
        GameModel GetModel();
        int GetNumberOfKnight(MyKnights knight);
        int GetMyMoney();
        int GetMyVictoryMoney();
        Point MovePicture(MyKnights knight);
        Point MoveHP(MyKnights knight);
        Point FightEv(MyEvil evil);
        Point FightKnight(MyKnights knight);
        Point MoveHPEvFight(MyEvil evil);
        Point MoveHPKn(MyKnights knight);
        Point MovePictureEv(MyEvil evil);
        Point MoveHPEv(MyEvil evil);
        void AddKnight(MyKnights knight);
        void SelectTower();
        int HPshka(MyKnights knights);
        Point StartPoints(MyKnights knight);
        Point StartPointsBar(MyKnights knight);
        void HandleKnightsMoving(MyKnights knighrt);
        void MoveEnabling(MyKnights knight);
        void MoveDisabling(MyKnights knight);
        void HandleEvilsMoving(MyEvil evil, bool IsMoving);
        void MoveEnabling(MyEvil evil);
        void MoveDisabling(MyEvil evil);
        void DecreaseKnightHP(MyKnights knight, int damage);
        void DecreaseEvilHP(MyEvil evil, int damage);
        void stopAll();
    }
}
