﻿using System.Numerics;
using System.Timers;
using Text_Fight.Entities;
using Text_Fight.Enviroment;
using Text_Fight.PlayerActions;

namespace GameCycle
{

    class Program
    {
        
        static void Main(string[] args)
        {

            StartRun();

        }

        //Run methods
        private static void ResetGame() //Resets the console for a new game (and anything else if need be)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
        private static void Tutorial() //the tutorial (seperate from start to make it more manageable while coding)
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2);
            QuickTime.DramaticWrite(20, "(-o-)/  |  'Howdy Im Bodhi! '");

            QuickTime.DramaticWrite(30, "(-0-).- |  'Im going to explain how things work around here'");
            QuickTime.DramaticWrite(30, "('-')l  |  'First off Ill give you a breath run down'");

            QuickTime.DramaticWrite(30, "(-0-).- |  'Here In the dungeon you will be facing many creatures'");
            QuickTime.DramaticWrite(30, "(-o-).  |  'Enemies can drop items and doubloons'");
            QuickTime.DramaticWrite(40, "(-0-)   |  'Items can be used in combat with commands.'");
            QuickTime.DramaticWrite(40, "(-o-)   |  'Some Items may require a quick time event'");

            QuickTime.DramaticWrite(40, "(-.-).  |  'You and the enemies you face have stats'");
            QuickTime.DramaticWrite(20, "('u')/  |  'First is Health!'");
            QuickTime.DramaticWrite(40, "('0').  |  'If your out of health ya DIE!'");
            QuickTime.DramaticWrite(30, "(X-X).  |  'If ya dead its game over!'");
            QuickTime.DramaticWrite(40, "('0').- |  'But, if your enemies die ya get some goodies!'");
            QuickTime.DramaticWrite(20, "('u')/  |  'Next is your Speed!'");
            QuickTime.DramaticWrite(50, "('o').  |  'Speed determines how many TURNS you/enemies have'");
            QuickTime.DramaticWrite(40, "('0').- |  'and whoever is faster goes first!'");
            QuickTime.DramaticWrite(30, "('u')/  |  'Now last, but not least is Damage!'");
            QuickTime.DramaticWrite(30, "(-.-)   |  'this is just how much damage ya deal...'");


            QuickTime.DramaticWrite(40, "('0').  |  'Ya can also use the try command to block/parry'");
            QuickTime.DramaticWrite(50, "('o').  |  'Blocking and parrying require ya to do a QUICK TIME!");
            QuickTime.DramaticWrite(40, "('0').  |  'Blocking cuts the damage in HALF if ya succeed'");
            QuickTime.DramaticWrite(40, "(7^P^)7 |  'Parrying STOPS ONE ATTACK and damages 10% of the enemy health!'");
            QuickTime.DramaticWrite(50, "(-.-)   |  'But the quick time is harder, and if you fail; ya take double damage...'");

            QuickTime.DramaticWrite(30, "(-u-).  |  'Ya should be ready now'");
            QuickTime.DramaticWrite(30, "(^o^).  |  'Lets part ways with a lil' dance!'");

            for (int i = 2; i != 0; i--)
            {
                QuickTime.DramaticWrite(1, "  (-u-)    |  See");
                QuickTime.DramaticWrite(1, " (-u-).    |  See");
                QuickTime.DramaticWrite(1, " (-u-).-   |  See");
                QuickTime.DramaticWrite(1, " (-u-).~   |  Ya");
                QuickTime.DramaticWrite(1, " (-u-).~   |  Ya");
                QuickTime.DramaticWrite(1, " (-u-).-   |  Ya");
                QuickTime.DramaticWrite(1, "  (-u-).   |  See");
                QuickTime.DramaticWrite(1, "  (-u-)    |  See");
                QuickTime.DramaticWrite(1, " .(-u-)    |  See");
                QuickTime.DramaticWrite(1, " -.(-u-)   |  See");
                QuickTime.DramaticWrite(1, " ~.(-u-)   |  Ya");
                QuickTime.DramaticWrite(1, " ~.(-u-)   |  Yaa");
                QuickTime.DramaticWrite(1, " -.(-u-)   |  Yaaa");
                QuickTime.DramaticWrite(1, " .(-u-)    |  Yaaaa");
            }
        }
        public static void StartRun() // starts the current runn
        {
            int enemyProgress = 1; //This is used to keep track of how manny enemies spawn

            ResetGame();
            Console.Title = "Welcome";

            Console.WriteLine("\n\n\n\n\n");

            QuickTime.DramaticWrite(5, "!!!Welcome To My Wonderous Compost!!!  (~v~)/ ");
            QuickTime.DramaticWrite(1, "!!!Welcome To My Wonderous Compost!!!  (~v~)- ");
            QuickTime.DramaticWrite(1, "!!!Welcome To My Wonderous Compost!!!  (~v~)/ ");
            QuickTime.DramaticWrite(1, "!!!Welcome To My Wonderous Compost!!!  (~v~)- ");
            Console.WriteLine("!!!Welcome To My Wonderous Compost!!!  (~v~)/ ");

            Console.WriteLine("\n\nYou are a worm!\nYour job is to clean up my Compost!!");

            Console.WriteLine("\n\nDo You want a long introduction {Y/N}");
            if (Console.ReadLine().ToString().ToLower() == "y"){Tutorial();}
            

            Console.WriteLine("\nWhats Your Username?");
            string username = Console.ReadLine();

            Player player = CreatePlayer(username, 100f, 2);
            player.CurrentWeapon = CreateWeapon(50f, "stick");
            

            

            while (!player.isdead) // main game loop
            {
                player.round++; //To keep track of the round I store the int in the player so it is easily acessable

                Console.WriteLine("\n\n Press enter to start Round!\n\n");
                

                if (Console.ReadLine().ToString().ToLower().Contains("devop"))
                {
                    int hackRound = Convert.ToInt32(Console.ReadLine());
                    enemyProgress = hackRound - (hackRound % 2);
                    player.round = hackRound;
                }

                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));


                List<Enemy> enemies = new List<Enemy>(); //List I store the current enemies in (The list allows for me to easily change and edit them)

                
                if (player.round % 2 == 0) //every even round adds an enemy
                {
                    enemyProgress++;
                }


                for (int i = enemyProgress; i > 0; i--)//This is code that adds enemies to the enemy list depending how far the player has gotten
                {
                    Enemy addedEnemy = RanEnemies(enemyProgress);
                    addedEnemy.enemyIndex = i.ToString();
                    enemies.Add(addedEnemy);
                }



                Enemy[] SelectedEnemies = enemies.ToArray(); //I use params so I can have unlimited enemies, so I need to transfer between array and list.

                Shop(player);

                Battle(player, SelectedEnemies);

            }
        }

        
        
            //  TURNS / BATTLES
        
        private static void EnemyTurn(Player player, Enemy enemy, List<Enemy> enemiesList, params Enemy[] enemies) //code for enemies to attack player and visuals for player
        {
            if (enemies.Length > 0) //So it doesn't run if all enemies are defeated
            {
                Console.WriteLine("Enemy Turn\n\npls wait");
                Thread.Sleep(1000);
                //Checks if player is parrying and if so then it cancels one of the enemies attacks
                if (player.isparrying)
                {
                    enemy.Damage(enemy.MaxHealth/10);
                }

                //enemy Turn (using different if statements that check the state of the player) - I use bools so multiple states can be achieved
                if (player.isvulnerable)
                {
                    player.Damage(enemy.AttackDamage + (enemy.AttackDamage * (1 / 2)));//adds half of damage to total then attacks
                    Console.WriteLine("Player damaged!");

                    string OverDamage = ((enemy.AttackDamage + (enemy.AttackDamage * (1 / 2))) / 5).ToString(); //Over time effect for damage

                    for (int i = 5; i > 1; i--)
                    {
                        QuickTime.DramaticWrite(2, OverDamage);
                    }
                    
                }

                if (player.isblocking)
                {
                    player.Damage(enemy.AttackDamage/2);//halfs the damage then attacks
                    Console.WriteLine("Player damaged!");

                    string OverDamage = ((enemy.AttackDamage - enemy.AttackDamage * (1 / 2)) / 3).ToString(); //Over time effect for damage

                    for (int i = 3; i > 1; i--)
                    {
                        QuickTime.DramaticWrite(3, OverDamage);
                    }

                    
                }

                if (!player.isvulnerable && !player.isblocking && !player.isparrying)
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
             //reseting all player states after enemy attack
            player.isvulnerable = false;
            player.isparrying = false;

        }
        private static void PlayerTurn(Player player, List<Enemy> enemiesList, params Enemy[] enemies)  //takes player input and does stuff as the player's turn
        {
            enemiesList = enemies.ToList();
            //User Turn
            bool loop = true;
            while (loop && enemies.Length > 0)//repeating until loop is broken or enemies have died. (if the loop breaks it uses a turn)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                try
                {
                    
                    Console.WriteLine("\nPlayer's Turn!");
                    Console.WriteLine("Input 'hlp' for commands");
                    Console.WriteLine("\n\n"); // so when answer is incorrect it doesn't delete said txt (If I use Set cursor position it goes out of window bounds)
                    string input = Console.ReadLine().ToString().ToLower();

                    if (input.Contains("atk") || input.Contains("a "))
                    {

                        string target; //Allows for both inputs (could just check if input contain enemy name but that would mean enemies can't have different version of name ex: carrot and evil carrot ; if evil carrot was first it would attack that instead of carrot)
                        if (input.Contains("atk")) { target = input.Replace("atk ", ""); }
                        else { target = input.Replace("a ", ""); } //These isolate the target name
                            
                        Console.WriteLine("trys to attack " + target);

                        target.ToLower();

                        bool found = false; //So if there is no enemy found I can tell player
                        Enemy targetEnemy;
                        for (int i = 0; i < enemiesList.Count; i++) //loops through all enemies to find the target
                        {

                            if (enemiesList[i].EnemyName.ToLower() == target || enemiesList[i].enemyIndex == target)
                            {
                                targetEnemy = enemies[i];
                                targetEnemy.Damage(player.BaseDamage * player.CurrentWeapon.damage); //Need to add weapons
                                Console.WriteLine(" tried to  damage  {0} for {1} ", targetEnemy.EnemyName, player.BaseDamage * player.CurrentWeapon.damage);
                                found = true;
                                break;
                            }
                            
                        }
                        if(target == player.UserName.ToLower() ){
                            player.Damage(player.BaseDamage * player.CurrentWeapon.damage);
                            found = true;
                            loop = false;
                            break;
                        }

                        if (found == false)
                        {
                            Console.WriteLine("\nEnemy not found, turn used\n\n Enter to continue:");
                            Console.ReadLine();
                            
                        }
                        if(found == true)
                        {
                            loop = false;
                            break;
                        }

                        
                    }
                    else if (input.Contains("use") || input.Contains("u "))
                    {
                        string target;
                        if (input.Contains("use")) { target = input.Replace("use ", ""); }
                        else { target = input.Replace("u ", ""); }

                        List<Items> items = player.Items;// the items the player has
                        List<Items> selectedItems = new List<Items>();  //a list for all the items that match to be added to
                        int amount = 0; // how many items that match

                        Items targetItem = null; //for interacting with items that match the requested name
                        for (int i = 0; i < items.Count; i++) //loops through all items to find the target
                        {
                            if (items[i].itemName.ToLower() == target.ToLower())
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
                           
                        }
                        else
                        {
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

                        
                    }
                    else if (input.Contains("try") || input.Contains("t "))
                    {
                        string target;
                        if (input.Contains("try")) { target = input.Replace("try ", ""); }
                        else { target = input.Replace("t ", ""); } 

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
                            break;
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
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Input either 'block' or 'parry' with 'try' command");
                            Console.ReadLine();
                        }

                        
                    }
                    else if (input.Contains("chk") || input.Contains("c "))
                    {
                        List<Items> items = player.Items;// the items the player has
                        Items targetItem = null; //for interacting with items that match the requested name

                        string target;
                        if (input.Contains("chk")) { target = input.Replace("chk ", ""); }
                        else { target = input.Replace("c ", ""); }
                        for (int i = 0; i < items.Count; i++) //loops through all items to find the target
                        {
                            if (items[i].itemName.ToLower() == target)
                            {
                                targetItem = items[i];

                            }
                        }
                        Console.WriteLine("_____________");
                        Console.WriteLine("Item Name: {0}",targetItem.itemName);

                        Console.WriteLine("Item needs spell: {0}", targetItem.requiresSpell);

                        if (targetItem.itemHeals)
                        {
                            Console.WriteLine("Heals the player by {0}", targetItem.HealAmount);
                        }
                        if (targetItem.itemDamages)
                        {
                            if (targetItem.splashDamage)
                            {
                                Console.WriteLine("Does {0} damage to all enemies", targetItem.DamageAmount);
                            }
                            else
                            {
                                Console.WriteLine("Does {0} damage to single target", targetItem.DamageAmount);
                            }

                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                    else if (input.Contains("hlp") || input.Contains("h "))
                    {
                        InputHelp();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                    else if (input.Contains("devop"))
                    {
                        int amount = Convert.ToInt32(Console.ReadLine());
                        List<Enemy> devEnemiesList = new List<Enemy>();

                        for (int i = 0; i < amount; i++)
                        {
                            Enemy addedEnemy = RanEnemies(player.round);
                            addedEnemy.enemyIndex = i.ToString();
                            Console.WriteLine(i);
                            Console.ReadLine();
                            devEnemiesList.Add(addedEnemy);
                        }
                        Enemy[] devEnemiesArray = devEnemiesList.ToArray();
                        Battle(player, devEnemiesArray);
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

                    Enemy[] updatedEnemies = enemiesList.ToArray<Enemy>(); //I use params so I can have unlimited enemies, so I need to transfer between array and list.
                    UpdateBattleGui(player, updatedEnemies);
                }
            }
        }
        public static void Battle(Player player, params Enemy[] enemies) //This is the main loop of the battle logic
        {
            
            Console.ForegroundColor = ConsoleColor.White;

            Enemy targetEntity = null;
            List<Enemy> enemiesList = new List<Enemy>();
            enemiesList = enemies.ToList(); //I use params so I can have unlimited enemies, so I need to transfer between array and list.

            int remainingTurns;
            string Turn = "";
            for (int i = 0; i < enemies.Length; i++) //loops through all enemies to who goes first and sets ups the enemies index numbers
            {
                enemiesList[i].enemyIndex = i.ToString();
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

            //Loops till no enemies remaining
            while (enemiesList.Count != 0 && enemies.Length != 0)
            {

                enemies = enemiesList.ToArray(); //I use params so I can have unlimited enemies, so I need to transfer between array and list.


                if (player.isparrying)
                {
                    Turn = "player";
                }
                if (Turn == "player")
                {
                    remainingTurns = player.Speed; //use this to keep track of remaining turns (using seperate allows me to edit it if needed, without shanging how the system runs)

                    Console.Title = "Battle: Player";
                    UpdateBattleGui(player, enemies);//just making sure the player is updated by updating the gui
                    
                    for (int i = player.Speed; i != 0; i--)
                    {
                        //Checks enemy status
                        for (int k = 0; k < enemiesList.Count; k++) //loops through all enemies to who is alive before every turn the player has
                        {
                            enemiesList[k].CheckHealth();
                            if (enemiesList[k].isdead)
                            {
                                
                                

                                PickupLoot(player, enemiesList[k]);

                                
                                enemiesList.Remove(enemiesList[k]);
                                enemies = enemiesList.ToArray();
                                
                                UpdateBattleGui(player, enemies);
                                k--;
                            }
                        }
                        
                        remainingTurns--;
                        Console.WriteLine("\nTurns remaining: "+remainingTurns);

                        //Runs player turn code
                        PlayerTurn(player, enemiesList, enemies);
                    }
                    Turn = "enemy";
                }

                if (Turn == "enemy")
                {
                    //Checks enemy status
                    for (int k = 0; k < enemiesList.Count; k++) //loops through all enemies to who is alive before every turn the player has
                    {
                        enemiesList[k].CheckHealth();
                        if (enemiesList[k].isdead)
                        {



                            PickupLoot(player, enemiesList[k]);


                            enemiesList.Remove(enemiesList[k]);
                            enemies = enemiesList.ToArray();

                            UpdateBattleGui(player, enemies);
                            k--;
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
                    
                    if (player.isblocking == true)
                    {
                        player.isblocking = false;
                    }
                    Turn = "player";
                }

            }

            Console.WriteLine("!!!Battle Over!!!"); //When all enemies are defeated this runs
            player.score++;
        }
        
        public static void Shop(Player player)//manages the shop
        {
            int frame = 0;

            Console.Title = "Shop";

            Items items1 = RanShopItems(); //not in loop so shop items and weapons only refreshes every time you enter it
            Items items2 = RanShopItems();
            Items items3 = RanShopItems();
            Items items4 = RanShopItems();
            Weapon weapon = RanShopWeapon(player.round);

            // Create a timer with a two second interval.
            var aTimer = new System.Timers.Timer(200); //A timer that is set for 2 seconds
            aTimer.AutoReset = true;//The timer resets every time it elapses
            aTimer.Enabled = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += (sender, e) => frame++; //Outside loop so multiple frame events aren't made
            aTimer.Elapsed += (sender, e) => WormUI(40, 5, frame);

            while (true) //repeating every time the imput is taken and statements are run, untill loop is broken by exit command
            {
                aTimer.Stop();//If I don't stop the timer while updating gui the cursor trys to print the snake while printing the gui
                UpdateShopGUI(player, items1, items2, items3, items4, weapon);
                aTimer.Start();
                

                string Input = Console.ReadLine().ToString(); //this is the input

                if (player.currentDoubloons >= 10 + player.Speed & (Input.ToLower() == "speed" || Input.ToLower() == "s"))
                {
                    player.currentDoubloons -= 10 + player.Speed;
                    player.Speed++;
                    
                }
                else if (player.currentDoubloons >= (2 + MathF.Round(player.BaseDamage)) & (Input.ToLower() == "damage" || Input.ToLower() == "d" ))
                {
                    player.currentDoubloons -= Convert.ToInt32(2 + MathF.Round(player.BaseDamage));
                    player.BaseDamage += 0.1f;
                    
                }
                else if (player.currentDoubloons >= 1 & (Input.ToLower() == "health" || Input.ToLower() == "h" || Input.ToLower() == "m" || Input.ToLower() == "max-health"))
                {
                    float prevHealth = player.CurrentHealth;
                    player.MaxHealth += player.MaxHealth/10;
                    player.CurrentHealth = prevHealth;
                    player.currentDoubloons -= 1;
                }
                else if (player.currentDoubloons >= items1.ItemPrice & Input.ToLower() == "1" || Input.ToLower() == items1.itemName.ToLower())
                {
                    player.Items.Add(items1);
                    player.currentDoubloons -= items1.ItemPrice;
                    Console.WriteLine(items1.itemName + " Bought");
                }
                else if (player.currentDoubloons >= items2.ItemPrice & Input.ToLower() == "2" || Input.ToLower() == items2.itemName.ToLower())
                {
                    player.Items.Add(items2);
                    player.currentDoubloons -= items2.ItemPrice;
                    Console.WriteLine(items2.itemName + " Bought");
                }
                else if (player.currentDoubloons >= items3.ItemPrice & Input.ToLower() == "3" || Input.ToLower() == items3.itemName.ToLower())
                {
                    player.Items.Add(items3);
                    player.currentDoubloons -= items3.ItemPrice;
                    Console.WriteLine(items4.itemName + " Bought");
                }
                else if (player.currentDoubloons >= items4.ItemPrice & Input.ToLower() == "4" || Input.ToLower() == items4.itemName.ToLower() )
                {
                    player.Items.Add(items4);
                    player.currentDoubloons -= items4.ItemPrice;
                    Console.WriteLine(items4.itemName + " Bought");
                }
                else if (player.currentDoubloons >= weapon.Cost & Input.ToLower() == "5" || Input.ToLower() == weapon.weaponName.ToLower())
                {
                    player.CurrentWeapon = weapon;
                    player.currentDoubloons -= weapon.Cost;
                    Console.WriteLine(weapon.weaponName + " Bought");
                }
                else if (Input.ToLower() == "exit" || Input.ToLower() == "e")
                {
                    aTimer.Stop();
                    break;
                }
                else if (Input.Contains("use") || Input.Contains("u "))
                {
                    string target;
                    if (Input.Contains("use")) { target = Input.Replace("use ", ""); }
                    else { target = Input.Replace("u ", ""); }

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
                    
                    if (!selectedItems[0].itemDamages)
                    {
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

                                    targetItem.UseItem(inputAmount, targetItem, null, player);
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
                    else
                    {
                        Console.WriteLine("Can't use Damageing items in shop");
                        Thread.Sleep(1000);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Wrong input or not enough doubloons");
                }

                
            }


            

        }

        private static Items RanShopItems() //gets random shop item
        {
            Items SelectedItem;
            List<Items> items = new List<Items>();  //So I can add and edit the items
            Random random = new Random(); //to chose random item

            Items mikuLeech = CreateItem("Miku's Leek", 0, 100, 1, true, 5, "Miku Miku BEAM!");

            Items chugJug = CreateItem("Chug Jug", 50, 0, 2, false);

            Items boogieBomb = CreateItem("Boogie Bomb", 0, 10, 1, false);
            boogieBomb.splashDamage = true;

            Items GibsonFlyingV = CreateItem("Gibson flying v with an vibrato", 100, 1000, 5, true, 10, "Nothing can happen till you swing the bat");

            Items fruitSalad = CreateItem("Fruit Salad", 100, 0, 3, false);

            Items tetoBaguette = CreateItem("Teto's Baguette", 200, 0, 5, false);

            items.Add(tetoBaguette);
            items.Add(mikuLeech);
            items.Add(chugJug);
            items.Add(boogieBomb);
            items.Add(GibsonFlyingV);
            items.Add(fruitSalad);


            SelectedItem = items[random.Next(0,items.Count)];   //Gives a random item
            return SelectedItem;
        }
        private static Weapon RanShopWeapon(int round) //gets random shop weapon
        {
            Weapon weapon;

            List<Weapon> selectedWeapons = new List<Weapon>(); //stores all weapons
            Random random = new Random();
            

            if (round <= 5)
            {
                selectedWeapons.Add(CreateWeapon(169f, "Chunchunmaru", 10));
                selectedWeapons.Add(CreateWeapon(169f, "Chunchunmaru", 10));
                selectedWeapons.Add(CreateWeapon(75f, "Spatula", 4));
                selectedWeapons.Add(CreateWeapon(75f, "Spatula", 4));
                selectedWeapons.Add(CreateWeapon(75f, "Spatula", 4));
                selectedWeapons.Add(CreateWeapon(75f, "Spatula", 4));
                selectedWeapons.Add(CreateWeapon(90f, "pot", 4));
                selectedWeapons.Add(CreateWeapon(90f, "pot", 4));
                selectedWeapons.Add(CreateWeapon(90f, "pot", 4));
                selectedWeapons.Add(CreateWeapon(100f, "toy knife", 5)); //I add items multiple times to incease their chance
                selectedWeapons.Add(CreateWeapon(100f, "toy knife", 5));
                selectedWeapons.Add(CreateWeapon(100f, "toy knife", 5));
            }
            else if(round > 5 && round < 10)// after round 5 the user can get better weapons (so it doen't get too difficult)
            {
                selectedWeapons.Add(CreateWeapon(200f, "1965 Vespa Super Sport 180", 20));
                selectedWeapons.Add(CreateWeapon(1000f, "Death Note", 100));
                selectedWeapons.Add(CreateWeapon(400f, "1957 Les Paul Custom Reissue", 35));
                selectedWeapons.Add(CreateWeapon(500f, "Musashi's kaneshige koshirae", 40));
                selectedWeapons.Add(CreateWeapon(600f, "AGL Arms", 50));
            }
            else
            {
                selectedWeapons.Add(CreateWeapon(10000f, "omnipotence", 400));
                selectedWeapons.Add(CreateWeapon(2000f, "Inifinity Guantlent", 120));
                selectedWeapons.Add(CreateWeapon(5000f, "Dokuro-chan's bludgeoning stick", 250));
                selectedWeapons.Add(CreateWeapon(50000f, "Garfield", 1000));
                selectedWeapons.Add(CreateWeapon(1000000f, "Command Block", 10000));
            }
            




            weapon = selectedWeapons[random.Next(0, selectedWeapons.Count)]; //choses and returns random weapon

            return weapon;
        }
        private static Enemy RanEnemies(int round)//gets random enemy
        {
            Enemy SelectedEnemy;
            List<Enemy> enemies = new List<Enemy>();  //So I can add and edit the items
            Random random = new Random();

            float ProgressiveDif = Convert.ToInt32((Math.Pow(2, round)));//this is the exponential equation foor the difficulty scaling



            if (round == 1)
            {
                ProgressiveDif = 0;
            }

            Enemy bob = CreateEnemy("Apple Core", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy gob = CreateEnemy("Old Pear", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy hob = CreateEnemy("Orange peels", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy bodhiG = CreateEnemy("great bodhi scrap", (100 * round) + (ProgressiveDif), (50 * round) + (ProgressiveDif), 2, round * 5);
            bodhiG.droppedWeapon = CreateWeapon(100*round, "Rubber handled food-themed mallet");
            Enemy goblin = CreateEnemy("Cucumber Goblin", (10 * round) + (ProgressiveDif), (20 * round) + (ProgressiveDif), 2, round);
            Enemy carrot = CreateEnemy("Half Eaten Carrot", (20 * round) + (ProgressiveDif), (100 * round) + (ProgressiveDif), 1, round * 3);
            Enemy cabbage = CreateEnemy("Rotten Cabbage", (150 * round) + (ProgressiveDif), ProgressiveDif/10 + 10, 1, round * 3);
            Enemy bone = CreateEnemy("Chicken Bones", (80 * round) + (ProgressiveDif), (40 * round) + (ProgressiveDif), 1, round * 3);
            bone.droppedWeapon = CreateWeapon(110, "Bonking Bone");



            enemies.Add(bob);
            enemies.Add(bone);
            enemies.Add(goblin);
            enemies.Add(gob);
            enemies.Add(hob);
            enemies.Add(bob);
            enemies.Add(gob);
            enemies.Add(hob);
            enemies.Add(bodhiG);
            enemies.Add(carrot); //I add items twice to incease there chance
            enemies.Add(carrot);
            enemies.Add(cabbage);
            enemies.Add(cabbage);



            SelectedEnemy = enemies[random.Next(0, enemies.Count)];   //Gives a random item
            return SelectedEnemy;
        }



        //  Other methods
        private static Enemy FindEnemy(string target, List<Enemy> enemies) //Code if I need to find Enemy
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
        public static void PickupLoot(Player player, Enemy enemy) //handels item and wepon drops from enemies
        {
            Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine("\n" + enemy.EnemyName + " Died!");

            player.currentDoubloons += enemy.Doubloons;

            //checks if the enemy has items if it does code runs else nothing happens
            if (enemy.droppedWeapon != null)
            {
                Console.WriteLine("Do you want to take the weapon Y/N\n {0} [{1}]", enemy.droppedWeapon.weaponName, enemy.droppedWeapon.damage); //incase player has better weapon
                string input = Console.ReadLine();
                if (input.ToLower() == "y")
                {
                    player.CurrentWeapon = enemy.droppedWeapon;
                }
                
            }
            if (enemy.droppedItems != null)
            {
                for(int i = 0; i < enemy.droppedItems.Count; i++)
                {
                    player.Items.Add(enemy.droppedItems[i]);
                } 
            }

            Console.WriteLine("\n Enter to continue:");
            Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
        }


            //  MAKE CLASSES
        public static Enemy CreateEnemy(string name, float maxHealth, float attackDamage, int speed, int doubloons) //makes enemy class object and returns it
        {
            Enemy enemy = new Enemy();
            enemy.EnemyName = name;
            enemy.MaxHealth = maxHealth;
            enemy.AttackDamage = attackDamage;
            enemy.Speed = speed;
            enemy.Doubloons = doubloons;


            return enemy;
        }
        public static Player CreatePlayer(string name, float maxHealth, int speed) //makes player class object and returns it
        {
            Player player = new Player();
            player.UserName = name;
            player.MaxHealth = maxHealth;
            player.Speed = speed;
            player.BaseDamage = 1f;
            player.isdead = false;
            player.currentDoubloons = 10;

            player.CurrentHealth = maxHealth;

            return player;
        }
        public static Items CreateItem(string name, float healAmount, float damageAmount, int cost, bool needSpell, int spellTimeLimit = 0, string spellWords = "") //makes items class object and returns it
        {
            //automated bools (execpt spells) in main code
            Items item = new Items();
            item.itemName = name;

            item.HealAmount = healAmount;
            item.DamageAmount = damageAmount;

            item.requiresSpell = needSpell;
            item.spellTimeLimit = spellTimeLimit;
            item.itemSpellName = spellWords;
            item.ItemPrice = cost;
            



            return item;
        }
        public static Weapon CreateWeapon(float damage, string name, int cost = 0) //makes weapon class object and returns it
        {
            Weapon weapon = new Weapon();
            weapon.damage = damage;
            weapon.weaponName = name;
            weapon.Cost = cost;

            return weapon;
        }



        

            //  PRINT GUI
        private static void InputHelp() { Console.WriteLine("\n\nInput___________________\n\n'Atk' + [enemy name] <--> To attack an enemy\n\n 'Use' + [itemName] <--> To use an item\n\n 'Chk' + [itemName] <--> To check an items use\n\n 'Try' + [block/parry] <--> To attempt a block quicktime\n\n 'Hlp' <--> To get the input list again\n\n An example of a command is:    Atk dude ( The + represents a space! )\n________________________"); }
        private static void PrintPlayer(Player player, bool printItems, int colomnPos, int itemWidth = 0) //prints player gui
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            if (itemWidth == 0) //if o input it will just go to the widow width
            {
                itemWidth = Console.WindowWidth;
            }

            //____Player GUI____
            Console.WriteLine("\n\n"); //so name is more visible
            Console.SetCursorPosition(colomnPos, Console.CursorTop); //goes to middle of console and down 5 rows
            
            

            

            //Username
            Console.WriteLine(player.UserName);
            Console.WriteLine(""); //so name is more visible

            if (player.CurrentHealth<(player.MaxHealth/3f))
            {
                
                //Health
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(colomnPos + 12, Console.CursorTop - 1); //This should replace the current health in heal with a red version indecating low health
                Console.WriteLine("Health <==> {0} / {1}", player.CurrentHealth, player.MaxHealth);

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.SetCursorPosition(colomnPos, Console.CursorTop); //goes to middle of console

            }
            else
            {
                //Health
                Console.SetCursorPosition(colomnPos, Console.CursorTop); //goes to middle of console
                Console.WriteLine("Health <==> {0} / {1}", player.CurrentHealth, player.MaxHealth);

            }

            
            //Speed
            Console.SetCursorPosition(colomnPos, Console.CursorTop);
            Console.WriteLine("Speed <==> {0}", player.Speed);
            //Damage mult
            Console.SetCursorPosition(colomnPos , Console.CursorTop);
            Console.WriteLine("Damage Mult <==> {0}", player.BaseDamage.ToString("n1"));

            //Damage
            Console.SetCursorPosition(colomnPos, Console.CursorTop);
            Console.WriteLine("Weapon: {0}", player.CurrentWeapon.weaponName);
            Console.SetCursorPosition(colomnPos, Console.CursorTop);
            Console.WriteLine("Damage <==> {0}", player.CurrentWeapon.damage);

            //Damage
            Console.SetCursorPosition(colomnPos, Console.CursorTop);
            Console.WriteLine("Total Damage <==> {0}", (player.BaseDamage * player.CurrentWeapon.damage).ToString("n1"));


            //Items
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.WriteLine("Items:");
            int columnPos2 = 0;

            if (printItems == true)//if inputs true items are printed else they aren't
            {

                //prints all items player has
                foreach (Items item in player.Items)
                {
                    //I make sure there is two lots of items space so it looks cleaner and doesn't overlap in the shop
                    if ((columnPos2 + (item.itemName.Length + 2)*2) < itemWidth) //If the text wont overflow
                    {
                        Console.WriteLine(item.itemName);
                        columnPos2 += item.itemName.Length + 2; //moves along so theres enough room
                        Console.SetCursorPosition(columnPos2, Console.CursorTop - 1);

                    }
                    else// So when there is no space to fit the string the cursor will reset the column and go down two rows
                    {

                        columnPos2 = 0;
                        Console.WriteLine(item.itemName);
                        Console.SetCursorPosition(columnPos2, Console.CursorTop);
                    }
                    
                }
            }
        }
        private static void PrintEnemy(Enemy enemy ,int columnPos, int rowShift)//prints enemy gui
        {

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(columnPos, Console.CursorTop - 1 + rowShift); //goes up a row to last line, and to the column position

            Console.WriteLine(enemy.EnemyName + " - " + enemy.enemyIndex); //list starts at 0 so I minus 1

            Console.SetCursorPosition(columnPos + 1, Console.CursorTop + 1);
            Console.WriteLine("Health <==> {0} ", enemy.CurrentHealth.ToString("n1")); //this makes it go to the correcnt collunm

            Console.SetCursorPosition(columnPos + 2, Console.CursorTop);
            Console.WriteLine("Speed <==> {0}", enemy.Speed);

            Console.SetCursorPosition(columnPos + 3, Console.CursorTop);
            Console.WriteLine("Damage <==> {0}", enemy.AttackDamage);

            Console.SetCursorPosition(columnPos, Console.CursorTop - 3); // as I added 3 lines I need to take away 3 or enemies will be too far apart

            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void UpdateBattleGui(Player player, params Enemy[] enemies)//prints player and enemy gui in correct order
        {
            Console.ForegroundColor = ConsoleColor.White;






            if (enemies.Length > 0) // So It doesn't crash
            {


                //Refreshs the console
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                Console.WriteLine("\nRound: {0}\n", player.round);

                int rowPos = Console.CursorTop; //Used to track where the last row was and move from there
                int columnPos = 0;  //Used to track where the last row was and move from there
                int width = Console.WindowWidth - enemies[enemies.Count() - 1].EnemyName.Length; //the width of the collumn minus the chars(should be 1 column per char) the first string takes up

                Console.WriteLine("\n____________________\nEnemies:\n");

                int remainingEnemies = 0; // This is to know how many enemies there are

                //Enemy GUI -----

                int rowShift = 0; //Incase I need to shift The printed variable vertically

                remainingEnemies = enemies.Count();

                int enemyPacket;
                if (player.round > 10)
                {
                    enemyPacket = 4;
                }
                else
                {
                    enemyPacket = 7;
                }

                while (remainingEnemies > enemyPacket) //This makes the enemies print in packets of seven preventing them from overlapping or overflowing
                {

                    remainingEnemies = remainingEnemies - enemyPacket; //removes seven from total then prints them
                    Console.WriteLine("\n");

                    List<Enemy> updateEnemies = enemies.ToList();

                    for (int i = enemyPacket; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
                    {

                        columnPos = (width / enemyPacket) * (i - 1);//doing -1 cause it looks good --collumn pos is equal to ratio of enemy size to window size (was eg. width * 1/5) times the amount of enemies - 1
                        PrintEnemy(enemies[i - 1], columnPos, rowShift);
                        columnPos += width / enemyPacket; //moves along a section of total width
                        updateEnemies.Remove(enemies[i - 1]);
                        Thread.Sleep(100);
                        enemies = updateEnemies.ToArray();
                    }
                    


                }
                for (int i = remainingEnemies; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
                {
                    columnPos = (width / remainingEnemies) * (i - 1);//doing -1 cause it looks good --collumn pos is equal to ratio of enemy size to window size (was eg. width * 1/5) times the amount of enemies - 1
                    PrintEnemy(enemies[i - 1], columnPos, rowShift);
                    columnPos += width / remainingEnemies; //moves along a section of total width
                    Thread.Sleep(100);
                }



                //Player GUI -----
                PrintPlayer(player, true, width / 2);



                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("No Enemies!");
                return;
            }


        }
        public static void UpdateShopGUI(Player player, Items items1, Items items2, Items items3, Items items4, Weapon weapon) //prints shop gui
        {
            //Refreshs the console
            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            PrintPlayer(player, true, 0, Console.WindowWidth / 2); //So player is right side to the shop

            Console.ForegroundColor = ConsoleColor.Magenta;

            int rowPos = Console.WindowTop + 3;

            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine("Shop_________________________________________");
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos + 1);
            Console.WriteLine("Upgrades_________________________");
            rowPos += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" Speed: {0} Doubloons per 1",10+player.Speed);
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" Damage: {0} Doubloons per .1", (2 + MathF.Round(player.BaseDamage)));
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" Max-Health: 1 Doubloons per 10");
            rowPos += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine("Items_________________________");
            rowPos += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" 1: {0}, cost: {1}", items1.itemName, items1.ItemPrice);
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" 2: {0}, cost: {1}", items2.itemName, items2.ItemPrice);
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" 3: {0}, cost: {1}", items3.itemName, items3.ItemPrice);
            rowPos++;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" 4: {0}, cost: {1}", items4.itemName, items4.ItemPrice);
            rowPos += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine("Weapon_________________________");
            rowPos += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, rowPos);
            Console.WriteLine(" 5: {0}[{2}], cost: {1}", weapon.weaponName, weapon.Cost, weapon.damage);

            Console.WriteLine("\n\n\nCurrent Doubloons Owned: " + player.currentDoubloons);
            Console.WriteLine("\nInput numbers for items; speed, damage, health, or the first letter for upgrades;\nU or use to use followed by [item name] (only healing items); and exit to leave the shop");

            Console.ForegroundColor = ConsoleColor.DarkCyan;
        }
        private static void WormUI(int colomnPos, int down, int frame = 1) //prints worm gui based on what frame it is
        {
            //Worm Image
            Console.CursorVisible = false;

            int lastcoloumnPos = Console.CursorLeft;
            int lastrowPos = Console.CursorTop;

            for (int i = 3; i > 0; i--)//clears previous worm
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + i);
                Console.WriteLine("        ");//Clear
            }

            //Every frame has a unique ascii art

            if (frame % 8 == 0)
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1); //goes to inputed row and column of console
                Console.WriteLine(@" | \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@" |  |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@" /  /");

                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 4);//So no flickering
                Console.WriteLine("        ");//Clear
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 4);
                Console.WriteLine(@"\''/");

            }
            else if (frame % 8 == 1)
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1); //goes to inputed row and column of console
                Console.WriteLine(@"  | \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@" |  |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@"/  /");

                
            }
            else if (frame % 8 == 2)
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1); //goes to inputed row and column of console
                Console.WriteLine(@"  / \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@" /  /");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@"/  /");
                
            }
            else if (frame % 8 == 3) 
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1); //goes to inputed row and column of console
                Console.WriteLine(@" / \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@"/  /");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@"|  |");
            }
            else if (frame % 8 == 4)
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1);
                Console.WriteLine(@" / |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@"|  |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@"\  \");

                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 4);//So no flickering
                Console.WriteLine("        ");//Clear
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 4);
                Console.WriteLine(@" \''/");
            }
            else if (frame % 8 == 5) 
            {
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1);
                Console.WriteLine(@"/ |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@"|  |");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@" \  \");

            }
            else if (frame % 8 == 6) //every first frame will be this ascii
            {

                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1);
                Console.WriteLine(@"/ \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@"\  \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@" \  \");
            }
            else if (frame % 8 == 7) //every first frame will be this ascii
            {

                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 1);
                Console.WriteLine(@"/ \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 2);
                Console.WriteLine(@"\  \");
                Console.SetCursorPosition(colomnPos, Console.WindowTop + down + 3);
                Console.WriteLine(@" |  |");
            }
            
            Console.SetCursorPosition(colomnPos-2, Console.WindowTop + down + 6);
            Console.WriteLine(@" ^ you ^ ");

            Console.SetCursorPosition(lastcoloumnPos,lastrowPos); //goes last position
            Console.CursorVisible = true;


        }

    }



}
