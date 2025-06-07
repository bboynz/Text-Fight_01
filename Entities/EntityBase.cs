using GameCycle;
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
        public List<Items> droppedItems = new List<Items>();
        public Weapon droppedWeapon;




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
                Die();
            }
        }
        public void Attack(float damage, params Enemy[] targets)
        {
            foreach (Enemy target in targets)
            {
                target.Damage(damage*BaseDamage);
            }

        }

        private void Die()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            Console.Clear();
            Console.WriteLine("\x1b[3J");

            Console.WriteLine("Oh Nooo Ya Ded, Score:" + score);
            Console.WriteLine("Input R to restart or anyting else to exit");

            try
            {
                char input = Console.ReadKey(true).KeyChar;
                input = char.ToLower(input); 

                if (input == Convert.ToChar("r"))
                {
                    Program.StartRun();

                }
                else
                {
                    isdead = true;
                    System.Environment.Exit(1);
                }
            }
            catch
            {

            }
 
        }


        public float BaseDamage = 1.0f;
        public int Speed = 2;
        public string UserName = "";

        public List<Items> Items = new List<Items>();

        public static void SetHighScore(string item, int score, string username)
        {
            string data;

            string path = "..\\..\\..\\HighScore";
            string userPath = "..\\..\\..\\HighScore";

            string currentInv = File.ReadAllText(path);

            StreamReader reader = null;
            StreamWriter writer = null;

            try
            {
                reader = new StreamReader(path);

                data = reader.ReadLine();

                if (Convert.ToInt32(data) >= score)
                {
                    while (data != null)
                    {
                        Console.WriteLine(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();


                    writer = new StreamWriter(path);
                    writer.WriteLine(score);
                    while (data != null)
                    {
                        Console.WriteLine(data);
                        data = reader.ReadLine();
                    }
                    reader.Close();

                    reader = new StreamReader(path);

                    writer = new StreamWriter(userPath);
                    writer.WriteLine(userPath);
                }
                else
                {
                    reader.Close();
                }

                
                


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {

                writer.Close();
            }
        }


    }


}

