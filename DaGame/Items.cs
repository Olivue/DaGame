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

        static string[] potions = { };
        static string[] bombs = { };
        static string[] items = { };

        static public string ChosenItem;

        static public string ChooseItem(string ItemType)
        {
            if (ItemType == "potions")
            {
                ChosenItem = potions[random.Next(potions.Length)];
                Hero.Inventory.Add(ChosenItem);
                return ChosenItem;
            }
            else if (ItemType == "bombs")
            {
                ChosenItem = bombs[random.Next(bombs.Length)];
                return ChosenItem;
            }
            else if (ItemType == "items")
            {
                ChosenItem = items[random.Next(items.Length)];
                return ChosenItem;
            }
            else return ChosenItem;
        }

        static public void RecieveItem()
        {

        }


    }
}
