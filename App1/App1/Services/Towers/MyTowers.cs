using System;
using System.Drawing;

namespace App1.Services.Towers
{
    public enum MyTowers
    {
        CANNON,
        FORTRESS,
        WOODEN
    }

    public static class MyTowersUseCase
    {
        private const int CANNON_PRICE = 100;
        private const int FORTRESS_PRICE = 50;
        private const int WOODEN_PRICE = 40;
        private const int NO_PRICE = 0;

        public static int GetPrice(this MyTowers tower)
        {
            switch (tower)
            {
                case MyTowers.CANNON:
                    return CANNON_PRICE;
                case MyTowers.FORTRESS:
                    return FORTRESS_PRICE;
                case MyTowers.WOODEN:
                    return WOODEN_PRICE;
                default:
                    return NO_PRICE;             
            }
        }

        public static Bitmap GetImage(this MyTowers tower)
        {
            switch (tower)
            {
                case MyTowers.CANNON:
                    return Properties.Resources.cannon_tower;
                case MyTowers.FORTRESS:
                    return Properties.Resources.fortress;
                case MyTowers.WOODEN:
                    return Properties.Resources.watchtower_wooden_full_size;
                default:
                    return null;
            }
        }

        public static MyTowers Next(this MyTowers tower)
        {
            switch (tower)
            {
                case MyTowers.CANNON:
                    return MyTowers.FORTRESS;
                case MyTowers.FORTRESS:
                    return MyTowers.WOODEN;
                case MyTowers.WOODEN:
                    return MyTowers.CANNON;
                default:
                    return MyTowers.CANNON;
            }
        }

        public static MyTowers Previous(this MyTowers tower)
        {
            switch (tower)
            {
                case MyTowers.CANNON:
                    return MyTowers.WOODEN;
                case MyTowers.FORTRESS:
                    return MyTowers.CANNON;
                case MyTowers.WOODEN:
                    return MyTowers.FORTRESS;
                default:
                    return MyTowers.CANNON;
            }
        }
    }
}
