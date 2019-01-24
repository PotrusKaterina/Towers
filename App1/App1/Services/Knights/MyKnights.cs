using System.Drawing;


namespace App1.Services.Towers
{
    public enum MyKnights
    {
        JEALOUS_TEEN,
        BROWED_NINJA,
        HOMELESS_WITH_AX,
        BALROG_PARODY,
        PRINCESS_WITH_EGGS
    }

    public static class MyKnightsUseCase
    {
        private const int JEALOUS_TEEN_PRICE = 10;
        private const int BROWED_NINJA_PRICE = 20;
        private const int HOMELESS_WITH_AX_PRICE = 35;
        private const int BALROG_PARODY_PRICE = 50;
        private const int PRINCESS_WITH_EGGS_PRICE = 100;
        private const int NO_PRICE = 0;        

        public static int GetPrice(this MyKnights knight)
        {
            switch (knight)
            {
                case MyKnights.JEALOUS_TEEN:
                    return JEALOUS_TEEN_PRICE;
                case MyKnights.BROWED_NINJA:
                    return BROWED_NINJA_PRICE;
                case MyKnights.HOMELESS_WITH_AX:
                    return HOMELESS_WITH_AX_PRICE;
                case MyKnights.BALROG_PARODY:
                    return BALROG_PARODY_PRICE;
                case MyKnights.PRINCESS_WITH_EGGS:
                    return PRINCESS_WITH_EGGS_PRICE;
                default:
                    return NO_PRICE;
            }
        }

        private const int JEALOUS_TEEN_HP = 10;
        private const int BROWED_NINJA_HP = 40;
        private const int HOMELESS_WITH_AX_HP = 20;
        private const int BALROG_PARODY_HP = 50;
        private const int PRINCESS_WITH_EGGS_HP = 100;
        private const int NO_HP = 0;

        public static int GetHP(this MyKnights knight)
        {
            switch (knight)
            {
                case MyKnights.JEALOUS_TEEN:
                    return JEALOUS_TEEN_HP;
                case MyKnights.BROWED_NINJA:
                    return BROWED_NINJA_HP;
                case MyKnights.HOMELESS_WITH_AX:
                    return HOMELESS_WITH_AX_HP;
                case MyKnights.BALROG_PARODY:
                    return BALROG_PARODY_HP;
                case MyKnights.PRINCESS_WITH_EGGS:
                    return PRINCESS_WITH_EGGS_HP;
                default:
                    return NO_HP;
            }
        }

        public static string GetStringValue(this MyKnights knight)
        {
            switch (knight)
            {
                case MyKnights.JEALOUS_TEEN:
                    return "Jealous teen";
                case MyKnights.BROWED_NINJA:
                    return "Browed ninja";
                case MyKnights.HOMELESS_WITH_AX:
                    return "Homeless with ax";
                case MyKnights.BALROG_PARODY:
                    return "Balrog parody";
                case MyKnights.PRINCESS_WITH_EGGS:
                    return "Princess with eggs";
                default:
                    return "Some knight";
            }
        }
    }
    public class KnightInGame
    {
        public int HealthPoints { get; set; }
        public int PresentationHP { get; set; }
        public int NumberOfKnights { get; set; }
        public bool IsGoing { get; set; }

        public Point PointForKnight;
        public Point PointForHp;
        public Point PointForKnightStart;
        public Point PointForHpStart;

        public KnightInGame (int number, Point point, Point HP)
        {           
            NumberOfKnights = number;
            HealthPoints = number*100;
            PointForKnight = point;
            PointForHp = point;
            PointForKnightStart = point;
            PointForHpStart = HP;
            IsGoing = false;
            PresentationHP = 100;
        }
    }
}

