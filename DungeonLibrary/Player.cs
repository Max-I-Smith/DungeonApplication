using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    class Player:CharacterBase
    {

        //Grab players weapon
        public Weapons EquippedWeapon { get; set; }
        //grab race
        public Race PlayerRace { get; set; }
        //grab class
        public Class PlayerClass { get; set; }
        public Player(string name,int hitchance,int blockchance,int maxlife,int remaininglife,Race playerrace,Class playerclass)
        {
            Name = name;
            HitChance = hitchance;
            BlockChance = blockchance;
            MaxLife = maxlife;
            RemainingLife = remaininglife;
            PlayerRace = playerrace;
            PlayerClass = playerclass;


            //Depending on Character Race Give attributes
            //Switch
            switch (PlayerRace)
            {
                case Race.HalfOrc:
                    MaxLife += 5;
                    BlockChance += 5;
                    break;
                case Race.Human:
                    BlockChance += 10;
                    break;
                case Race.Elf:
                    HitChance += 10;
                    break;
                case Race.Hobbit:
                    HitChance += 5;
                    BlockChance += 10;
                    MaxLife -= 5;
                    break;
                case Race.HalfElf:
                    HitChance += 5;
                    BlockChance += 5;
                    break;
                case Race.Dwarf:
                    MaxLife += 10;
                    BlockChance += 5;
                    HitChance -= 5;
                    break;
                case Race.Goblin:
                    MaxLife -= 10;
                    HitChance += 10;
                    BlockChance += 10;
                    break;
                case Race.Kobold:
                    MaxLife -= 10;
                    HitChance += 10;
                    BlockChance += 10;
                    break;
                case Race.Orc:
                    MaxLife += 20;
                    HitChance -= 5;
                    BlockChance -= 5;
                    break;
                case Race.Gnome:
                    MaxLife -= 10;
                    HitChance += 10;
                    BlockChance += 10;
                    break;
                case Race.Ogre:
                    MaxLife += 30;
                    HitChance -= 10;
                    BlockChance -= 10;
                    break;
                case Race.Werewolf://Werewolf is stronger than any of the others intentionally/shouldn't be able to be chosen normally
                    MaxLife +=15;
                    HitChance +=15;
                    BlockChance += 15;
                    break;
                default:
                    break;
            }//end switch
        }//end constructor
        //Methods
        public override string ToString()
        {
            //Create a string to return for the players description
            string description = "";

            switch (PlayerRace)
            {
                case Race.HalfOrc:
                    description = "A Half-Orc a human orc hybrid";
                    break;
                case Race.Human:
                    description = "A perfectly average and uninteresting Human";
                    break;
                case Race.Elf:
                    description = "A Elf a longlived race considered to be extremely dexterous and wise";
                    break;
                case Race.Hobbit:
                    description = "A Hobbit a small race known to be brave and to eat alot";
                    break;
                case Race.HalfElf:
                    description = "A Half-Elf a human elf hybrid";
                    break;
                case Race.Dwarf:
                    description = "A Dwarf a small race. Proud and long lived";
                    break;
                case Race.Goblin:
                    description = "A Goblin a small race known troublemakers";
                    break;
                case Race.Kobold:
                    description = "A Kobold a small race generally considered to be goblins lesser known cousins.";
                    break;
                case Race.Orc:
                    description = "A Orc a strong a savage race";
                    break;
                case Race.Gnome:
                    description = "A Gnome a small race known for tinkering with all kinds of knickknacks";
                    break;
                case Race.Ogre:
                    description = "A Ogre a large race extremely strong but slow witted and a bit clumsy";
                    break;
                case Race.Werewolf:
                    description = "A Werewolf a human cursed with lycanthopy. This grants them extreme strength and regeneration but a loss of control during full moons.";
                    break;
            }//end switch
            return string.Format($"_______{Name}_____\n" +
                $"Life: {RemainingLife} of {MaxLife}\n" +
                $"Hit Chance: {DetermineHitChance()}%\n" +
                $"Weapon:\n{EquippedWeapon}\n" +
                $"Block: {BlockChance}\n" +
                $"Description:\n" +
                $"{description}");
        }//End ToString()
        public override int DamageDone()
        {
            //Generate random damage
            Random rndDmg = new Random();
            int damage = rndDmg.Next(EquippedWeapon.MinDmg, EquippedWeapon.MaxDmg + 1);
            return damage;
        }//end DamageDone

        public override int DetermineHitChance()
        {
            //Add players weapon bonus
            return base.DetermineHitChance() + EquippedWeapon.BonusToHit;
        }
    }//end class
}//ene namespace
