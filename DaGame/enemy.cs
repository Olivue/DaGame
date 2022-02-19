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


        static public void ChooseEnemy()
        {
            if (Hero.MaxHP < 51)
            {
                enemyName = enemy1[random.Next(enemy1.Length)];
                enemyHP = random.Next(8, 15);
                enemyExp = 5;      
                             
            }
            else if (Hero.MaxHP > 50)
            {
                enemyName = enemy2[random.Next(enemy2.Length)];
                enemyHP = random.Next(10, 20);
                enemyExp = 10;
            }
            Console.WriteLine("твоя вражина это " + enemyName);
            Console.WriteLine("хепе вражины " + enemyHP);
        }

        static public int EnemyAttack(string name)
        {
            double chance = random.NextDouble();
            if (enemy1.Contains(name))
            {
                enemyAttack = random.Next(4);
                return enemyAttack;
            }
            else if (enemy2.Contains(name))
            {
                if (chance <= 0.05)
                {
                    enemyAttack = random.Next(7, 10);
                    Console.WriteLine("О ннннет! Враг кританул!!!");
                }
                else
                {
                    enemyAttack = random.Next(7);
                }
                return enemyAttack;
            }
            else
            {
                enemyAttack = 0;
                return enemyAttack;
            }
        }
    }
}
