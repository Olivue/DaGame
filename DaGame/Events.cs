using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;

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
            Console.WriteLine("Нажми [q] чтоб сделать жертвоприношение,[e] чтоб пройти мимо");
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
                else if (input == 'e' || input == 'у')
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
                        else Console.WriteLine("Старик выхватывает протянутое зелье и жадно глотает содержимое. Внезапно он заходится кашлем. Тебе кажется, что он сейчас выплюнет свои легкие, но ты не знаешь, чем ему помочь. Старик скрючивается и хрипя протягивает тебе руку. Через пару мгновений рука падает, а старик издает последний тихий хрип. У тебя нет времени и сил на похороны. Ты оставляешь тело нетронутым и уходишь прочь.");
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

        public static void Trap()
        {
            Console.WriteLine("");
            Console.WriteLine("ну чтож, сейчас будет пиздиловка");
            Console.WriteLine("тыркни чтоб начать пиздиловку");
            Console.ReadKey(true);
            QTE(3);
            Console.WriteLine("молодучень");
        }
        
        public static void QTE(int howManyTimes)
        {
            Console.ReadKey(true);

            char[] qteChars = { 'q', 'w', 'e', 'a', 's', 'd', 'z', 'x', 'c'};
            char randomChar;
            Timer timer;
            int i;
            char tab;
            int checker;

            while (howManyTimes > 0)
            {
                timer = new Timer(1000);
                qteStarter();
                timer.Dispose();
                GC.Collect();
                Console.WriteLine("ну теперь то конец?");
                Console.ReadKey(true);
                howManyTimes--;
            }

            void qteStarter()
            {
                randomChar = qteChars[random.Next(qteChars.Length)];
                i = 10;
                checker = 1;
                timer.Enabled = true;
                do
                {
                    tab = Console.ReadKey(true).KeyChar;
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                    Console.WriteLine("конец не конец?");
                } while (checker == 1);                
            }

            void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                i--;                
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("                  DEFUSE THE BOMB");
                Console.WriteLine("");
                Console.WriteLine("                Времени осталось:  " + i.ToString());
                Console.WriteLine("");
                Console.WriteLine("                Нажми на кнопку:  " + randomChar);
                Console.WriteLine("");
                Console.WriteLine("=================================================");
                if (i < 0)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("==============================================");
                    Console.WriteLine("         B O O O O O M M M M M ! ! ! !");
                    Console.WriteLine("");
                    Console.WriteLine("               G A M E  O V E R");
                    Console.WriteLine("==============================================");

                    timer.Close();
                }
                if (tab == randomChar || i == 0)
                {
                    timer.Stop();
                    timer.Close();
                    Console.WriteLine("pizka");
                    checker = 0;
                }                
            }
        }

        public static void Labyrinth()
        {
            Console.WriteLine("Ты видишь перед собой узкий коридор, который разветвляется на несколько путей.");
            Console.WriteLine("Чтож, путь назад отрезан, тебе остается только идти вперед.");
            Console.WriteLine("Нажми любую клавишу, чтобы войти в рукав пещеры. Для дальнейшего перемещения используй стрелки клавиатуры.");
            Console.ReadKey(true);
            Console.Clear();

            string[] lines = File.ReadAllLines("Map.txt");
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                string line = lines[r];
                for (int c = 0; c < cols; c++)
                {
                    char currentChar = line[c];
                    grid[r, c] = currentChar.ToString();
                }
            }

            int PlayerX = 0;
            int PlayerY = 5;
            string PlayerMarker = "0";
            ConsoleColor PlayerColor = ConsoleColor.Red;

            while (true)
            {
                Console.CursorVisible = false;
                Console.Clear();
                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        string element = grid[y, x];
                        Console.SetCursorPosition(x, y);
                        if(element == "Ф")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(element);
                            Console.ResetColor();
                        }
                        else if(element == "V")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(element);
                            Console.ResetColor();
                        }
                        else if(element == "X")
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine(element);
                            Console.ResetColor();
                        }
                        else Console.Write(element);
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
                        if (WallChecker(PlayerX, PlayerY - 1)) PlayerY -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (WallChecker(PlayerX, PlayerY + 1)) PlayerY += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (WallChecker(PlayerX - 1, PlayerY)) PlayerX -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (WallChecker(PlayerX + 1, PlayerY)) PlayerX += 1;
                        break;
                    default:
                        break;
                }

                if (grid[PlayerY, PlayerX] == "X") break;
                if (grid[PlayerY, PlayerX] == "V" || grid[PlayerY, PlayerX] == "Ф")
                {
                    Console.SetCursorPosition(0, 25);
                    if(grid[PlayerY, PlayerX] == "V") Items.ChooseItem("potions");
                    else Items.ChooseItem("bombs");
                    Console.WriteLine("Нажми любую кнопку, чтобы продолжить двигаться");
                    grid[PlayerY, PlayerX] = " ";
                    Console.ReadKey(true);
                }
                //System.Threading.Thread.Sleep(20);
            }

            bool WallChecker(int x, int y)
            {
                if (x < 0 || y < 0 || x >= cols || y >= rows)
                {
                    return false;
                }
                return grid[y, x] == " " || grid[y, x] == "X" || grid[y, x] == "V" || grid[y, x] == "Ф";
            }
            
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("Ты прошел злоебучий лабиринт. Впереди ты видишь свет. Надо только растолкать несколько камней и продолжить путь.");
            Console.WriteLine("Ты делаешь короткую передышку, пока есть время.");
            Console.WriteLine("Нажми любую клавишу, чтобы продолжить свой путь.");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
