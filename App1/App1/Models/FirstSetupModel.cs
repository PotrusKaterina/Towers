using App1.Services.Towers;
using System.Collections.Generic;


namespace App1.Models
{
    public class FirstSetupModel
    {
        public MyTowers TowerType { get; set; }
        public int GoldRest { get; set; }
        public Dictionary<MyKnights,int> Knights { get; set; }
        public int KnightsCount { get; set; }

        public FirstSetupModel()
        {
            GoldRest = 200;
            TowerType = MyTowers.CANNON;
            KnightsCount = 0;
            Knights = new Dictionary<MyKnights, int>();
            Knights.Add(MyKnights.BROWED_NINJA, KnightsCount);
            Knights.Add(MyKnights.BALROG_PARODY, KnightsCount);
            Knights.Add(MyKnights.HOMELESS_WITH_AX, KnightsCount);
            Knights.Add(MyKnights.JEALOUS_TEEN, KnightsCount);
            Knights.Add(MyKnights.PRINCESS_WITH_EGGS, KnightsCount);
        }
    }
}
