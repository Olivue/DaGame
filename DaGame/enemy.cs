using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    internal class enemy
    {
        static Random random = new Random();
        static string[] enemy1 = {"ядовитая цветожаба", "комар-кровопийца", "слизень-всосун"};
        static string[] enemy2 = {"волчара подзорный", "орел петушатый", "громила воображаемой таверны", "стая соседских детей"};
        static string[] enemy3 = {"","","","","",""};
        static public string enemyName;
        static public int enemyHP;
        static public int enemyAttack;
        static public int enemyExp;
        public int enemyLVL;

        public static List<enemy> enemies = new List<enemy>() { };
        public string Name;
        public int HP;
        public int Exp;
        public int PoisonCounter;
        public int StanCounter;
        public int SuperPower;
        public string Picture;
        public bool BossChecker;
        public bool FinalBossChecker;
        public int Attack;
        public int SuperPowerCounter;
        public int MaxHP;
        static public void ChooseEnemy(int level)
        {
            if (level == 1)
            {
                enemyName = enemy1[random.Next(enemy1.Length)];
                enemyHP = random.Next(8, 15);
                enemyExp = 5;
                enemyAttack = random.Next(2, 5);             
            }
            else if (level == 2)
            {
                enemyName = enemy2[random.Next(enemy2.Length)];
                enemyHP = random.Next(15, 26);
                enemyExp = 10;
                enemyAttack = random.Next(4, 9);
            }
            else if (level == 3)
            {
                enemyName = enemy3[random.Next(enemy3.Length)];
                enemyHP = random.Next(26, 46);
                enemyExp = 15;
                enemyAttack = random.Next(8, 16);
            }
            enemies.Add(new enemy() { Name = enemyName, HP = enemyHP, Exp = enemyExp, PoisonCounter = 0, StanCounter = 0, BossChecker = false, FinalBossChecker = false, Attack = enemyAttack, enemyLVL = level });
        }

        static public int EnemyAttack(int level, bool BossChecker, int attack)
        {
            double chance = random.NextDouble();
            if (level == 1) return attack - random.Next(2);
            else if (level == 2)
            {
                if (chance <= 0.1)
                {
                    Console.WriteLine("Враг изворачивается и наносит тебе удар по незащищенному месту");
                    return attack + random.Next(4, 9);
                }
                else return attack - random.Next(3);
            }
            else if(level == 3)
            {
                if (chance <= 0.1)
                {
                    Console.WriteLine("На мгновение ты отвлекаешься и враг целится в открытое слабое место!");
                    return attack + random.Next(8, 16);
                }
                else if(chance >= 0.85)
                {
                    Console.WriteLine("После этой атаки ты чувствуешь резкую и болезненную вспышку. Тебя отравили.");
                    Hero.PoisonCounter = 3;
                    return attack - random.Next(5);
                }
                else return attack - random.Next(3);
            }
            else if(BossChecker)
            {
                if (chance <= 0.15)
                {
                    Console.WriteLine("Враг изворачивается и наносит тебе удар по незащищенному месту");
                    return attack + random.Next(4, 9);
                }
                else return attack - random.Next(7);               
            }
            return attack;
        }
    }
}
