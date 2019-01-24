using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services.Evils
{
    public enum MyEvil
    {
        EVIL1,
        EVIL2,
        EVIL3,
        EVIL4,
        EVIL5
    }

    public class EvilInGame
    {
        public int HealthPoints { get; set; }
        public int NumberOfEvil { get; set; }
        public bool IsMoving { get; set; }
        public int PresentationHP { get; set; }
        public Point pointForEvil;
        public Point pointForHp;

        public EvilInGame(int number, Point point, Point HP)
        {
            if (number == 0) number = 1;
            this.NumberOfEvil = number;
            this.HealthPoints = number * 100;
            this.pointForEvil = point;
            this.pointForHp = point;
        }
    }
    }



