using System;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void Attack(CharacterBase attacker, CharacterBase defender)
        {
            //Generate randomNumber for dmg
            Random rand = new Random();
            int roll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(20);//Wait 20


            //Determine if the Character attacked with their roll
            if (roll <= (attacker.DetermineHitChance() - defender.DetermineBlock()))
            {
                int damageDone = attacker.DamageDone();
                defender.RemainingLife -= damageDone;


                //Change the color of the line to darkred and tell the user what happenend then rest the color to normal
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"{attacker.Name} struck {defender.Name} for {damageDone} damage!");
                Console.ResetColor();
            }//end if
            else
            {
                //Tells the user the attacker missed
                Console.WriteLine($"{attacker.Name} struck only air!");
            }//end else
        }//end Attack function

        //Actual combat function
        //public static void Battle(Player player, Monster monster)
        //{
        //    //Player attacks first
        //    Battle(player, monster);
        //    //Monster only attacks if it is still alive
        //    if (monster.RemainingLife > 0)
        //    {
        //        Attack(monster, player);
        //    }//end if

        //}//end battle function


}//end class
}//end NameSpace
