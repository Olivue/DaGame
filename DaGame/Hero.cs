using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    internal class Hero
    {
        static Random random = new Random();

        public static string Name;
        public static int MaxHP = 50;
        public static int HP = 50;
        public static int Attack = 5;
        public static int Exp;
        public static double HeroEvasion = 0.2;
        public static double HeroCrit = 0.1;
        static double Riser;
        public static bool secondAttMarker;
        public static bool thirdAttMarker;

        public static List<string> Inventory = new List<string>();
        public static List<string> Equip = new List<string>();
        public static List<Items> Equipment = new List<Items>();

        public static void LevelUp()
        {
            MaxHP += 5;
            Attack += 2;
            Console.WriteLine("Ты достигаешь нового уровня!");
            Console.WriteLine("Максимальное колличество здоровья и атаки увеличено!");
            Console.WriteLine("MaxHP = " + MaxHP + ", Attack = " + Attack);
            Console.WriteLine("Твое здоровье восстановленно!");
            Console.WriteLine("");
            HP = MaxHP;
        }

        public static bool Evasion() ///gotovo
        {
            double evasion = random.NextDouble();
            Riser = 0;

            foreach(Items item in Equipment)
            {
                if (item.ItemProp == "уворота")
                {
                    Riser += item.ItemValue;
                }
            }
            if (evasion <= HeroEvasion + Riser) return true;
            else return false;
        }

        public static void CheckInventory() /// gotovo
        {
            if (!Inventory.Any()) 
            {
                Console.WriteLine("В инвентаре сейчас ничего нет");
                return;
            } 
            Console.WriteLine("В инвентаре сейчас следующие предметы:");
            int i = 1;
            foreach (string item in Inventory)
            {
                Console.WriteLine(i + " " + item);
                i++;
            }
            Console.WriteLine("");
            Console.WriteLine("На тебе надеты следующие предметы:");
            foreach (Items item in Equipment)
            {
                Console.WriteLine(item.ItemName + " " + item.ItemProp);
            }
            Console.WriteLine("Для использования предмета введите его номер, для выхода из инвентаря нажмите Enter");
            string number = Console.ReadLine();

            if (number == "") return;
            if (int.TryParse(number, out int numumber))
            {
                if (numumber <= Inventory.Count)
                {
                    Items.UseItem(Inventory[numumber-1]);
                }
            }
            else Console.WriteLine("Ну значит ничего");
        }

        public static int HeroAttack()
        {
            int att = 0;
            if (Program.SecondAttack || Program.ThirdAttack) 
            {
                Console.WriteLine("Выбери тип атаки:");
                if (Program.SecondAttack)
                {
                    Console.Write("обычная атака - [q] атака по площади - [w]");
                }
                if(Program.ThirdAttack)
                {
                    Console.WriteLine(" сильная атака - [e]");
                }

                Console.WriteLine("");
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'q' || input == 'й')
                {
                    Console.WriteLine("пищ пищ пуу");
                    att = Attack - random.Next(4);
                }
                else if (input == 'w' || input == 'ц')
                {
                    Console.WriteLine("баба хххх");
                    secondAttMarker = true;
                    att = Attack - random.Next(3,6);
                }
                else if ((input == 'e' || input == 'у') & Program.ThirdAttack)
                {
                    Console.WriteLine("пдыыыщщщ");
                    thirdAttMarker = true;
                    att = Attack + random.Next(3,6);
                }
            }
            else
            {
                Console.WriteLine("пищ пищ пуу");
                att = Attack - random.Next(4);                
            }
            Console.WriteLine("");
            return att;
        }
        public static void BuffCheck()
        {

        }
    }
}
