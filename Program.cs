using System.Numerics;
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
        private static void ResetGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
        private static void Tutorial()
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
        public static void StartRun()
        {
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

            int enemyProgress = 1;

            while (!player.isdead) // main game loop
            {
                player.round++;

                Console.WriteLine("\n\n Press enter to start Round!\n\n");
                Console.ReadLine();
                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! '" + @"\" + "(>.<).  !"));
                QuickTime.DramaticWrite(1, ("LETS GO! .(>.<)/'  !"));


                List<Enemy> enemies = new List<Enemy>();

                
                if (player.round % 2 == 0) //every even round adds an enemy
                {
                    enemyProgress++;
                }


                for (int i = enemyProgress; i > 0; i--)
                {
                    enemies.Add(RanEnemies(player.round));
                }



                Enemy[] SelectedEnemies = enemies.ToArray();

                Shop(player);

                Battle(player, SelectedEnemies);

            }
        }

        
        
            //  TURNS / BATTLES
        
        private static void EnemyTurn(Player player, Enemy enemy, List<Enemy> enemiesList, params Enemy[] enemies)
        {
            if (enemies.Length > 0)
            {
                Console.WriteLine("Enemy Turn\n\npls wait");
                Thread.Sleep(1000);
                
                if (player.isparrying)
                {
                    enemy.Damage(enemy.MaxHealth/10);
                }

                //enemy Turn
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
            player.isblocking = false;
            player.isvulnerable = false;
            player.isparrying = false;

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
                    
                    Console.WriteLine("\nPlayer's Turn!");
                    Console.WriteLine("Input 'hlp' for commands");
                    Console.WriteLine("\n\n"); // so when answer is incorrect it doesn't delete said txt (If I use Set cursor position it goes out of window bounds)
                    string input = Console.ReadLine().ToString().ToLower();

                    if (input.Contains("atk") || input.Contains("a "))
                    {

                        string target; //Allows for both inputs (could just check if input contain enemy name but that would mean enemies can't have different version of name ex: carrot and evil carrot ; if evil carrot was first it would attack that instead of carrot)
                        if (input.Contains("atk")) { target = input.Replace("atk ", ""); }
                        else { target = input.Replace("a ", ""); }
                            
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
                            break;
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

            int remainingTurns;
            string Turn = "";
            for (int i = 0; i < enemiesList.Count; i++) //loops through all enemies to who goes first and sets ups the enemies index numbers
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

                enemies = enemiesList.ToArray();
               

                if (player.isparrying)
                {
                    Turn = "player";
                }
                if (Turn == "player")
                {
                    remainingTurns = player.Speed;

                    Console.Title = "Battle: Player";
                    UpdateBattleGui(player, enemies);
                    
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
                    Turn = "player";
                }

            }

            Console.WriteLine("!!!Battle Over!!!");
            player.score++;
        }
        
        public static void Shop(Player player)
        {
            int frame = 0;

            Console.Title = "Shop";

            Items items1 = RanShopItems();
            Items items2 = RanShopItems();
            Items items3 = RanShopItems();
            Items items4 = RanShopItems();
            Weapon weapon = RanShopWeapon();

            // Create a timer with a two second interval.
            var aTimer = new System.Timers.Timer(200); //A timer that is set for 2 seconds
            aTimer.AutoReset = true;//The timer resets every time it elapses
            aTimer.Enabled = true;
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += (sender, e) => frame++; //Outside loop so multiple frame events aren't made
            aTimer.Elapsed += (sender, e) => WormUI(40, 5, frame);

            while (true)
            {
                aTimer.Stop();
                UpdateShopGUI(player, items1, items2, items3, items4, weapon);
                aTimer.Start();
                

                string Input = Console.ReadLine().ToString();

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
                    player.MaxHealth += 10f;
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

        private static Items RanShopItems()
        {
            Items SelectedItem;
            List<Items> items = new List<Items>();  //So I can add and edit the items
            Random random = new Random();

            Items mikuLeech = CreateItem("Miku's Leek", 0, 100, 1, true, 5, "Miku Miku BEAM!");

            Items chugJug = CreateItem("Chug Jug", 50, 0, 2, false);

            Items boogieBomb = CreateItem("Boogie Bomb", 0, 10, 2, false);
            boogieBomb.splashDamage = true;

            Items GibsonFlyingV = CreateItem("Gibson flying v with a vibrato", 100, 1000, 5, true, 10, "Nothing can happen till you swing the bat");

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
        private static Weapon RanShopWeapon()
        {
            Weapon weapon;

            List<Weapon> selectedWeapons = new List<Weapon>();
            Random random = new Random();

            selectedWeapons.Add(CreateWeapon(169f, "Chunchunmaru",10));
            selectedWeapons.Add(CreateWeapon(75f, "Spatula",4));
            selectedWeapons.Add(CreateWeapon(75f, "Spatula", 4));
            selectedWeapons.Add(CreateWeapon(100f, "toy knife",5)); //I add items twice to incease there chance
            selectedWeapons.Add(CreateWeapon(100f, "toy knife", 5));


            weapon = selectedWeapons[random.Next(0, selectedWeapons.Count)];

            return weapon;
        }
        private static Enemy RanEnemies(int round)
        {
            Enemy SelectedEnemy;
            List<Enemy> enemies = new List<Enemy>();  //So I can add and edit the items
            Random random = new Random();

            if (round%2 == 0){
                round = round / 2;
            }
            else
            {
                if(round != 1){
                    round -= 1;
                }
                
            }

            float ProgressiveDif = Convert.ToInt32((Math.Pow(4, round)));



            if (round == 1)
            {
                ProgressiveDif = 0;
            }

            Enemy bob = CreateEnemy("Apple", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy gob = CreateEnemy("Pear", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy hob = CreateEnemy("Orange", (50 * round) + (ProgressiveDif), (25 * round) + (ProgressiveDif), 1, round*3);
            Enemy bodhiG = CreateEnemy("great bodhi", (100 * round) + (ProgressiveDif), (50 * round) + (ProgressiveDif), 2, round * 5);
            bodhiG.droppedWeapon = CreateWeapon(120, "Rubber handled morningstar mallet");
            Enemy goblin = CreateEnemy("Goblin", (10 * round) + (ProgressiveDif), (20 * round) + (ProgressiveDif), 3, round);
            Enemy carrot = CreateEnemy("Carrot", (20 * round) + (ProgressiveDif), (100 * round) + (ProgressiveDif), 1, round * 3);
            Enemy cabbage = CreateEnemy("Cabbage", (200 * round) + (ProgressiveDif), ProgressiveDif/10 + 10, 1, round * 3);



            enemies.Add(bob);
            enemies.Add(gob);
            enemies.Add(hob);
            enemies.Add(bob);
            enemies.Add(gob);
            enemies.Add(hob);
            enemies.Add(bodhiG);
            enemies.Add(carrot);
            enemies.Add(carrot);
            enemies.Add(cabbage);
            enemies.Add(cabbage);



            SelectedEnemy = enemies[random.Next(0, enemies.Count)];   //Gives a random item
            return SelectedEnemy;
        }



        //  Other methods
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
        public static void PickupLoot(Player player, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;


            Console.WriteLine("\n" + enemy.EnemyName + " Died!");

            player.currentDoubloons += enemy.Doubloons;

            if (enemy.droppedWeapon != null)
            {
                Console.WriteLine("Do you want to take the weapon Y/N\n {0} [{1}]", enemy.droppedWeapon.weaponName, enemy.droppedWeapon.damage);
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
        public static Enemy CreateEnemy(string name, float maxHealth, float attackDamage, int speed, int doubloons)
        {
            Enemy enemy = new Enemy();
            enemy.EnemyName = name;
            enemy.MaxHealth = maxHealth;
            enemy.AttackDamage = attackDamage;
            enemy.Speed = speed;
            enemy.Doubloons = doubloons;


            return enemy;
        }
        public static Player CreatePlayer(string name, float maxHealth, int speed)
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
        public static Items CreateItem(string name, float healAmount, float damageAmount, int cost, bool needSpell, int spellTimeLimit = 0, string spellWords = "")
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
        public static Weapon CreateWeapon(float damage, string name, int cost = 0)
        {
            Weapon weapon = new Weapon();
            weapon.damage = damage;
            weapon.weaponName = name;
            weapon.Cost = cost;

            return weapon;
        }



        

            //  PRINT GUI
        private static void InputHelp() { Console.WriteLine("\n\nInput___________________\n\n'Atk' + [enemy name] <--> To attack an enemy\n\n 'Use' + [itemName] <--> To use an item\n\n 'Chk' + [itemName] <--> To check an items use\n\n 'Try' + [block/parry] <--> To attempt a block quicktime\n\n 'Hlp' <--> To get the input list again\n\n An example of a command is:    Atk dude ( The + represents a space! )\n________________________"); }
        private static void PrintPlayer(Player player, bool printItems, int colomnPos, int itemWidth = 0)
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
                Console.SetCursorPosition(colomnPos, Console.CursorTop); //goes to middle of console
                Console.WriteLine("Health <==> {0} / {1}", player.CurrentHealth, player.MaxHealth);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(colomnPos + 12, Console.CursorTop - 1); //This should replace the current health in heal with a red version indecating low health

                Console.ForegroundColor = ConsoleColor.DarkBlue;
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

            if (printItems == true)
            {


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
        private static void PrintEnemy(Enemy enemy ,int columnPos, int rowShift)
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
        public static void UpdateBattleGui(Player player, params Enemy[] enemies)
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

                while (remainingEnemies > 7) //This makes the enemies print in packets of seven preventing them from overlapping or overflowing
                {

                    remainingEnemies = remainingEnemies - 7; //removes seven from total then prints them
                    Console.WriteLine("\n");

                    for (int i = 7; i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
                    {
                        columnPos = (width / 7) * (i - 1);//doing -1 cause it looks good --collumn pos is equal to ratio of enemy size to window size (was eg. width * 1/5) times the amount of enemies - 1
                        PrintEnemy(enemies[i - 1], columnPos, rowShift);
                        columnPos += width / 7; //moves along a section of total width
                        Thread.Sleep(100);
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
        public static void UpdateShopGUI(Player player, Items items1, Items items2, Items items3, Items items4, Weapon weapon)
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
        private static void WormUI(int colomnPos, int down, int frame = 1)
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
