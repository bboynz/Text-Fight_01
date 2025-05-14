using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Fight.PlayerActions;

namespace Text_Fight.Entities
{
    class Enemy
    {
        private bool isdead;


        private float maxhealth; // this is private variable used in the getter setter
        public float MaxHealth
        {
            get
            {
                return maxhealth;
            }
            set
            {
                maxhealth = value;
                if (currentHealth < MaxHealth)
                {
                    currentHealth = MaxHealth;
                }
            }
        }

        // This is to keep track of current health
        private float currentHealth;
        public float CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                var previousHealth = currentHealth;
                currentHealth = Math.Clamp(value, 0, MaxHealth); //This makes sure that the value in between the correct amounts

                var healthUpdate = new HealthUpdate
            }
        }  
        
        
        public void Heal(float amount)  //this should change the objects current health
        {
            currentHealth += amount;
        }




        public float Damage;
        public int speed;
        public string EnemyName = "";

        public List<Items> Items = new List<Items>();





        public partial class HealthUpdate
        {

            public float PreviousHealth;
            public float CurrentHealth;
            public float MaxHealth;
            public bool IsHeal;

        }


    }
    class Player
    {



        private float currentHealth;
        public float Health
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
            }
        }
        public float BaseDamage = 1.0f;
        public int speed = 10;
        public string UserName = "";

        public List<Items> CurrentItems = new List<Items>();

    }
}
