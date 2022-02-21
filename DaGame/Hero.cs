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

        public static List<string> Inventory = new List<string>();

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
    }
}
