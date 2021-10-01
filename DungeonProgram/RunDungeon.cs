using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonProgram
{
    class RunDungeon
    {
        static void Main(string[] args)
        {
            Console.Title = "The End of the World";
            //Title the console window

            Console.WriteLine("You enter the dark tunnel......");


            // Weapons
            //Creating a list of possible weapons and putting them into an array
            #region Weapons
            //Five basic/starter weapons
            Weapons dagger = new Weapons(4, "Basic Dagger", 4, false, 1);//Easy to hit low potential dmg
            Weapons greatSword = new Weapons(8, "Basic GreatSword", 2, false, 3);//Slightly harder to hit for a slight dmg increase
            Weapons sword = new Weapons(6, "Basic Sword", 3, false, 2);//Medium option
            Weapons mace = new Weapons(6, "Basic Mace", 3, false, 2);//Same as sword just description difference
            Weapons staff = new Weapons(10, "Basic Staff", 1, false, 4);//Big damage, hard to hit

            Weapons[] weapons = { dagger, greatSword, sword, mace, staff };

            //Magic weapons
            //Twice as good as normal weapons
            Weapons mDagger = new Weapons(8, "An Enchanted Dagger", 8, true, 2);
            Weapons mGreatSword = new Weapons(16, "An Enchanted GreatSword", 4, true, 6);
            Weapons mSword = new Weapons(12, "An Enchanted Sword", 6, true, 4);
            Weapons mMace = new Weapons(12, "An Enchanted Mace", 6, true, 4);
            Weapons mStaff = new Weapons(20, "An Enchanted Staff", 2, true, 4);

            Weapons[] mWeapons = { mDagger, mGreatSword, mSword, mMace, mStaff };

            
            //TODO add legendary weapons? maybe

            #endregion
            //TODO Player
           
            //TODO Extra customization

            //TODO Loop for room

            //TODO Room Description

            //TODO Monster

            //TODO  Menu loop

            //TODO Menu Options

            //TODO User Choice

            //TODO Use User input for actions

            //TODO Battle Functionality

            //TODO Handle if user wins

            //TODO Opportunity Attack

            //TODO Display Monster Description

            //TODO Check Players life

            //TODO Display score/If they've won
            // Boss after certain number of rooms/defeated monsters



        }//end main
    }//end class
}//end namespace
