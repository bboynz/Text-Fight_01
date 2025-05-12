using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Fight.Entities;

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
        public float HealAmount;

        public bool itemDamages;  // If the item damages, and how much it does
        public float DamageAmount;



        public void UseItem(Enemy enemy, Player player, int useAmount, Items item) //will make sure to make parameter null if input isn't needed
        {
            Console.WriteLine("Item Used"); //Basic use here

            
            if (item.itemHeals) // Heal Logic
            {
                item.HealItem(player, useAmount, item);
            }

            if (item.itemDamages) // Damage Logic
            {
                item.DamageItem(enemy, useAmount, item);
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

            Console.WriteLine("Item Used");


            return damageAmount;
        }
    }
}
