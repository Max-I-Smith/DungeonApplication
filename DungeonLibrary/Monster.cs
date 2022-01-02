using System;

namespace DungeonLibrary
{
    public class Monster : CharacterBase
    {
        private int _minDmg;
        private int maxLife;
        

        public int MaxDmg { get; set; }
        public Race Race { get; set; }
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                if (value > 0 && value <= MaxDmg)
                {
                    _minDmg = value;
                }
                else
                {
                    _minDmg = 0;
                }
            }
        }
        public Monster() { }
        public Monster(int minDmg, int maxDmg, Race race,string name, int hitChance, int blockChance, int maxLife, int remainingLife)
        {
           
            MaxDmg = maxDmg;
            Race = race;
            MinDmg = minDmg;
            Name = name;
            HitChance = hitChance;
            BlockChance = blockChance;
            MaxLife = maxLife;
            RemainingLife = remainingLife;
        }//end Constructor

        public override int DamageDone()
        {
            Random rand = new Random();
            return rand.Next(MinDmg, MaxDmg + 1);
        }
    }
}

