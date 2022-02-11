using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DaGame
{
    internal class Program
    {

        static Random random = new Random();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;


            Console.WriteLine("имя введи");
            string name = Console.ReadLine();
            Hero.Name = name;
            Console.WriteLine("тебя значица зовут " + Hero.Name);
            Console.WriteLine("вот и твоя первая вражина!");
            Fight();
            Fight();



            Console.ReadKey();
        }

        static void Fight()
        {
            enemy.ChooseEnemy();
            Console.WriteLine("нажми на кнопочку для действия");
            while (enemy.enemyHP > 0 & Hero.HP > 0)
            {
                Console.WriteLine("[атака - q] [статус - w] [бегство - e]");
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    Console.WriteLine("пищ пищ пуу");
                    int attack = Hero.Attack - random.Next(4);
                    enemy.enemyHP -= attack;
                    Console.WriteLine(Hero.Name + " наносит врагу " + enemy.enemyName + " " + attack + " урона");

                    if (enemy.enemyHP > 0)
                    {
                        Console.WriteLine(enemy.enemyName + " атакует тебя в ответ");
                        enemy.enemyAttack = random.Next(6);
                        if (enemy.enemyAttack == 0)
                        {
                            Console.WriteLine("упсеее вражина промахнулсии");
                        }
                        else
                        {
                            Hero.HP -= enemy.enemyAttack;
                            Console.WriteLine("Вражина нанес тебе " + enemy.enemyAttack + " урона");
                        }
                    }
                }
                else if (input == 'w' || input == 'ц')
                {
                    Console.WriteLine(enemy.enemyName + " все еще существует с " + enemy.enemyHP + " хепе");
                    Console.WriteLine(Hero.Name + ", у тебя сейчас " + Hero.HP + " хепе");
                }
                else if (input == 'e' || input == 'у')
                {
                    Console.WriteLine("сбежал как лошара");
                    return;
                }                
            }
            if (Hero.HP <= 0)
            {
                Console.WriteLine("помер получается");
            }
            else
            Console.WriteLine("победа получается");

        }


    }
}

