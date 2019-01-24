using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Services.Evils;
using App1.Services.Towers;

namespace App1.Services.Logger
{
    class Logger: ILogger
    {

        string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Logs/logs.txt");

        public void LogCurrentGold(int gold)
        {
            LogInfo(string.Format("Current gold: {0} coins", gold));   
        }

        public void LogEvilFight(EvilInGame evil)
        {
            LogInfo(string.Format("Evil was attacked: POSITION: [ X: {0} Y: {1} ], HP left: {2}, Number of evils: {3}", evil.pointForEvil.X, evil.pointForEvil.Y, evil.HealthPoints, evil.NumberOfEvil));
        }

        public void LogException(Exception ex)
        {
            LogModel log = new LogModel(TypeOfLog.EXCEPTION, ex.Message);
            FileWrite(log.ToString());
        }

        public void LogGameStart()
        {
            LogInfo("GAME STARTED");
        }

        public void LogInfo(string message)
        {
            LogModel log = new LogModel(TypeOfLog.INFO, message);
            FileWrite(log.ToString());
        }

        public void LogKnightBuying(MyKnights knight, int goldLeft)
        {
            LogInfo(string.Format("Knight {0} was bought, gold left: {1} coins", knight.GetStringValue(), goldLeft));
        }

        public void LogKnightFight(KnightInGame knight, MyKnights knightType)
        {
            LogInfo(string.Format("Knight {0} was attacked: POSITION: [ X: {1}, Y: {2} ], HP left: {3}, Number of such knights: {4}", knightType.GetStringValue(), knight.PointForKnight.X, knight.PointForKnight.Y, knight.HealthPoints, knight.NumberOfKnights));
        }

        public void LogMovementOfEvil(EvilInGame evil)
        {
            LogInfo(string.Format("Evil moved: POSITION: [ X: {0} Y: {1} ], HP left: {2}, Number of evils: {3}", evil.pointForEvil.X, evil.pointForEvil.Y, evil.HealthPoints, evil.NumberOfEvil));
        }

        public void LogMovementOfKnight(KnightInGame knight, MyKnights knightType)
        {
            LogInfo(string.Format("Knight {0} moved: POSITION: [ X: {1}, Y: {2} ], HP left: {3}, Number of such knights: {4}", knightType.GetStringValue(), knight.PointForKnight.X, knight.PointForKnight.Y, knight.HealthPoints, knight.NumberOfKnights));
        }

        public void LogShopClosing()
        {
            LogInfo("Shop was closed");
        }

        public void LogShopEntering()
        {
            LogInfo("Shop was opened");
        }

        public void LogUserLoses()
        {
            LogInfo("User lost");
        }

        public void LogUserWins()
        {
            LogInfo("User won");
        }

        private void FileWrite(string message)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, 4096, true))
            using (StreamWriter sw = new StreamWriter(stream))
            {
                sw.WriteLine(message);
            }
        }
    }
}
