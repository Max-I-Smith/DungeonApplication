using DungeonLibrary;
using System;

namespace DungeonProgram
{
    class RunDungeon
    {
        static void Main(string[] args)
        {
            //Title the console window
            Console.Title = "The End of the World";
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


            // TODO Player
            Player player = new Player("Hero",60,5,20,20, Race.Human, sword);
            bool createPlayer = false;
            string userName = "";
            string userRace = "";
            bool CompleteGame = false;
            //Ask user for player info 
            #region Player Customization
            //do
            //{

            //    Console.WriteLine("Please enter your hero's name\n");
            //    userName = Console.ReadLine();
            //    if (userName =="ADMIN")
            //    { CompleteGame = true; }
            //    Console.WriteLine("Please select a Race:\n");
            //    Console.WriteLine("1: HalfOrc\n" +
            //                      "2: Human\n" +
            //                      "3: Elf\n" +
            //                      "4: Hobbit\n" +
            //                      "5: HalfElf\n" +
            //                      "6: Dwarf\n" +
            //                      "7: Gnome\n");
            //    if (CompleteGame == true)
            //    {
            //        Console.WriteLine("You have unlocked the Secret Race: 8: WereWolf\n");
            //    }
            //    string playerRace = Console.ReadLine().ToUpper();


            //    switch (playerRace)
            //    {
            //        case "HALFORC":
            //            Player  player= new Player(userName, 10, 10, 10, 10, Race.HalfOrc);
            //            break;
            //        case "HUMAN":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.Human);
            //            break;
            //        case "ELF":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.Elf);
            //            break;
            //        case "HOBBIT":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.Hobbit);
            //            break;
            //        case "HALFELF":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.HalfElf);
            //            break;
            //        case "DWARF":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.Dwarf);
            //            break;
            //        case "GNOME":
            //            Player player = new Player(userName, 10, 10, 10, 10, Race.Gnome);
            //            break;

            //        default:
            //            break;
            //    }//end switch
            //    createPlayer = true;

            //}
            //while (createPlayer == false);
            #endregion
            //TODO Extra customization
            Console.WriteLine("You have been sent to cleanse this dark place of the terrible experiments created here.\n");

            Console.WriteLine("You enter the dark tunnel......");


            // Loop for rooms in the dungeon
            bool exit = false;//Check if player wants to continue/Has lost or won
            do
            {
                //Room Description
                Console.WriteLine(GetRoom());

                RandMonster randMonster = new RandMonster();
                Console.WriteLine("Before you stands one of the Dark Lord's Abominations!\n");

                bool reload = false;//reload the menu
                int score = 0;
                do
                {
                    // 8. Create a menu of options
                    Console.WriteLine("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Player info\n" +
                        "M) Monster info\n" +
                        "X) Exit\n");
                    // 9. Capture user choice
                    //string userChoice = Console.ReadLine();
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    // 10. Perform an action based on the users input
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            // 11. Create attack/battle functionality
                            Combat.Attack(player, randMonster);
                            Combat.Attack(randMonster, player);
                            if (randMonster.RemainingLife <= 0)
                            {
                                // 12. Handle if the user wins 
                                //its dead
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\nYou killed {0}!\n", randMonster.Name);
                                Console.ResetColor();
                                reload = true;//this breaks us out of the loop to get a new room and new monster
                                score++;
                            }
                            break;
                        case ConsoleKey.R:
                            //14. Monster Free Attack
                            Console.WriteLine($"{randMonster.Name} attacks you as you flee.");
                            Combat.Attack(randMonster, player);//free attack
                            Console.WriteLine();
                            reload = true;//load a new room
                            break;
                        case ConsoleKey.P:
                            Console.WriteLine("Player Info");
                            // Write out player info to screen
                            Console.WriteLine(player);
                            break;
                        case ConsoleKey.M:
                            Console.WriteLine("Monster Info");
                            // 15. Write out Monster info to screen
                            Console.WriteLine(randMonster);
                            break;
                        case ConsoleKey.X:
                        case ConsoleKey.E:
                            Console.WriteLine("Noone likes a quitter.");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Thou hast chosen an improper option. Try again.");
                            break;
                    }//end switch


                    //16. Check the players life
                    if (player.RemainingLife <= 0)
                    {
                        Console.WriteLine("You have fallen in battle!");
                        Console.WriteLine("Your score was: "+score);
                        exit = true;//breaks out of both loops
                    }
                } while (!reload && !exit);





            } while (!exit);


            //TODO Display score/If they've won
            // Boss after certain number of rooms/defeated monsters



        }//end main
        private static string GetRoom()
        {
            string[] rooms =
            {
                "Rusting spikes line the walls and ceiling of this chamber. The dusty floor shows no sign that the walls move over it, but you can see the skeleton of some humanoid impaled on some wall spikes nearby.",
                "This chamber holds one occupant: the statue of a male figure with elven features but the broad, muscular body of a hale human. It kneels on the floor as though fallen to that posture. Both its arms reach upward in supplication, and its face is a mask of grief. Two great feathered wings droop from its back, both sculpted to look broken. The statue is skillfully crafted.",
                "A horrendous, overwhelming stench wafts from the room before you. Small cages containing small animals and large insects line the walls. Some of the creatures look sickly and alive but most are clearly dead. Their rotting corpses and the unclean cages no doubt result in the zoo's foul odor. A cat mews weakly from its cage, but the other creatures just silently shrink back into their filthy prisons.",
                "This tiny room holds a curious array of machinery. Winches and levers project from every wall, and chains with handles dangle from the ceiling. On a nearby wall, you note a pictogram of what looks like a scythe on a chain.",
                " Rats inside the room shriek when they hear the door open, then they run in all directions from a putrid corpse lying in the center of the floor. As these creatures crowd around the edges of the room, seeking to crawl through a hole in one corner, they fight one another. The stinking corpse in the middle of the room looks human, but the damage both time and the rats have wrought are enough to make determining its race by appearance an extremely difficult task at best."
            };
            Random ran = new Random();
            int index = ran.Next(rooms.Length);

            string room = rooms[index];
            return room;
        }//end GetRoom
    }//end class
}//end namespace
