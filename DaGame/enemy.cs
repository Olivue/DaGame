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
        static string[] enemy2 = {"волчара", "", "", ""};
        static string[] enemy3 = {"","","","","",""};
        static public string enemyName;
        static public int enemyHP;
        static public int enemyAttack;


        static public void ChooseEnemy()
        {
            if (Hero.MaxHP > 20)
            {
                enemyName = enemy1[random.Next(enemy1.Length)];
                enemyHP = random.Next(10, 21);
                
                Console.WriteLine("твоя вражина это " + enemyName);
                Console.WriteLine("хепе вражины " + enemyHP);
                                
            }
            
        }
    }
}
