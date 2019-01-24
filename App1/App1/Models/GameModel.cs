using App1.Services.Evils;
using App1.Services.Towers;
using System.Collections.Generic;
using System.Drawing;

namespace App1.Models
{
    public class GameModel
    {
        public MyTowers myTower { get; set; }
        public Dictionary <MyKnights, KnightInGame> Knight { get; set; }
        public Dictionary<MyEvil, EvilInGame> Evil { get; set; }
        public Dictionary<MyKnights, Point> StartPosition { get; set; }
        public int UsersGold { get; set; }
        public int TowersHealth { get; set; }

        public GameModel(Dictionary<MyKnights, int> knightsNumber)
        {
            Knight = new Dictionary<MyKnights, KnightInGame>();
            Knight[MyKnights.BALROG_PARODY] = new KnightInGame(knightsNumber[MyKnights.BALROG_PARODY], new Point(225, 408), new Point (225,395));
            Knight[MyKnights.BROWED_NINJA] = new KnightInGame(knightsNumber[MyKnights.BROWED_NINJA], new Point(170, 361),new Point(176, 349));
            Knight[MyKnights.HOMELESS_WITH_AX] = new KnightInGame(knightsNumber[MyKnights.HOMELESS_WITH_AX], new Point(272, 408), new Point(272,395));
            Knight[MyKnights.JEALOUS_TEEN] = new KnightInGame(knightsNumber[MyKnights.JEALOUS_TEEN], new Point(272, 361), new Point(272, 349));
            Knight[MyKnights.PRINCESS_WITH_EGGS] = new KnightInGame(knightsNumber[MyKnights.PRINCESS_WITH_EGGS], new Point(225, 361), new Point(225,349));
            Evil = new Dictionary<MyEvil, EvilInGame>();
            Evil[MyEvil.EVIL1] = new EvilInGame(knightsNumber[MyKnights.BROWED_NINJA], new Point(1171, 361), new Point(1171, 349));
            Evil[MyEvil.EVIL2] = new EvilInGame(knightsNumber[MyKnights.PRINCESS_WITH_EGGS], new Point(1220, 361), new Point(1220, 395));
            Evil[MyEvil.EVIL3] = new EvilInGame(knightsNumber[MyKnights.JEALOUS_TEEN], new Point(1267,361), new Point(1267,349));
            Evil[MyEvil.EVIL4] = new EvilInGame(knightsNumber[MyKnights.BALROG_PARODY], new Point(1220,408), new Point(1220,395));
            Evil[MyEvil.EVIL5] = new EvilInGame(knightsNumber[MyKnights.HOMELESS_WITH_AX], new Point(1267, 408), new Point(1267, 395));
            TowersHealth = 100;
        }
    }
}
