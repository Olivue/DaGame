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
        static int ExpCounter;
        public static bool SecondAttack = true;
        public static bool ThirdAttack = true;
       
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;
            //Fight(3, 0, 0);
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            Items.ChooseItem("bombs");
            BossFight();
            Events.Trap();
            Events.Labyrinth();

            //var text = "If you have a single word that is greater than the specified column width, it will overrun the column boundary to the right. This is the only case where your text might spill over beyond the width specified. This is by design. There's no great way to handle it. The other options would have been to truncate the word, or to hard break the word in the middle of it somewhere.Unfortunately, this does not preserve whitespace, except line breaks. Tabs will be converted to spaces and multiple characters of whitespace will be turned into a single space. Making this preserve whitespace greatly increases the complexity so I decided not to do it.";
            //Console.WriteLine(text);

            Console.WriteLine("имя введи");
            string name = Console.ReadLine();

            Hero.Name = name;
            Console.WriteLine("тебя значица зовут " + Hero.Name);
            Console.WriteLine("вот и твоя первая вражина!");
            Console.WriteLine("");
            Console.WriteLine(DaBosss.Leviathan + DaBosss.Hellebore + DaBosss.Wyvern + DaBosss.Basilisk + DaBosss.Serpent);
            Events.SPR();
            Events.Lottery();
            Events.Sacrifice();
            Items.ChooseItem("potions");
            Items.ChooseItem("potions");
            Items.ChooseItem("potions");
            Items.ChooseItem("potions");
            Items.ChooseItem("potions");
            Events.Offering();
            Events.Offering();
            Events.Offering();
            Events.Offering();
            Events.Offering();
            /*Items.ChooseItem("items");
            Items.ChooseItem("items");
            Items.ChooseItem("items");
            Items.ChooseItem("items");
            Items.ChooseItem("items");
            Items.ChooseItem("items");*/
            

            Fight(1, 0, 0);
            Items.ChooseItem("potions");
            Items.ChooseItem("bombs");
            Items.ChooseItem("items");
            Fight(2, 0, 0);

            Events.Level1Events();
            
            Fight(1, 0, 0);
            Fight(3, 0, 0);

            ///level 2
            ///добавляем вторую атаку
            SecondAttack = true;
            
            Fight(2, 0, 0);
            Fight(0, 1, 0);
            Fight(2, 1, 0);

            Events.Level2Events();
            
            Fight(2, 0, 0);
            Fight(0, 2, 0);

            ///level3
            ///добавляем третью атаку
            ThirdAttack = true;

            Fight(2, 0, 0);
            Fight(2, 1, 0);
            Fight(0, 0, 1);
            Fight(1, 0, 1);

            Events.Level3Events();

            Fight(2, 1, 0);
            Fight(2, 0, 1);
            Fight(0, 2, 1);

            Console.ReadKey();
        }

        static void Fight(int firstLevel, int secondLevel, int thirdLevel)
        {
            int ExpCounter = 0;
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
            while (enemy.enemies.Count > 0 & Hero.HP > 0)
            {
                FightActions();
            }
            Console.WriteLine("");
            if (Hero.HP <= 0)
            {
                EndGame();
            }
            else
            {
                Hero.Exp += ExpCounter;
                Console.WriteLine("победа получается");
                Console.WriteLine("За эту битву ты получаешь " + ExpCounter + " опыта");
                Console.WriteLine("Теперь у тебя " + Hero.Exp + " опыта");
                Console.WriteLine("");
            }
            if (Hero.Exp == 20)
            {
                Hero.LevelUp();                
            }
        }
        public static int InBattleEnemyChoose()
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
            if (number == "")  return 500;
            if (int.TryParse(number, out int numumber))
            {
                return numumber - 1;
            }
            else return 500;
        }

        static void FightActions()
        {
            Console.WriteLine("");
            Console.WriteLine("[атака - q] [статус - w] [чекнуть инвентарь - e]");
            char input = Console.ReadKey(true).KeyChar;
            if (input == 'q' || input == 'й')
            {
                int attack = Hero.HeroAttack();
                if (Hero.secondAttMarker)
                {
                    int i = 0;
                    foreach (enemy enemy in enemy.enemies)
                    {
                        TakeDamage(attack, i);
                        i++;
                    }
                    Hero.secondAttMarker = false;
                }
                else
                {
                    if (enemy.enemies.Count == 1) TakeDamage(attack, 0);
                    else
                    {
                        int numumber = InBattleEnemyChoose();
                        if (numumber <= enemy.enemies.Count)
                        {
                            if (Hero.thirdAttMarker)
                            {
                                double chance = random.NextDouble();
                                if (chance > 0.5)
                                {
                                    Console.WriteLine(Hero.Name + " слабо замахнулся, удар сильным не получится.");
                                    TakeDamage(attack / 2, numumber);                                    
                                }
                                else TakeDamage(attack, numumber);
                                Hero.thirdAttMarker = false;
                            }
                            else TakeDamage(attack, numumber);
                        }                        
                    }
                }
                List<int> count = new List<int>();
                int e;
                foreach (enemy enemumy in enemy.enemies)
                {
                    if (enemumy.PoisonCounter > 0)
                    {
                        enemumy.PoisonCounter--;
                        enemumy.HP -= 3;
                        Console.WriteLine(enemumy.Name + " нанесен урон ядом 3 ед.");
                    }
                    if (enemumy.StanCounter > 0)
                    {
                        enemumy.StanCounter--;
                        Console.WriteLine(enemumy.Name + " обездвижен и не атакует");
                    }
                    else
                    {
                        if (enemumy.HP > 0)
                        {
                            Console.WriteLine(enemumy.Name + " атакует тебя в ответ");
                            int EnemyAtack = enemy.EnemyAttack(enemumy.Name);
                            if (Hero.Evasion())
                            {
                                Console.WriteLine("упсеее вражина промахнулсии");
                            }
                            else
                            {
                                Hero.HP -= EnemyAtack;
                                Console.WriteLine("Вражина нанес тебе " + EnemyAtack + " урона");
                            }
                        }
                        else
                        {
                            e = enemy.enemies.IndexOf(enemumy);
                            count.Add(e);
                        }
                    }
                }
                count.Reverse();
                foreach (int i in count)
                {
                    Console.WriteLine(enemy.enemies[i].Name + " умирает");
                    ExpCounter += enemy.enemies[i].Exp;
                    enemy.enemies.RemoveAt(i);
                }
            }
            else if (input == 'w' || input == 'ц')
            {
                foreach (enemy enemumy in enemy.enemies)
                {
                    Console.WriteLine(enemumy.Name + " все еще существует с " + enemumy.HP + " очками здоровья");
                }
                Console.WriteLine(Hero.Name + ", у тебя сейчас " + Hero.HP + " хепе из " + Hero.MaxHP);
            }
            else if (input == 'e' || input == 'у')
            {
                Hero.CheckInventory();
            }
            if (Hero.HP <= 0) Hero.LifeCheck();
        }

        static void TakeDamage(int attack, int i)
        {
            double evasion = random.NextDouble();
            if (enemy.enemies[i].SuperPower == 3 & enemy.enemies[i].StanCounter == 0 & evasion <= 0.8)
            {
                DaBosss.CoolAttacks[3]();
            }
            else
            {
                enemy.enemies[i].HP -= attack;
                Console.WriteLine(Hero.Name + " наносит врагу " + enemy.enemies[i].Name + " " + attack + " урона");
            }
        }

        static void BossFight()
        {
            DaBosss.Bosses();
            for (int i = 0; i < 3; i++)
            {
                DaBosss.Boss.RemoveAt(random.Next(DaBosss.Boss.Count));
            }
            enemy.enemies.Add(new enemy() { Name = DaBosss.Boss[0].BossName, HP = DaBosss.Boss[0].BossHP, Exp = 50, PoisonCounter = 0, StanCounter = 0, BossChecker = true, SuperPower = DaBosss.Boss[0].CoolAttackNumber, Picture = DaBosss.Boss[0].BossImage, Attack = DaBosss.Boss[0].BossAttack});
            enemy.ChooseEnemy(1);
            Console.WriteLine(DaBosss.Boss[0].BossName);
            Fight(0,0,0);
        }

        static void EndGame()
        {
            string deadHead = @"
                           ,--.
                          {    }
                          K,   }
                         /  `Y`
                    _   /   /
                   {_'-K.__/
                     `/-.__L._
                     /  ' /`\_}
                    /  ' /     
            ____   /  ' /
     ,-'~~~~    ~~/  ' /_
   ,'             ``~~~%%',
  (                     %  Y
 {                      %% I
{      -                 %  `.
|       ',                %  )
|        |   ,..__      __. Y
|    .,_./  Y ' / ^Y   J   )|
\           |' /   |   |   ||
 \          L_/    . _ (_,.'(
  \,   ,      ^^``' / |      )
    \_  \          /,L]     /
      '-_`-,       ` `   ./`
         `-(_            )
             ^^\..___,.--`";
            Console.WriteLine("помер получается");
            Console.WriteLine("");
            Console.WriteLine("> > > ИГРА ОКОНЧЕНА < < <");
            Console.WriteLine("");
            Console.WriteLine(deadHead);
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void StoryLine()
        {
            string[] Rumors = {"", "", "", "", "", "" };
        }
    }
}

