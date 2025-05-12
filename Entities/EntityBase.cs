using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Fight.PlayerActions;

namespace Text_Fight.Entities
{
    class Enemy
    {
        public float Health;
        public float Damage;
        public string EnemyName = "";

        public List<Items> Items = new List<Items>();


    }
    class Player
    {
        public float Health;
        public float BaseDamage = 1.0f;
        public string EnemyName = "";

        public List<Items> CurrentItems = new List<Items>();

    }
}
