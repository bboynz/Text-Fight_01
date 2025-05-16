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
        private bool isdead; //This says if the entity is dead
        

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
        private bool isdead; //This says if the entity is dead
        private bool isblocking;

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
            if (isblocking)
            {
                amount = amount/2;
            }
            Heal(-amount);
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





        public partial class HealthUpdate
        {

            public float PreviousHealth;
            public float CurrentHealth;
            public float MaxHealth;
            public bool IsHeal;

        }


     

    }
}
