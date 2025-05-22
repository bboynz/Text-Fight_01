using Text_Fight.Entities;
using Text_Fight.Enviroment;
using Text_Fight.PlayerActions;

namespace GameCycle
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;


            Player player = CreatePlayer("BootyBasher9000", 100, 2);

            Items mikuLeech = CreateItem("Miku's Leek", 0, 100, true, 10, "Miku Miku BEAM!");
            Items chugJug = CreateItem("Chug Jug", 50, 0, false);

            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(mikuLeech);
            player.Items.Add(chugJug);

            while (!player.isdead)
            {
                Console.WriteLine("Press enter to start Battle!");
                Console.ReadLine();
                //Revives enemies
                Enemy bob = CreateEnemy("Bobgob", 100, 25, 1);
                Enemy gob = CreateEnemy("Gobbob", 100, 25, 1);
                Enemy hob = CreateEnemy("Hobtob", 100, 25, 1);
                Enemy tob = CreateEnemy("great bodhi", 200, 50, 2);
                //
                Battle(player, bob, hob, tob, gob);

            }

        }

        
        
            //  TURNS / BATTLES
        
        private static void EnemyTurn(Player player, Enemy enemy, List<Enemy> enemiesList, params Enemy[] enemies)
        {
            if (enemies.Length > 0)
            {
                Console.WriteLine("Enemy Turn\n\npls wait");
                Thread.Sleep(1000);

                //enemy Turn
                if (player.isvulnerable)
                {
                    player.Damage(enemy.AttackDamage + enemy.AttackDamage * (1 / 2));//adds half of damage to total then attacks
                    Console.WriteLine("Player damaged!");

                    string OverDamage = ((enemy.AttackDamage + enemy.AttackDamage * (1 / 2)) / 5).ToString(); //Over time effect for damage

                    for (int i = 5; i > 1; i--)
                    {
                        QuickTime.DramaticWrite(2, OverDamage);
                    }
                }

                if (player.isblocking)
                {
                    player.Damage(enemy.AttackDamage - enemy.AttackDamage * (1 / 2));//halfs the damage then attacks
                    Console.WriteLine("Player damaged!");

                    string OverDamage = ((enemy.AttackDamage - enemy.AttackDamage * (1 / 2)) / 3).ToString(); //Over time effect for damage

                    for (int i = 3; i > 1; i--)
                    {
                        QuickTime.DramaticWrite(3, OverDamage);
                    }
                }

                if (!player.isvulnerable && !player.isblocking)
                {
                    player.Damage(enemy.AttackDamage);
                    Console.WriteLine("Player damaged!");

                    string OverDamage = (enemy.AttackDamage / 4).ToString(); //Over time effect for damage

                    for (int i = 4; i > 1; i--)
                    {
                        QuickTime.DramaticWrite(2, OverDamage);
                    }
                }

            }


        }
        private static void PlayerTurn(Player player, List<Enemy> enemiesList, params Enemy[] enemies)
        {
            enemiesList = enemies.ToList();
            //User Turn
            bool loop = true;
            while (loop && enemies.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                try
                {
                    Console.WriteLine("Player's Turn!");
                    Console.WriteLine("\n\n"); // so when answer is incorrect it doesn't delete said txt (If I use Set cursor position it goes out of window bounds)
                    string input = Console.ReadLine().ToString().ToLower();

                    if (input.Contains("atk"))
                    {
                        string target = input.Replace("atk ", "");
                        Console.WriteLine("trys to attack " + target);

                        target.ToLower();

                        bool found = false; //So if there is no enemy found I can tell player
                        Enemy targetEnemy;
                        for (int i = 0; i < enemiesList.Count; i++) //loops through all enemies to find the target
                        {

                            if (enemiesList[i].EnemyName.ToLower() == target)
                            {
                                targetEnemy = enemies[i];
                                targetEnemy.Damage(player.BaseDamage * 100); //Need to add weapons
                                Console.WriteLine(" tried to  damage  {0} for {1} ", targetEnemy.EnemyName, player.BaseDamage * 100);
                                found = true;
                            }
                        }

                        if (found == false)
                        {
                            Console.WriteLine("\nEnemy not found, turn used\n\n Enter to continue:");
                            Console.ReadLine();
                            break;
                        }

                        loop = false;
                        break;
                    }
                    else if (input.Contains("use"))
                    {
                        string target = input.Replace("use ", "");

                        List<Items> items = player.Items;// the items the player has
                        List<Items> selectedItems = new List<Items>();  //a list for all the items that match to be added to
                        int amount = 0; // how many items that match

                        Items targetItem = null; //for interacting with items that match the requested name
                        for (int i = 0; i < items.Count; i++) //loops through all items to find the target
                        {
                            if (items[i].itemName.ToLower() == target)
                            {
                                targetItem = items[i];
                                selectedItems.Add(targetItem);

                            }
                        }
                        amount = selectedItems.Count;

                        if (amount == 0)
                        {
                            Console.WriteLine("\nItem not found, turn used\n\n Enter to continue:");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("You have {0} {1}", amount, target);
                        Console.WriteLine("How many do you want to use?");

                        while (true)
                        {
                            try
                            {
                                int inputAmount = int.Parse(Console.ReadLine());

                                if (inputAmount <= amount)
                                {
                                    Enemy[] targetEnemies = enemiesList.ToArray();
                                    targetItem.UseItem(inputAmount, targetItem, targetEnemies, player);
                                    loop = false;
                                    break;
                                }
                                else
                                {
                                    Console.Beep();
                                    Console.WriteLine("Wrong Input");
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Just input a correct amount mate");
                            }
                        }
                    }
                    else if (input.Contains("try"))
                    {
                        string target = input.Replace("try ", "");
                        Console.WriteLine("trys to " + target);

                        if (target.Contains("parry"))
                        {
                            if (QuickTime.WordQuickTime(2, target, "Attack Parried", "Parry failed, take 2x More damage"))
                            {
                                player.isparrying = true;
                            }
                            else
                            {
                                player.isvulnerable = true;
                            }
                            loop = false;
                        }
                        else if (target.Contains("block"))
                        {

                            if (QuickTime.WordQuickTime(4, target, "Attack blocked half damage", "block failed, take damage"))
                            {
                                player.isblocking = true;
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

                        break;
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
                catch (Exception e)
                {
                    QuickTime.DramaticWrite(10, "--Error Occured-- " + e);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ReadLine(); //so I can check errorS
                }
                finally
                {
                    foreach (Enemy enemy in enemiesList)
                    {

                    }

                    Enemy[] updatedEnemies = enemiesList.ToArray<Enemy>();
                    UpdateBattleGui(player, updatedEnemies);
                }
            }
        }
        public static void Battle(Player player, params Enemy[] enemies)
        {
            
            Console.ForegroundColor = ConsoleColor.White;

            Enemy targetEntity = null;
            List<Enemy> enemiesList = new List<Enemy>();
            enemiesList = enemies.ToList();

            string Turn = "";
            for (int i = 0; i < enemiesList.Count; i++) //loops through all enemies to who goes first
            {

                if (enemiesList[i].Speed > player.Speed)
                {
                    Turn = "enemy";
                    break;
                }
                else if (enemiesList[i].Speed <= player.Speed)
                {
                    Turn = "player";
                }
            }

            while (enemiesList.Count != 0 && enemies.Length != 0)
            {
                enemies = enemiesList.ToArray();
               

                if (player.isparrying)
                {
                    Turn = "player";
                }
                if (Turn == "player")
                {
                    Console.Title = "Battle: Player";
                    UpdateBattleGui(player, enemies);
                    InputHelp();
                    for (int i = player.Speed; i != 0; i--)
                    {
                        for (int k = 0; k < enemiesList.Count; k++) //loops through all enemies to who is alive before every turn the player has
                        {
                            enemiesList[k].CheckHealth();
                            if (enemiesList[k].isdead)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n"+enemiesList[k].EnemyName + " Died! \n\n Enter to continue:");
                                Console.ReadLine();
                                enemiesList.Remove(enemiesList[k]);
                                enemies = enemiesList.ToArray();
                                Console.ForegroundColor = ConsoleColor.White;
                                UpdateBattleGui(player, enemies);
                            }
                        }

                        PlayerTurn(player, enemiesList, enemies);
                    }
                    Turn = "enemy";
                }

                if (Turn == "enemy")
                {
                    for (int k = 0; k < enemiesList.Count; k++) //loops through all enemies to who is alive (Do this before trying to attack)
                    {
                        enemiesList[k].CheckHealth();
                        if (enemiesList[k].isdead)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n" + enemiesList[k].EnemyName + " Died! \n\n Enter to continue:");
                            Console.ReadLine();
                            enemiesList.Remove(enemiesList[k]);
                            enemies = enemiesList.ToArray();
                            Console.ForegroundColor = ConsoleColor.White;
                            UpdateBattleGui(player, enemies);
                        }
                    }

                    Console.Title = "Battle: Enemies";
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine("");

                    

                    for (int i = 0; i < enemiesList.Count; i++) //loops through all enemies to who goes first
                    {

                        for (int k = enemiesList[i].Speed; k > 0; k--)
                        {

                            Enemy enemy = enemiesList[i];

                            
                            EnemyTurn(player, enemy, enemiesList, enemies);
                            
                            
                        }
                    }
                    Turn = "player";
                }

            }

            Console.WriteLine("!!!Battle Over!!!");
            Console.ReadLine();
        }



            //  Enviroment / game progression
        public static Scaling ApplyScaling(double round)
        {
            Scaling scale = new Scaling();

            scale.scale = Convert.ToInt32(Math.Pow(round, 2.00D)); // this makes an exponential increase

            return scale;

        }
        private static Enemy FindEnemy(string target, List<Enemy> enemies)
        {
            Enemy targetEnemy = null;


            for (int i = 0; i < enemies.Count; i++) //loops through all enemies to find the target
            {

                if (enemies[i].EnemyName.ToLower() == target.ToLower())
                {
                    targetEnemy = enemies[i];
                }
            }




            return targetEnemy;
        }



            //  MAKE CLASSES
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
            player.isdead = false;

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
        


            //  PRINT GUI
        private static void InputHelp() { Console.WriteLine("\n\nInput___________________\n\n'Atk' + [enemy name] <--> To attack an enemy\n\n 'Use' + [itemName] <--> To use an item\n\n 'Try' + [block/parry] <--> To attempt a block quicktime\n\n 'Hlp' <--> To get the input list again\n________________________"); }
        private static void PrintEnemy(Enemy enemy ,int columnPos, int rowShift)
        {
            


            Console.SetCursorPosition(columnPos, Console.CursorTop - 1 + rowShift); //goes up a row to last line, and to the column position

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
            Console.ForegroundColor = ConsoleColor.White;






            if (enemies.Length > 0) // So It doesn't crash
            {


                Console.Clear(); //Refreshs the console

                int rowPos = Console.CursorTop; //Used to track where the last row was and move from there
                int columnPos = 0;  //Used to track where the last row was and move from there
                int width = Console.WindowWidth - enemies[enemies.Count() - 1].EnemyName.Length; //the width of the collumn minus the chars(should be 1 column per char) the first string takes up

                Console.WriteLine("\n____________________\nEnemies:\n");

                int k = 0; // This is to know how many enemies there are

                //Enemy GUI -----

                int rowShift = 0; //Incase I need to shift The printed variable vertically

                k = enemies.Count();

                while (k > 7) //This makes the enemies print in packets of seven preventing them from overlapping or overflowing
                {

                    k = k - 7; //removes seven from total then prints them
                    Console.WriteLine("\n");

                    for (int i = 7; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
                    {
                        columnPos = (width / 7) * (i - 1);//doing -1 cause it looks good --collumn pos is equal to ratio of enemy size to window size (was eg. width * 1/5) times the amount of enemies - 1
                        PrintEnemy(enemies[i - 1], columnPos, rowShift);
                        columnPos += width / 7; //moves along a section of total width
                        Thread.Sleep(10);
                    }


                }
                for (int i = k; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
                {
                    columnPos = (width / k) * (i - 1);//doing -1 cause it looks good --collumn pos is equal to ratio of enemy size to window size (was eg. width * 1/5) times the amount of enemies - 1
                    PrintEnemy(enemies[i - 1], columnPos, rowShift);
                    columnPos += width / k; //moves along a section of total width
                    Thread.Sleep(10);
                }



                //Player GUI -----
                Console.WriteLine("\n\n\n\n\n"); //so name is more visible
                Console.SetCursorPosition(width / 2, Console.CursorTop); //goes to middle of console and down 5 rows

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
                        Console.WriteLine("\n");
                        Console.SetCursorPosition(columnPos2, Console.CursorTop);
                        Console.WriteLine(item.itemName);
                    }

                }

            }
            else
            {
                Console.WriteLine("No Enemies!");
                return;
            }


        }


    }



}
