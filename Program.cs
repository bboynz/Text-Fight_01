using System;
using System.IO;
using System.Collections;
using System.Text;
using Text_Fight.Entities;
using Text_Fight.PlayerActions;

namespace GameCycle
{

    class Program
    {
        static void Main(string[] args)
        {


        }

        static Enemy CreateEnemy(string name, float maxHealth)
        {
            Enemy enemy = new Enemy();
            enemy.EnemyName = name;
            enemy.MaxHealth = maxHealth;





            return enemy;
        }


    }



}
