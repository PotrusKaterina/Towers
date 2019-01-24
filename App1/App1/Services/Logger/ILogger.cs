using App1.Services.Evils;
using App1.Services.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services.Logger
{
    public interface ILogger
    {
        void LogException(Exception ex);
        void LogInfo(string message);
        void LogGameStart();
        void LogUserWins();
        void LogUserLoses();
        void LogMovementOfKnight(KnightInGame knight, MyKnights knightType);
        void LogMovementOfEvil(EvilInGame evil);
        void LogKnightFight(KnightInGame knight, MyKnights knightType);
        void LogEvilFight(EvilInGame evil);
        void LogCurrentGold(int gold);
        void LogShopEntering();
        void LogKnightBuying(MyKnights knight, int goldLeft);
        void LogShopClosing();
    }
}
