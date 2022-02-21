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


        static void HiddenLoot()
        {
            ///зелька и предмет
        }

        static void LifeFountain()
        {
            Hero.HP = Hero.MaxHP;
            Console.WriteLine("");
        }

        static void CoolTeachers()
        {
            Hero.Exp += 20;
            Console.WriteLine("");
        }

        static void Lottery()
        {
            Console.WriteLine("");
            ///randomizer for chests

            char input = Console.ReadKey(true).KeyChar;
            if (input == 'q' || input == 'й')
            {
                Console.WriteLine("пищ пищ пуу");
                
            }
            else if (input == 'w' || input == 'ц')
            {
                Console.WriteLine(enemy.enemyName + " все еще существует с " + enemy.enemyHP + " хепе");

            }
            else if (input == 'e' || input == 'у')
            {
                Console.WriteLine("сбежал как лошара");

            }
        }

        static void SPR()
        {
            ///randomizer for a game and random loot like with chests
        }

        static void Sacrifice()
        {
            Console.WriteLine("");
            char input = Console.ReadKey(true).KeyChar;
            if (input == 'q' || input == 'й')
            {
                Console.WriteLine("пищ пищ пуу");

            }
            else if(input == 'w' || input == 'ц') return;
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
