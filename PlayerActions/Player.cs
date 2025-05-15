using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Fight.Entities;
using Text_Fight.PlayerActions;

namespace Text_Fight.PlayerActions
{
    class Inventory
    {
    }
    class Items
    {
        public string itemName = "";
        public int itemID; // Incase I need to Sort items;


        public bool itemHeals; // If the item heals, and how much it does
        private float healamount = 0;
        public float HealAmount //Handels bool logic so I can minimize how many variable i need to input when making items
        { 
            get {
                return healamount;
            }
            set {
                healamount = value;
                if (healamount < 0)
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
                if (healamount < 0)
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
        public void UseItem(int useAmount, Items item, Enemy enemy, Player player) //will make sure to make parameter null if input isn't needed
        {
            Console.WriteLine("Item Used"); //Basic use here

            
            

            if (item.requiresSpell) // If a spell is require it will run a quick time using the spell name and time limit
            {
                if (QuickTime.WordQuickTime(item.spellTimeLimit, item.itemSpellName, "", "Try again"))
                {
                    if (item.itemHeals) // Heal Logic
                    {
                        item.HealItem(player, useAmount, item);
                    }

                    if (item.itemDamages) // Damage Logic
                    {
                        item.DamageItem(enemy, useAmount, item);
                    }
                }

            }
            else if (!item.requiresSpell)
            {
                if (item.itemHeals) // Heal Logic
                {
                    item.HealItem(player, useAmount, item);
                }

                if (item.itemDamages) // Damage Logic
                {
                    item.DamageItem(enemy, useAmount, item);
                }
            }

        }

        public float HealItem(Player player, int useAmount, Items item) //I will input target when calling the method and also how many item the player uses
        {
            float healAmount = 0; //Local variable to keep track of heal amount

            if (item.itemHeals == true)   //check if it is a healing item
            {
                healAmount = item.HealAmount;


                Console.WriteLine("Subject damaged");
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
