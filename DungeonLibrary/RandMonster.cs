using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
   public class RandMonster : Monster
    {
       public RandMonster(string name, int maxLife, int remainingLife, int hitChance, int blockChance, int minDmg , int maxDmg, Race race):base(minDmg,maxDmg,race,name,hitChance,blockChance,maxLife,remainingLife)
        {
          
        }
            Random rand = new Random();//For Random Values
            Array values = Enum.GetValues(typeof(Race));
         
        public RandMonster()
        {
            Race randomRace = (Race)values.GetValue(rand.Next(values.Length));
            //For getting a random Race
            Name = "Amalgamation";

            MaxLife = 3 + rand.Next(10);
            RemainingLife = MaxLife;
            HitChance = 20+ rand.Next(50);
            BlockChance = rand.Next(30);
            MinDmg = 1+ rand.Next(3);
            MaxDmg = 1+ rand.Next(7);
            Race = randomRace;
        }
        public override string ToString()
        {
            return string.Format($"\n*****MONSTER*****\n" +

                $"{Name}\n" +
                 $"Life: {RemainingLife} of {MaxLife}\n" +
                 $"Damage: {MinDmg} to {MaxDmg}\n" +
                 $"Block: {BlockChance}\n" +
                 $"Race: {Race}\n");
        }
    }
}
