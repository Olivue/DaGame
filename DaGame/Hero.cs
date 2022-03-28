﻿using System;
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
        public static int HP = 500;
        public static int Attack = 10;
        public static int Exp;
        public static double HeroEvasion = 0.2;
        public static double HeroCrit = 0.05;
        static double Riser;
        public static bool secondAttMarker;
        public static bool thirdAttMarker;
        public static int DebaffCounter = 0;
        public static int PoisonCounter = 0;

        public static List<string> Inventory = new List<string>();
        public static List<string> Equip = new List<string>();
        public static List<Items> Equipment = new List<Items>();
        static List<int> level = new List<int> { 20, 50, 100, 200 };

        public static void LevelUp()
        {
            if(Hero.Exp >= level[0])
            {
                MaxHP += 5;
                Attack += 2;
                Console.WriteLine("Ты достигаешь нового уровня!");
                Console.WriteLine("Максимальное колличество здоровья и атаки увеличено!");
                Console.WriteLine("MaxHP = " + MaxHP + ", Attack = " + Attack);
                Console.WriteLine("Твое здоровье восстановленно!");
                Console.WriteLine("");
                HP = MaxHP;
                level.RemoveAt(0);
            }
        }

        public static bool Evasion() ///gotovo
        {
            double evasion = random.NextDouble();
            Riser = 0;
            foreach(Items item in Equipment) if (item.ItemProp == "уворота") Riser += item.ItemValue;
            if (evasion <= HeroEvasion + Riser) return true;
            else return false;
        }

        public static void CheckInventory() /// gotovo
        {
            if (!Inventory.Any() & !Equipment.Any()) 
            {
                Console.WriteLine("В инвентаре сейчас ничего нет");
                return;
            }
            if(Inventory.Any()) Console.WriteLine("В инвентаре сейчас следующие предметы:");
            int i = 1;
            foreach (string item in Inventory)
            {
                Console.WriteLine(i + " " + item);
                i++;
            }
            Console.WriteLine("");
            Console.WriteLine("На тебе надеты следующие предметы:");
            foreach (Items item in Equipment) Console.WriteLine(item.ItemName + " " + item.ItemProp);
            if (Inventory.Any()) Console.WriteLine("Для использования предмета введите его номер, для выхода из инвентаря нажмите Enter");
            else Console.WriteLine("Для выхода из инвентаря нажмите Enter");
            string number = Console.ReadLine();
            if (number == "") return;
            if (int.TryParse(number, out int numumber) & numumber <= Inventory.Count & numumber > 0) Items.UseItem(Inventory[numumber - 1]);
            else Console.WriteLine("Ты не находишь в инвентаре ничего подходящего");
        }

        public static int HeroAttack() // gotovo
        {
            int att = 0;
            if (Program.SecondAttack || Program.ThirdAttack) 
            {
                Console.WriteLine("Выбери тип атаки:");
                if (Program.SecondAttack) Console.Write("обычная атака - [q] атака по площади - [w]");
                if(Program.ThirdAttack) Console.WriteLine(" сильная атака - [e]");
                Console.WriteLine("");
                while (true)
                {
                    char input = Console.ReadKey(true).KeyChar;
                    if (input == 'q' || input == 'й')
                    {
                        Console.WriteLine("пищ пищ пуу");
                        att = Attack - random.Next(4);
                        break;
                    }
                    else if (input == 'w' || input == 'ц')
                    {
                        Console.WriteLine("баба хххх");
                        secondAttMarker = true;
                        att = Attack - random.Next(3, 6);
                        break;
                    }
                    else if ((input == 'e' || input == 'у') & Program.ThirdAttack)
                    {
                        Console.WriteLine("пдыыыщщщ");
                        thirdAttMarker = true;
                        att = Attack + random.Next(3, 6);
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("пищ пищ пуу");
                att = Attack - random.Next(4);                
            }
            Console.WriteLine("");
            int addAtt = 0;
            foreach (Items item in Equipment) if (item.ItemProp == "атаки") addAtt += (int)item.ItemValue;
            return att + CritCheck() + addAtt;
        }
        public static void LifeCheck()
        {
            int counter = 0;
            foreach(Items item in Equipment) if (item.ItemProp == "жизни") counter++;
            if(counter >= 1) 
            {
                int pizka = Equipment.FindIndex(x => x.ItemProp == "жизни");
                Console.WriteLine(Equipment[pizka].ItemName + " " + Equipment[pizka].ItemProp + " разрушается и спасает вам жизнь, здоровье восстановлено наполовину");
                Equipment.RemoveAt(pizka);
                HP = MaxHP / 2;
            }
        }
        static int CritCheck()
        {
            double crit = random.NextDouble();
            int critAtt = random.Next(5, 11);
            Riser = 0;
            foreach (Items item in Equipment) if (item.ItemProp == "уворота") Riser += item.ItemValue;
            if (crit <= HeroCrit + Riser) 
            {
                Console.WriteLine(Name + " наносит критический урон");
                return critAtt; 
            }
            else return 0;
        }
    }
}
