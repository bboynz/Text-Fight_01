using System;
using System.IO;
using System.Collections;
using System.Text;
using Text_Fight.Entities;
using Text_Fight.PlayerActions;
using Text_Fight.Enviroment;
using System.Data.SqlTypes;

namespace GameCycle
{

    class Program
    {
        
        static void Main(string[] args)
        {
            Player player = CreatePlayer("BootyBasher9000", 100, 2);

            Items mikuLeech = CreateItem("Miku's Leech", 0, 100, true, 10, "Miku Miku BEAM!");

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
            Enemy tob = CreateEnemy("Hob the tob", 100, 25, 1);

            Battle(player, bob, hob, gob);
        }

        public static void Battle(Player player, params Enemy[] enemies)
        {
            int curPosition = Console.CursorTop;
            int width = Console.WindowWidth - enemies[enemies.Count()- 1].EnemyName.Length; //the width of the collumn minus the chars(should be 1 column per char) the first string takes up
            Console.WriteLine("Enemies:\n");

            //Enemy GUI
            for (int i = enemies.Count(); i > 0; i--)//collumn position is split into the amount of enemies then names are printed over time with every time one split section is added
            {
                int columnPos = (width / enemies.Count()) *(i-1);//doing -1 cause it looks good
                Console.SetCursorPosition(columnPos, Console.CursorTop - 1); //goes up a row to last line, and to the column position

                Console.WriteLine(enemies[i - 1].EnemyName); //list starts at 0 so I minus 1
                
                Console.SetCursorPosition(columnPos+1, Console.CursorTop+1);
                Console.WriteLine("Health <==> {0} ", enemies[i - 1].CurrentHealth); //this makes it go to the correcnt collunm
                
                Console.SetCursorPosition(columnPos+2, Console.CursorTop);
                Console.WriteLine("Speed <==> {0}", enemies[i - 1].Speed);
                
                Console.SetCursorPosition(columnPos+3, Console.CursorTop);
                Console.WriteLine("Damage <==> {0}", enemies[i - 1].AttackDamage);

                Console.SetCursorPosition(columnPos, Console.CursorTop - 3); // as I added 3 lines I need to take away 3 or enemies will be too far apart

                columnPos += width / enemies.Count(); //moves along a section of total width


                
            }

            Console.SetCursorPosition(width/2, Console.CursorTop + 5); //goes to middle of console and down 5 rows
            //Username
            Console.WriteLine(player.UserName);

            //Health
            Console.SetCursorPosition(width / 2, Console.CursorTop); //goes to middle of console
            Console.WriteLine("Health <==> {0}", player.CurrentHealth);
            //Speed
            Console.SetCursorPosition(width / 2, Console.CursorTop); 
            Console.WriteLine("Health <==> {0}", player.CurrentHealth);

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
                    Console.SetCursorPosition(columnPos2, Console.CursorTop +2);
                    Console.WriteLine(item.itemName);
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

    }



}
