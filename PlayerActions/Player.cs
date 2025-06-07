using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Fight.Entities;
using Text_Fight.PlayerActions;
using Text_Fight;

namespace Text_Fight.PlayerActions
{
    class Weapon
    {
        public float damage;
        public string weaponName = "";
        public int Cost;

    }


    class Items
    {
        public string itemName = "";
        public int itemID; // Incase I need to Sort items;


        public bool shopItem;
        private int itemPrice = 0;
        public int ItemPrice //Handels bool logic so I can minimize how many variable i need to input when making items
        {
            get
            {
                return itemPrice;
            }
            set
            {
                itemPrice = value;
                if (itemPrice > 0)
                {
                    shopItem = true;
                }
                else
                {
                    shopItem = false;
                }
            }
        }


        public bool itemHeals; // If the item heals, and how much it does
        private float healamount = 0;
        public float HealAmount //Handels bool logic so I can minimize how many variable i need to input when making items
        { 
            get {
                return healamount;
            }
            set {
                healamount = value;
                if (healamount > 0)
                {
                    itemHeals = true;
                }
                else
                {
                    itemHeals = false;
                }
            } 
        }


        public bool itemDamages;  // If the item damages, and how much it does
        public bool splashDamage;
        private float damageamount = 0;
        public float DamageAmount //Handels bool logic so I can minimize how many variable i need to input when making items
        {
            get
            {
                return damageamount;
            }
            set
            {
                damageamount = value;
                if (damageamount > 0)
                {
                    itemDamages = true;
                }
                else
                {
                    itemDamages = false;
                }
                
            }
        }


        public bool requiresSpell; // spell will just be the item name
        public int spellTimeLimit; // how fast in seconds you need to type the name
        public string itemSpellName = "";
        //hit and miss messages can be manualy put in

        



        //Could add target variable if needed
        public void UseItem(int useAmount, Items item, Enemy[] enemies, Player player) //will make sure to make parameter null if input isn't needed
        {
            Console.WriteLine("Item Used"); //Basic use here

            Enemy enemy = null;



            if (item.requiresSpell) // If a spell is require it will run a quick time using the spell name and time limit
            {
                if (QuickTime.WordQuickTime(item.spellTimeLimit, item.itemSpellName, "", "Try again"))
                {

                    if (item.itemHeals) // Heal Logic
                    {
                        for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                        {
                            item.HealItem(player, useAmount, item);
                            player.Items.Remove(item);

                            Console.WriteLine("Player Healed");
                            Thread.Sleep(10 * 100);

                        }

                    }

                    if (item.itemDamages) // Damage Logic
                    {

                        if (splashDamage)
                        {
                            for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                            {
                                for (int k = 0; k < enemies.Length; k++) //loops through all enemies to damage all enemies
                                {
                                    enemies[k].Damage(item.DamageAmount * player.BaseDamage);
                                }
                                player.Items.Remove(item);

                            }

                        }
                        else
                        {
                            while (enemy == null)
                            {
                                Console.WriteLine("Who to attack?");
                                string target = Console.ReadLine().ToString(); //Get name of enemy
                                for (int i = 0; i < enemies.Length; i++) //loops through all enemies to find the target
                                {
                                    if (enemies[i].EnemyName.ToLower() == target.ToLower() || enemies[i].enemyIndex == target)
                                    {
                                        enemy = enemies[i];
                                    }
                                }

                            }

                            Console.WriteLine("Attacks " + enemy.EnemyName);
                            for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                            {
                                enemy.Damage(item.DamageAmount * player.BaseDamage);
                                player.Items.Remove(item);

                            }

                            //  item.DamageItem(enemy, useAmount, item); // If I need any multiplier logiv or smth
                        }

                    }
                }

            }
            else if (!item.requiresSpell)
            {
                if (item.itemHeals) // Heal Logic
                {
                    for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                    {
                        item.HealItem(player, useAmount, item);
                        player.Items.Remove(item);

                        Console.WriteLine("Player Healed");
                        Thread.Sleep(10 * 100);

                    }

                }

                if (item.itemDamages) // Damage Logic
                {

                    if (splashDamage)
                    {
                        for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                        {
                            for (int k = 0; k < enemies.Length; k++) //loops through all enemies to damage all enemies
                            {
                                enemies[k].Damage(item.DamageAmount*player.BaseDamage);
                            }
                            player.Items.Remove(item);

                        }

                    }
                    else
                    {
                        while (enemy == null)
                        {
                            Console.WriteLine("Who to attack?");
                            string target = Console.ReadLine().ToString(); //Get name of enemy
                            for (int i = 0; i < enemies.Length; i++) //loops through all enemies to find the target
                            {
                                if (enemies[i].EnemyName.ToLower() == target.ToLower() || enemies[i].enemyIndex == target)
                                {
                                    enemy = enemies[i];
                                }
                            }

                        }

                        Console.WriteLine("Attacks " + enemy.EnemyName);
                        for (int i = 0; i < useAmount; i++) //Damages target for spefic amount for all items used
                        {
                            enemy.Damage(item.DamageAmount*player.BaseDamage);
                            player.Items.Remove(item);

                        }

                        //  item.DamageItem(enemy, useAmount, item); // If I need any multiplier logiv or smth
                    }

                }
            }

        }

        public float HealItem(Player player, int useAmount, Items item) //I will input target when calling the method and also how many item the player uses
        {
            float healAmount = item.HealAmount; //Local variable to keep track of heal amount

            for (int i = 0; i < useAmount; i++) //loops through all enemies to find the target
            {
                player.Heal( player.MaxHealth/(item.healamount/100) ); //Heals A percentacge of health 
            }

            return healAmount;
        }



        public float DamageItem(Enemy enemy, int useAmount, Items item) //I will input target when calling the method and also how many item the player uses
        {
            int damageAmount = 0; //Local variable to keep track of damage amount

            Console.WriteLine("Item Used to attack");
            return damageAmount;
        }
    }
}
