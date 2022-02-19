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
            Fight();
            Fight();
            Fight();
            Fight();





            Console.ReadKey();
        }

        static void Fight()
        {
            enemy Enemy1 = new enemy();
            Enemy1.ChooseEnemy();
            Console.WriteLine("нажми на кнопочку для действия");
            Console.WriteLine("[атака - q] [статус - w] [бегство - e]");
            while (Enemy1.enemyHP > 0 & Hero.HP > 0)
            {
                Console.WriteLine("");
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    Console.WriteLine("пищ пищ пуу");
                    int attack = Hero.Attack - random.Next(4);
                    Enemy1.enemyHP -= attack;
                    Console.WriteLine(Hero.Name + " наносит врагу " + Enemy1.enemyName + " " + attack + " урона");

                    if (Enemy1.enemyHP > 0)
                    {
                        Console.WriteLine(Enemy1.enemyName + " атакует тебя в ответ");
                        int EnemyAtack = Enemy1.EnemyAttack(Enemy1.enemyName);
                        if (EnemyAtack == 0)
                        {
                            Console.WriteLine("упсеее вражина промахнулсии");
                        }
                        else
                        {
                            Hero.HP -= EnemyAtack;
                            Console.WriteLine("Вражина нанес тебе " + Enemy1.enemyAttack + " урона");
                        }
                    }
                }
                else if (input == 'w' || input == 'ц')
                {
                    Console.WriteLine(Enemy1.enemyName + " все еще существует с " + Enemy1.enemyHP + " хепе");
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
                Console.WriteLine("");
                Console.WriteLine("> > > ИГРА ОКОНЧЕНА < < <");
            }
            else
            {
                Console.WriteLine("победа получается");
                Console.WriteLine("За эту битву ты получаешь " + Enemy1.enemyExp + " опыта");
                Hero.Exp += Enemy1.enemyExp;
                Console.WriteLine("Теперь у тебя " + Hero.Exp + " опыта");
                Console.WriteLine("");
            }

            if (Hero.Exp == 20)
            {
                Hero.LevelUp();
                
            }
            

        }


    }
}

