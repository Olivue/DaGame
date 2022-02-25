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

            bool SecondAttac = false;
            bool ThirdAttac = false;

            Console.WriteLine("имя введи");
            string name = Console.ReadLine();
            Hero.Name = name;
            Console.WriteLine("тебя значица зовут " + Hero.Name);
            Console.WriteLine("вот и твоя первая вражина!");
            Console.WriteLine("");
            Fight(3, 0, 0);

            Fight(1, 0, 0);
            Items.ChooseItem("potions");
            Items.ChooseItem("bombs");
            Items.ChooseItem("items");
            Fight(2, 0, 0);

            ///ivent
            
            Fight(1, 0, 0);
            Fight(3, 0, 0);

            ///level 2
            ///добавляем вторую атаку
            ///суперАтака = труе
            
            Fight(2, 0, 0);
            Fight(0, 1, 0);
            Fight(2, 1, 0);

            ///ivent
            
            Fight(2, 0, 0);
            Fight(0, 2, 0);

            ///level3
            ///добавляем третью атаку
            ///суперПуперАтака = труе

            Fight(2, 0, 0);
            Fight(2, 1, 0);
            Fight(0, 0, 1);
            Fight(1, 0, 1);

            ///ivent

            Fight(2, 1, 0);
            Fight(2, 0, 1);
            Fight(0, 2, 1);

            Console.ReadKey();
        }

        static void Fight(int firstLevel, int secondLevel, int thirdLevel)
        {
            
            for (int i = 0; i < firstLevel; i++)
            {
                enemy.ChooseEnemy(1);
            }
            for (int i = 0; i < secondLevel; i++)
            {
                enemy.ChooseEnemy(2);
            }
            for(int i = 0; i < thirdLevel; i++)
            {
                enemy.ChooseEnemy(3);
            }
            Console.WriteLine(Hero.Name + " столкнулся с:");
            foreach (enemy enemumy in enemy.enemies)
            {
                Console.WriteLine(enemumy.Name + " с " + enemumy.HP + " очками здоровья");
            }
            Console.WriteLine("нажми на кнопочку для действия");
            Console.WriteLine("[атака - q] [статус - w] [чекнуть инвентарь - e]");
            while (enemy.enemyHP > 0 & Hero.HP > 0)
            {
                Console.WriteLine("");
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
                        int EnemyAtack = enemy.EnemyAttack(enemy.enemyName);
                        bool evasion = Hero.Evasion();
                        if (evasion == true)
                        {
                            Console.WriteLine("упсеее вражина промахнулсии");
                        }
                        else
                        {
                            Hero.HP -= EnemyAtack;
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
                    Hero.CheckInventory();
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
                Console.WriteLine("За эту битву ты получаешь " + enemy.enemyExp + " опыта");
                Hero.Exp += enemy.enemyExp;
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

