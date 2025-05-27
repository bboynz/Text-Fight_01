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
        public bool isdead; //This says if the entity is dead

        public string enemyIndex = "";

        public void CheckHealth()
        {
            if (currentHealth <= 0 && !isdead)
            {
                isdead = true;
            }
        }


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
        private float currentHealth;// value that can be changed and returned
        public float CurrentHealth // manages current health
        {
            get
            {
                return currentHealth;
            }
            private set
            {
                var previousHealth = currentHealth;
                currentHealth = Math.Clamp(value, 0, MaxHealth); //This makes sure that the value in between the correct amounts

                var healthUpdate = new HealthUpdate
                {
                    PreviousHealth = previousHealth,
                    CurrentHealth = currentHealth,
                    MaxHealth = maxhealth,
                    IsHeal = previousHealth <= currentHealth
                };
                if (currentHealth != 0 && !isdead)
                {
                    isdead = true;
                }
            }
        }
        
        public void Heal(float amount)  //this should change the objects current health
        {
            currentHealth += amount;
        }
        public void Damage(float amount)
        {
            Heal(-amount);
        }




        public float AttackDamage;
        public int Speed;
        public string EnemyName = "";

        public int Doubloons;
        public List<Items> loot = new List<Items>();





        public partial class HealthUpdate   // If I need to send data, maybe using events or smth
        {

            public float PreviousHealth;
            public float CurrentHealth;
            public float MaxHealth;
            public bool IsHeal;

        }


    }
    class Player
    {
        public Weapon CurrentWeapon;


        public bool isdead; //This says if the entity is dead
        public bool isblocking;
        public bool isparrying;
        public bool isvulnerable;

        public int score = 0;
        public int round = 0;
        public int currentDoubloons;

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
                if (CurrentHealth <= MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
        }

        // This is to keep track of current health
        private float currentHealth;// value that can be changed and returned
        public float CurrentHealth // manages current health
        {
            get
            {
                return currentHealth;
            }
            set
            {
                var previousHealth = currentHealth;
                currentHealth = Math.Clamp(value, 0, MaxHealth); //This makes sure that the value in between the correct amounts

                if (currentHealth <= 0 && !isdead)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    
                    Console.Clear();
                    Console.WriteLine("Oh Nooo Ya Ded, Score:" + score);

                    Console.ReadLine();
                    isdead = true;
                    System.Environment.Exit(1);
                }
            }
        }

        public void Heal(float amount)  //this should change the objects current health
        {
            CurrentHealth += amount;
        }
        public void Damage(float amount)
        {

            
            Heal(-amount);
            if (currentHealth <= 0 && !isdead)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth / 2), (Console.WindowHeight / 2));
                Console.WriteLine("Oh Nooo Ya Ded  Score: " + score);
                Console.ReadLine();
                

                //TEMP ENDING CODE________________
                    System.Environment.Exit(1);
                //--------------------------------
                isdead = true;
            }
        }
        public void Attack(float damage, params Enemy[] targets)
        {
            foreach (Enemy target in targets)
            {
                target.Damage(damage*BaseDamage);
            }

        }



        public float BaseDamage = 1.0f;
        public int Speed = 2;
        public string UserName = "";

        public List<Items> Items = new List<Items>();


     

    }
}
