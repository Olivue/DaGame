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
        public static double HeroEvasion = 0.15;
        public static double HeroCrit = 0.1;

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

        public static bool Evasion()
        {
            double evasion = random.NextDouble();
            if (evasion <= HeroEvasion) return true;
            else return false;
        }

        public static void CheckInventory()
        {
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
                Console.WriteLine(i + " " + item);
                i++;
            }
            Console.WriteLine("Для использования предмета введите его номер, для выхода из инвентаря нажмите Enter");
            string number = Console.ReadLine();

            if (number == "") return;
            if (int.TryParse(number, out int numumber))
            {
                if (numumber <= Hero.Inventory.Count)
                {
                    Items.UseItem(Hero.Inventory[numumber-1]);
                }
            }
            else Console.WriteLine("Введи номер предмета или Enter для закрытия инвентаря");

        }
    }
}
