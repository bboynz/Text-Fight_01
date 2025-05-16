using System;
using System.IO;
using System.Collections;
using System.Text;
using Text_Fight.Entities;
using Text_Fight.PlayerActions;
using Text_Fight.Enviroment;
using System.Data.SqlTypes;
using System.Numerics;
using System.Security.Principal;

namespace GameCycle
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Player player = CreatePlayer("BootyBasher9000", 100, 2);

            Items mikuLeech = CreateItem("Miku's Leek", 0, 100, true, 10, "Miku Miku BEAM!");

            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);

            Enemy bob = CreateEnemy("Bob the gob", 100, 25, 1);
            Enemy gob = CreateEnemy("Gob the bob", 100, 25, 1);
            Enemy hob = CreateEnemy("Hob the tob", 100, 25, 1);
            Enemy tob = CreateEnemy("Tob the hob", 100, 25, 1);

            Battle(player, bob,hob,tob, tob,bob,bob, bob,bob);
        }

        private static void InputHelp() { Console.WriteLine("\n\nInput___________________\n\n'Atk' + [enemy name] <--> To attack an enemy\n\n 'Use' + [itemName] <--> To use an item\n\n 'Try' + [block/parry] <--> To attempt a block quicktime\n\n 'Hlp' <--> To get the input list again\n________________________"); }
        public static void Battle(Player player, params Enemy[] enemies)
        {
            UpdateBattleGui(player,enemies);
            InputHelp();
            

            bool loop = true;
            while (loop)
            {
                try
                {
                    Console.WriteLine("\n\n"); // so when answer is incorrect it doesn't delete said txt (If I use Set cursor position it goes out of window bounds)
                    string input = Console.ReadLine().ToString().ToLower();

                    if (input.Contains("atk"))
                    {
                        string target = input.Replace("atk ", "");

                        target.ToLower();


                        Enemy targetEnemy;
                        for (int i = 0; i < enemies.Length; i++) //loops through all enemies to find the target
                        {
                            Console.WriteLine("trys to attack" + target);
                            if (enemies[i].EnemyName.ToLower() == target)
                            {
                                targetEnemy = enemies[i];
                                targetEnemy.Damage(player.BaseDamage * 100); //Need to add weapons
                                Console.WriteLine("{0} damaged for {1}", targetEnemy.EnemyName, player.BaseDamage * 100);
                                Console.ReadLine();
                                loop = false;
                            }
                        }

                        
                    }
                    else if (input.Contains("use"))
                    {
                        string target = input.Replace("use ", "");
                        Console.WriteLine("uses " + target);
                        Console.ReadLine(); //So user can read text before gui is reset/updated

                        List<Items> items = player.Items;// the items the player has
                        List<Items> selectedItems = new List<Items>();  //a list for all the items that match to be added to
                        int amount = 0; // how many items that match
                        Items targetItem; //for interacting with items that match the requested name
                        for (int i = 0; i < items.Count; i++) //loops through all items to find the target
                        {
                            if (items[i].itemName.ToLower() == target)
                            {
                                targetItem = items[i];
                                selectedItems.Add(targetItem);
                                
                            }
                        }
                        amount = selectedItems.Count;
                        Console.WriteLine("You have {0} {1}", amount, target);
                        Console.ReadLine();
                        loop = false;
                    }
                    else if (input.Contains("try"))
                    {
                        string target = input.Replace("try ", "");
                        Console.WriteLine("trys to " + target);

                        if (target.Contains("parry"))
                        {
                            if (QuickTime.WordQuickTime(2, target, "Attack Parried", "Parry failed, take 2x More damage"))
                            {

                            }
                            else
                            {

                            }
                            loop = false;
                        }
                        else if (target.Contains("block"))
                        {

                            if (QuickTime.WordQuickTime(4, target, "Attack blocked half damage", "block failed, take damage"))
                            {

                            }
                            else
                            {

                            }
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Input either 'block' or 'parry' with 'try' command");
                            Console.ReadLine();
                        }
                            
                    }
                    else if (input.Contains("hlp"))
                    {
                        InputHelp();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        
                        QuickTime.DramaticWrite(10, "--Incorrect Input--");
                        
                    }

                }
                catch(Exception e)
                {
                    QuickTime.DramaticWrite(10, "--Error Occured-- " + e);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Read();
                }
                finally
                {

                    UpdateBattleGui(player, enemies);
                }
                
            }
            


        }

        public static Scaling ApplyScaling(double round)
        {
            Scaling scale = new Scaling();

            scale.scale = Convert.ToInt32(Math.Pow(round, 2.00D)); // this makes an exponential increase

            return scale;

        }
        public static Enemy CreateEnemy(string name, float maxHealth, float attackDamage, int speed)
        {
            Enemy enemy = new Enemy();
            enemy.EnemyName = name;
            enemy.MaxHealth = maxHealth;
            enemy.AttackDamage = attackDamage;
            enemy.Speed = speed;


            return enemy;
        }
        public static Player CreatePlayer(string name, float maxHealth, int speed)
        {
            Player player = new Player();
            player.UserName = name;
            player.MaxHealth = maxHealth;
            player.Speed = speed;
            player.BaseDamage = 1;

            return player;
        }


        public static Items CreateItem(string name, float healAmount, float damageAmount, bool needSpell, int spellTimeLimit = 0, string spellWords = "")
        {
            //automated bools (execpt spells) in main code
            Items item = new Items();
            item.itemName = name;

            item.HealAmount = healAmount;
            item.DamageAmount = damageAmount;

            item.requiresSpell = needSpell;
            item.spellTimeLimit = spellTimeLimit;
            item.itemSpellName = spellWords;



            

            return item;
        }


        private static void PrintEnemy(Enemy enemy ,int columnPos, int rowShift)
        {
            


            Console.SetCursorPosition(columnPos, Console.CursorTop - 1); //goes up a row to last line, and to the column position

            Console.WriteLine(enemy.EnemyName); //list starts at 0 so I minus 1

            Console.SetCursorPosition(columnPos + 1, Console.CursorTop + 1);
            Console.WriteLine("Health <==> {0} ", enemy.CurrentHealth); //this makes it go to the correcnt collunm

            Console.SetCursorPosition(columnPos + 2, Console.CursorTop);
            Console.WriteLine("Speed <==> {0}", enemy.Speed);

            Console.SetCursorPosition(columnPos + 3, Console.CursorTop);
            Console.WriteLine("Damage <==> {0}", enemy.AttackDamage);

            Console.SetCursorPosition(columnPos, Console.CursorTop - 3); // as I added 3 lines I need to take away 3 or enemies will be too far apart

            
        }
        public static void UpdateBattleGui(Player player, params Enemy[] enemies)
        {
            
            Console.Clear(); //Refreshs the console

            int rowPos = Console.CursorTop; //Used to track where the last row was and move from there
            int columnPos = 0;  //Used to track where the last row was and move from there
            int width = Console.WindowWidth - enemies[enemies.Count() - 1].EnemyName.Length; //the width of the collumn minus the chars(should be 1 column per char) the first string takes up
            
            Console.WriteLine("Enemies:\n");

            int k = 0; // This is to know how many enemies there are
            int r = 0; // this is how many remaining enemies there are

            //Enemy GUI
            
            int rowShift = 0; //Incase I need to shift The printed variable vertically

            k = enemies.Count();
            while (columnPos + (width / k) < width) // While the current column position plus the amount of columns used for next enemy is bigger than the window
            {
                k--;
                r++;

            }
            
            for (int i = k; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
            {
                columnPos = (width / k) * (i - 1);//doing -1 cause it looks good
                PrintEnemy(enemies[i - 1], columnPos, rowShift);
                columnPos += width / k; //moves along a section of total width
                Thread.Sleep(100);
            }
            
            for (int i = r; i > 0; i--)//Extras in next row
            {
                rowShift = -5;
                columnPos = (width / r) * (i - 1);//doing -1 cause it looks good
                PrintEnemy(enemies[i - 1], columnPos, rowShift);
                columnPos += width / r; //moves along a section of total width
                Thread.Sleep(100);
            }


            k--;
            Thread.Sleep(400); // so i can see whats happening
            

            Console.SetCursorPosition(width / 2, Console.CursorTop + 5); //goes to middle of console and down 5 rows
            //Username
            Console.WriteLine(player.UserName);

            //Health
            Console.SetCursorPosition(width / 2, Console.CursorTop); //goes to middle of console
            Console.WriteLine("Health <==> {0}", player.CurrentHealth);
            //Speed
            Console.SetCursorPosition(width / 2, Console.CursorTop);
            Console.WriteLine("Speed <==> {0}", player.Speed);

            //Items
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("Items:");
            int columnPos2 = 0;

            foreach (Items item in player.Items)
            {

                if ((columnPos2 + item.itemName.Length + 2) < Console.WindowWidth) //If the text wont overflow
                {
                    Console.WriteLine(item.itemName);
                    columnPos2 += item.itemName.Length + 2; //moves along so theres enough room
                    Console.SetCursorPosition(columnPos2, Console.CursorTop - 1);

                }
                else// So when there is no space to fit the string the cursor will reset the column and go down two rows
                {
                    columnPos2 = 0;
                    Console.SetCursorPosition(columnPos2, Console.CursorTop + 2);
                    Console.WriteLine(item.itemName);
                }

            }
            


        }


    }



}
