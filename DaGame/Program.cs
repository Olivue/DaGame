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
        public static bool SecondAttack = true;
        public static bool ThirdAttack = true;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

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
                Console.WriteLine(enemumy.Name + " с " + enemumy.HP + " здоровья");
            }
            Console.WriteLine("нажми на кнопочку для действия");
            while (enemy.enemyHP > 0 & Hero.HP > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("[атака - q] [статус - w] [чекнуть инвентарь - e]");
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    int attack = Hero.HeroAttack();

                    if (Hero.secondAttMarker)
                    {
                        foreach (enemy enemy in enemy.enemies)
                        {
                            enemy.HP =- attack;
                        }
                        Console.WriteLine("Всем врагам нанесено " + attack + " урона");
                        Hero.secondAttMarker = false;
                    }
                    else
                    {
                        if(enemy.enemies.Count == 1)
                        {
                            enemy.enemies[0].HP -= attack;
                            Console.WriteLine(Hero.Name + " наносит врагу " + enemy.enemies[0].Name + " " + attack + " урона");
                        }
                        else
                        {
                            Console.WriteLine("Выберите врага для атаки:");
                            int i = 1;
                            foreach (enemy enemy in enemy.enemies)
                            {
                                Console.WriteLine(i + " " + enemy.Name + " (" + enemy.HP + " здоровья)");
                                i++;
                            }
                            Console.WriteLine("");
                            Console.WriteLine("Для атаки выбранного врага введите его номер:");
                            string number = Console.ReadLine();
                            if (number == "") return;
                            if (int.TryParse(number, out int numumber))
                            {
                                if (numumber <= enemy.enemies.Count)
                                {
                                    if (Hero.thirdAttMarker)
                                    {
                                        double chance = random.NextDouble();
                                        if (chance > 0.5)
                                        {
                                            enemy.enemies[numumber - 1].HP -= attack/2;
                                            Console.WriteLine(Hero.Name + " промахивается и наносит врагу всего " + enemy.enemies[numumber - 1].Name + " " + attack + " урона");
                                        }
                                        else
                                        {
                                            enemy.enemies[numumber - 1].HP -= attack;
                                            Console.WriteLine(Hero.Name + " наносит врагу " + enemy.enemies[numumber - 1].Name + " " + attack + " урона");
                                        }
                                        Hero.thirdAttMarker = false;
                                    }
                                    else
                                    {
                                        enemy.enemies[numumber - 1].HP -= attack;
                                        Console.WriteLine(Hero.Name + " наносит врагу " + enemy.enemies[numumber - 1].Name + " " + attack + " урона");
                                    }
                                }
                            }
                        }
                    }
                    List<int> count = new List<int>();
                    int e;
                    foreach (enemy enemumy in enemy.enemies) /// переписать под нынешние реалии
                    {
                        if (enemumy.HP > 0) /// тоже доделать!!!!!
                        {
                            Console.WriteLine(enemy.enemyName + " атакует тебя в ответ");
                            int EnemyAtack = enemy.EnemyAttack(enemy.enemyName);
                            if (Hero.Evasion())
                            {
                                Console.WriteLine("упсеее вражина промахнулсии");
                            }
                            else
                            {
                                Hero.HP -= EnemyAtack;
                                Console.WriteLine("Вражина нанес тебе " + enemy.enemyAttack + " урона");
                            }
                        }
                        else
                        {
                            e = enemy.enemies.IndexOf(enemumy);
                            count.Add(e);
                        }
                    }
                    count.Reverse();
                    foreach(int i in count)
                    {
                        Console.WriteLine(enemy.enemies[i].Name + " умирает");
                        enemy.enemies.RemoveAt(i);
                    }

                }
                else if (input == 'w' || input == 'ц')
                {
                    foreach (enemy enemumy in enemy.enemies)
                    {
                        Console.WriteLine(enemumy.Name + " все еще существует с " + enemumy.HP + " очками здоровья");
                    }
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
            else /// добавить систему прибавки опыта
            {
                Console.WriteLine("победа получается");
                Console.WriteLine("За эту битву ты получаешь " + 1 + " опыта");
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

