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
            int choice = random.Next(3);
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
        }

        static public void Level2Events()
        {
            int choice = random.Next(3);
            if (choice == 0)
            {
                Lottery();
            }
            else if (choice == 1)
            {
                SPR();
            }
            else if (choice == 2)
            {
                Offering();
            }
        }

        static public void Level3Events()
        {
            int choice = random.Next(3);
            if (choice == 0)
            {
                Labyrinth();
            }
            else if (choice == 1)
            {
                Sacrifice();
            }
            else if (choice == 2)
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
            Console.WriteLine("Для выбора первого сундука - нажми [1], второго - нажми [2], третьего - нажми [3]");
            char input = Console.ReadKey(true).KeyChar;            
            if (input == '1' || input == '2' || input == '3')
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
            Console.WriteLine("Нажми [q] чтоб сделать жертвоприношение,[w] чтоб пройти мимо");
            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    Console.WriteLine("пищ пищ пуу, тебя протыкают иглами и тебе бобо");
                    Hero.HP = 1;
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

        public static void Offering()
        {
            Console.WriteLine("Какой-то старик просит помощи, ему нужна зелька");
            Console.WriteLine("Нажми [q] чтоб дать хилку старику,[w] чтоб пройти мимо");
            while (true)
            {
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    if (Hero.Inventory.Contains("Зелье лечения") || Hero.Inventory.Contains("Сильное зелье лечения"))
                    {
                        Console.WriteLine("Ты решаешь дать старику зелье, все равно у тебя нет ничего более подходящего, а ему больше и не надо");
                        int pizka = 0;
                        if (Hero.Inventory.Contains("Зелье лечения")) pizka = Hero.Inventory.FindIndex(x => x == "Зелье лечения");
                        if (Hero.Inventory.Contains("Сильное зелье лечения")) pizka = Hero.Inventory.FindIndex(x => x == "Сильное зелье лечения");
                        Hero.Inventory.RemoveAt(pizka);
                        int chance = random.Next(2);
                        if (chance == 1)
                        {
                            Console.WriteLine("Старик осторожно берет зелье и убирает в складки своих лохмотьев. В благодарность он рассказывает о том, что видел, пока сидит здесь. Ты получаешь очки опыта");
                            Hero.Exp += 40;
                        }
                        else Console.WriteLine("Старик выхватывает протянутое зелье и жадно глотает содержимое. Внезапно он заходится кашлем. Тебе кажется, что он сейчас выплюнет свои легкие, но ты не знаешь, чем ему помочь. Старик скрючивается и хрипя протягивает тебе руку. Через пару мгновений рука падает, а старик издает последний тихий хрип. У тебя нет времени на похороны. Ты оставляешь тело и уходишь прочь.");
                    }
                    else Console.WriteLine("Тебе нечего дать старику. Ты вздыхаешь и проходишь мимо.");
                    break;
                }
                else if (input == 'w' || input == 'ц')
                {
                    Console.WriteLine("Ты решаешь не давать ничего старику. Ты уходишь. Старик провожает тебя взглядом, пока ты не скрываешься");
                    break;
                }
            }            
        }

        static void Trap()
        {
            Console.WriteLine("");
            /// qte)))
        }

        public static void Labyrinth()
        {
            string[,] grid =
            {
                {"+", "-", "+", "-", "-", "-", "+" },
                {"|", " ", "|", " ", " ", " ", "|" },
                {" ", " ", "|", " ", "|", " ", "|" },
                {"|", " ", "|", " ", "|", " ", "|" },
                {"|", " ", " ", " ", "|", " ", "x" },
                {"+", "-", "-", "-", "+", "-", "+" },
            };

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            string canI = "jopa";
            int CheckX = 6;
            int CheckY = 4;

            if(CheckX < 0 || CheckY < 0 || CheckX >= cols || CheckY >= rows)
            {
                canI = "false";
            }
            else
            {
                if (grid[CheckY, CheckX] == " " || grid[CheckY, CheckX] == "x")
                {
                    canI = "true";
                }
                else canI = "pixa";
            }

            Console.WriteLine("");
            Console.WriteLine(canI);

            int PlayerX = 0;
            int PlayerY = 2;
            string PlayerMarker = "0";
            ConsoleColor PlayerColor = ConsoleColor.Red;



            while (true)
            {
                Console.Clear();
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        string element = grid[y, x];
                        Console.SetCursorPosition(x, y);
                        Console.Write(element);
                    }
                }
                Console.ForegroundColor = PlayerColor;
                Console.SetCursorPosition(PlayerX, PlayerY);
                Console.Write(PlayerMarker);
                Console.ResetColor();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                ConsoleKey key = keyInfo.Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        PlayerY -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        PlayerY += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        PlayerX -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        PlayerX += 1;
                        break;
                    default:
                        break;
                }

                System.Threading.Thread.Sleep(20);

                //break;
            }
        }
    }
}
