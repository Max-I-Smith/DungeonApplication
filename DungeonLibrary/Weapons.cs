using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapons
    {
        //Fields
        //Just minimum dmg so the minimum can't be higher than the maximum
        private int _minDmg;

        //Properties
        public int MaxDmg { get; set; }
        //Maximum Possible Dmg
        public string WeaponName { get; set; }
        //Name of the weapon
        public int BonusToHit { get; set; }
        //Bonus to hit 
        public bool IsMagic { get; set; }
        //Is Magic to determine if the weapon with ignore block and have a different display for hitting
        public int MinDmg
        {
            get { return _minDmg; }
            set
            {
                //Make sure MinDmg is greater than zero and less then MaxDmg
                if (value>0 &&value<=MaxDmg)
                {
                    _minDmg = value;
                }
                else
                {
                    _minDmg = 1;
                }
            }//end set
        }//end MinDmg

        //Constructors(Fully Qualified)

        public Weapons(int maxDmg, string weaponName, int bonusToHit, bool isMagic, int minDmg)
        {
            MaxDmg = maxDmg;
            WeaponName = weaponName;
            BonusToHit = bonusToHit;
            IsMagic = isMagic;
            MinDmg = minDmg;
        }//end of weapons constructor

        //Methods

        public override string ToString()
        {
            //If weapon is called going to display the Name of it
            //TODO Will have to check if it is magic in RunDungeon to change text color


            return WeaponName;
            
        }
    }//end class
}//end namespace
