using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    internal class Events
    {
        static Random random = new Random();
        static public void Level1Events()
        {
            int choice = random.Next(4);
            if (choice == 0)
            {
                HiddenLoot();
            }
            else if (choice == 1)
            {
                LifeFountain();
            }
            else if (choice == 2)
            {
                CoolTeachers();
            }
            else if (choice == 3)
            {
                Lottery();
            }

        }

        static public void Level2Events()
        {
            int choice = random.Next(5);
            if (choice == 0)
            {
                HiddenLoot();
            }
            else if (choice == 1)
            {
                LifeFountain();
            }
            else if (choice == 2)
            {
                CoolTeachers();
            }
            else if (choice == 3)
            {
                Labyrinth();
            }
            else if (choice == 4)
            {
                Offering();
            }

        }

        static public void Level3Events()
        {
            int choice = random.Next(6);
            if (choice == 0)
            {
                HiddenLoot();
            }
            else if (choice == 1)
            {
                LifeFountain();
            }
            else if (choice == 2)
            {
                CoolTeachers();
            }
            else if (choice == 3)
            {
                SPR();
            }
            else if (choice == 4)
            {
                Sacrifice();
            }
            else if (choice == 5)
            {
                Trap();
            }

        }


        public static void HiddenLoot()
        {
            Console.WriteLine("");
            Console.WriteLine("Воу, ты находишь схрон, кто-то неплохо затарился. Ты предпочитаешь взять содержимое схрона себе");
            Items.ChooseItem("poisons");
            Items.ChooseItem("potions");
            Items.ChooseItem("bombs");
        }

        public static void LifeFountain()
        {
            Hero.HP = Hero.MaxHP;
            Console.WriteLine("");
            Console.WriteLine("Ты находишь источник жизни, твое здоровье восстанавливается. Рядом валяются брошенные склянки. Ты набираешь в них воду из источника.");
            Items.ChooseItem("poisons");
            Items.ChooseItem("potions");
        }

        public static void CoolTeachers()
        {
            Hero.Exp += 20;
            Console.WriteLine("Ты встречаешь странника. Ночью у костра он рассказывает тебе о своих путешествиях и дает пару полезных советов.");
            Console.WriteLine("Ты усваиваешь чужой опыт. На прощание странник дает тебе кое-что и расстворяется в утреннем тумане.");
            Items.ChooseItem("items");
        }

        public static void Lottery()
        {
            Console.WriteLine("Перед тобой три сундука, выбери один из трех, выбирай аккуратно, если ткнешь мимо, не сможешь открыть ни один сундук");
            int choise = random.Next(3);
            char input = Console.ReadKey(true).KeyChar;
            if (input == 'q' || input == 'й' || input == 'w' || input == 'ц' || input == 'e' || input == 'у')
            {
                if (choise == 0)
	            {
                    Console.WriteLine("Находишь умную книгу и набираешься опыта");
                    Hero.Exp += 20;
	            }
                else if (choise == 1)
                {
                    Console.WriteLine("Да тут настоящий клад!");
                    Items.ChooseItem("potions");
                    Items.ChooseItem("bombs");
                    Items.ChooseItem("items");
                }
                else if (choise == 2)
                {
                    Console.WriteLine("В этом сундуке пусто, ты ничего не получил");
                }
                Console.WriteLine("Ну как тебе твой приз? Сударь ухмыльнулся кривой улыбкой, кричи о своем выйгрыше погромче, вдруг кто еще придет");
            }
            else Console.WriteLine("Ты не стал выбирать сундук, а просто ушел прочь");
        }

        public static void SPR()
        {
            string[] SPRthings = { "камень", "ножницы", "бумагу" };
            Console.WriteLine("");
            Console.WriteLine("Играем до 3-х побед");
            int wins = 0;
            int loses = 0;
            while (wins != 3 & loses != 3)
            {
                Console.WriteLine("");
                Console.WriteLine("Камень - нажми [1], ножницы - нажми [2], бумага - нажми [3]");
                int input = 0;
                int enemySign = random.Next(1, 4);
                char getShit = Console.ReadKey(true).KeyChar;
                if (int.TryParse(getShit.ToString(), out int number)) input = number;
                if (number != 1 & number != 2 & number != 3) continue;
                Console.WriteLine("Ты показываешь " + SPRthings[input - 1]);
                Console.WriteLine("Чувак показывает " + SPRthings[enemySign - 1]);
                if (enemySign == input) Console.WriteLine("Ничья, никто не получает очко");
                else if (input == 1 & enemySign == 2 || input == 2 & enemySign == 3 || input == 3 & enemySign == 1)
                {
                    wins++;
                    Console.WriteLine("Ты выйграл очко");
                }
                else if (input == 1 & enemySign == 3 || input == 2 & enemySign == 1 || input == 3 & enemySign == 2)
                {
                    loses++;
                    Console.WriteLine("Ты проиграл очко");
                }
                Console.WriteLine("Текущий счёт: " + wins + " : " + loses);
            }
            Console.WriteLine("");
            if (wins == 3)
            {
                Console.WriteLine("Ты выйграл и получаешь приз");
                Items.ChooseItem("potions");
                Items.ChooseItem("potions");
                Items.ChooseItem("items");                
            }
            else Console.WriteLine("Ты проиграл, вали отсюда");
        }

        public static void Sacrifice()
        {
            Console.WriteLine("");
            Console.WriteLine("Пожертвуй свою кровь, и наш бог благославит тебя за твою жертву");
            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    Console.WriteLine("пищ пищ пуу, тебя протыкают иглами и тебе бобо");
                    Hero.HP -= 20;
                    Items.ChooseItem("items");
                    Hero.Exp += 20;
                    break;
                }
                else if (input == 'w' || input == 'ц')
                {
                    Console.WriteLine("Тебя пугает такая перспектива, и ты в ужасе выбегаешь из пещеры, подальше от этих сумасшедших фанатиков");
                    break;
                }
            }
        }

        static void Offering()
        {
            Console.WriteLine("");
            char input = Console.ReadKey(true).KeyChar;
            if (input == 'q' || input == 'й')
            {
                Console.WriteLine(" ");
                int chance = random.Next(1);
                if (chance == 1)
                {
                    Console.WriteLine("");

                }
                else return;
            }
            else if (input == 'w' || input == 'ц') return;
        }

        static void Trap()
        {
            Console.WriteLine("");
            /// qte)))
        }

        static void Labyrinth()
        {
            Console.WriteLine("");
            /// )))
        }
    }
}
