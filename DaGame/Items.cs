using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame
{
    internal class Items
    {
        static Random random = new Random();

        static string[] potions = { "Зелье лечения", "Сильное зелье лечения"};
        static string[] bombs = { "Бомба", "Ядовитая бомба", "Оглушающая бомба"};
        static string[] items = { "Серьги", "Чётки", "Амулет"};
        ///static string[] properties = { "уворот", "хп", "атака", "крит"};

        static public string ChosenItem;

        static public void ChooseItem(string ItemType)
        {
            if (ItemType == "potions")
            {
                ChosenItem = potions[random.Next(potions.Length)];
                Hero.Inventory.Add(ChosenItem);
                Console.WriteLine("В твой инвентарь добавлено " + ChosenItem);
                if (ChosenItem == "Зелье лечения")
                {
                    Console.WriteLine(ChosenItem + " восстанавливает 5HP");
                }
                else Console.WriteLine(ChosenItem + " восстанавливает 15HP");

                Console.WriteLine("");
            }
            else if (ItemType == "items")
            {
                ChosenItem = items[random.Next(items.Length)];
                Hero.Inventory.Add(ChosenItem);
                Console.WriteLine(ChosenItem + " теперь в инвентаре");
                if (ChosenItem == "Серьги")
                {
                    Console.WriteLine(ChosenItem + " я хз накинь серге");
                }
                else if (ChosenItem == "Чётки")
                {
                    Console.WriteLine(ChosenItem + " чотки чочотки");
                }
                else Console.WriteLine(ChosenItem + " на шейку");
                
                Console.WriteLine("");
            }
            else if (ItemType == "bombs")
            {
                ChosenItem = bombs[random.Next(bombs.Length)];
                Hero.Inventory.Add(ChosenItem);
                Console.WriteLine("В твой инвентарь добавлена " + ChosenItem);
                if (ChosenItem == "Бомба")
                {
                    Console.WriteLine(ChosenItem + " наносит всем врагам 10 единиц урона");
                }
                else if (ChosenItem == "Ядовитая бомба")
                {
                    Console.WriteLine(ChosenItem + " наносит 3 единицы урона выбранному врагу 3 хода");
                }
                else Console.WriteLine(ChosenItem + " оглушает выбранного врага на 3 хода");

                Console.WriteLine("");
            }
        }

        static public void UseItem(string ItemName)
        {
            if(ItemName == "Зелье лечения")
            {
                Console.WriteLine(Hero.Name + " использует зелье лечения и восстанавливает 5HP");
                Hero.HP += 5;
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", зелье лечения удалено из инвентаря");
            }
            else if(ItemName == "Сильное зелье лечения")
            {
                Console.WriteLine(Hero.Name + " использует сильное зелье лечения и восстанавливает 15HP");
                Hero.HP += 15;
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", сильное зелье лечения удалено из инвентаря");
            }
            else if (ItemName == "Бомба")
            {
                Console.WriteLine(Hero.Name + " использует бомбу и наносит всем врагам 10 единиц урона");
                /// бомба я хз
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", бомба удалена из инвентаря");
            }
            else if (ItemName == "Ядовитая бомба")
            {
                Console.WriteLine(Hero.Name + " использует ядовитую бомбу и наносит 3 единицы урона выбранному врагу 3 хода");
                /// бомба я хз
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", ядовитая бомба удалена из инвентаря");
            }
            else if (ItemName == "Оглушающая бомба")
            {
                Console.WriteLine(Hero.Name + " использует оглушающую бомбу и оглушает выбранного врага на 3 хода");
                /// бомба я хз
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", оглушаяющая бомба удалена из инвентаря");
            }
        }


    }
}
