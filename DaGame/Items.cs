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

        static readonly string[] potions = { "Зелье лечения", "Сильное зелье лечения", "Противоядие", "Святая вода"};
        static readonly string[] bombs = { "Бомба", "Ядовитая бомба", "Оглушающая бомба"};
        static readonly string[] items = { "Серьги", "Чётки", "Амулет"};
        static readonly string[] properties = { "уворота", "здоровья", "атаки", "критического урона", "жизни"};

        public string ItemName;
        public string ItemProp;
        public double ItemValue;
        static int checker;
        static int counter;
        static int member;

        static public string ChosenItem;
        static public string ChosenAttribute;
        static public double AttributeValue;

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
                ChooseAtribute();
                Console.WriteLine("Тебе попался " + ChosenItem);             

                if (Hero.Equipment.Count == 0)
                {
                    Console.WriteLine("Предмета такого типа нет в инвентаре, " + Hero.Name + " надевает его на себя");
                    Hero.Equipment.Add(new Items() { ItemName = ChosenItem, ItemProp = ChosenAttribute, ItemValue = AttributeValue });
                    if (ChosenAttribute == "здоровья") Hero.MaxHP += (int)AttributeValue;
                    Console.WriteLine(ChosenItem + " " + ChosenAttribute + " " + AttributeValue + " - теперь надето");
                }
                else
                {
                    counter = 0;
                    checker = 0;
                    foreach (Items items in Hero.Equipment)
                    {
                        counter++;
                        Console.WriteLine("проверка предмета " + items.ItemName);
                        if (items.ItemName == ChosenItem)
                        {
                            checker++;
                            member = counter;
                        }
                    }
                    if(checker == 1)
                    {
                        Console.WriteLine(Hero.Equipment[member - 1].ItemName + " уже есть в инвентаре");
                        Console.WriteLine(Hero.Equipment[member - 1].ItemName + " " + Hero.Equipment[member - 1].ItemProp + " " + Hero.Equipment[member - 1].ItemValue + " - надето");
                        Console.WriteLine(ChosenItem + " " + ChosenAttribute + " " + AttributeValue + " - можете надеть");
                        Console.WriteLine("Если хочешь сменить предмет - нажми [q], если хочешь оставить предыдущий - нажми [e]");                        
                        while (true)
                        {
                            char input = Console.ReadKey(true).KeyChar;
                            if (input == 'q' || input == 'й')
                            {
                                if (Hero.Equipment[member - 1].ItemProp == "здоровья") Hero.MaxHP -= (int)Hero.Equipment[member - 1].ItemValue;
                                Hero.Equipment.RemoveAt(member - 1);
                                Hero.Equipment.Add(new Items() { ItemName = ChosenItem, ItemProp = ChosenAttribute, ItemValue = AttributeValue });
                                if (ChosenAttribute == "здоровья") Hero.MaxHP += (int)AttributeValue;
                                Console.WriteLine(ChosenItem + " " + ChosenAttribute + " " + AttributeValue + " - теперь надето, прежнее снаряжение выброшено");
                                break;
                            }
                            else if (input == 'e' || input == 'у')
                            {
                                Console.WriteLine(Hero.Equipment[member - 1].ItemName + " " + Hero.Equipment[member - 1].ItemProp + " " + Hero.Equipment[member - 1].ItemValue + " - все еще надето, другой предмет выброшен");
                                break;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Предмета такого типа нет в инвентаре, " + Hero.Name + " надевает его на себя");
                        Hero.Equipment.Add(new Items() { ItemName = ChosenItem, ItemProp = ChosenAttribute, ItemValue = AttributeValue });
                        if (ChosenAttribute == "здоровья") Hero.MaxHP += (int)AttributeValue;
                        Console.WriteLine(ChosenItem + " " + ChosenAttribute + " " + AttributeValue + " - теперь надето");
                    }
                }
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

        static void ChooseAtribute()
        {
            ChosenAttribute = properties[random.Next(properties.Length)];

            if (ChosenAttribute == "уворота")
            {
                AttributeValue = random.Next(10, 31) / 100D;
            }
            else if (ChosenAttribute == "здоровья")
            {
                AttributeValue = random.Next(3, 13);
            }
            else if (ChosenAttribute == "атаки")
            {
                AttributeValue = random.Next(1, 9);
            }
            else if (ChosenAttribute == "критического урона")
            {
                AttributeValue = random.Next(5, 16) / 100D;
            }
            else if (ChosenAttribute == "жизни")
            {
                AttributeValue = 1;
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
                Console.WriteLine(Hero.Name + " использует бомбу и наносит всем врагам 7 единиц урона");
                foreach (enemy enemumy in enemy.enemies)
                {
                    enemumy.HP -= 7;
                }
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", бомба удалена из инвентаря");
            }
            else if (ItemName == "Ядовитая бомба")
            {
                Console.WriteLine(Hero.Name + " использует ядовитую бомбу и наносит 3 единицы урона выбранному врагу 3 хода");
                int i = Program.InBattleEnemyChoose();
                enemy.enemies[i].PoisonCounter = 2;
                enemy.enemies[i].HP -= 3;
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", ядовитая бомба удалена из инвентаря");
            }
            else if (ItemName == "Оглушающая бомба")
            {
                Console.WriteLine(Hero.Name + " использует оглушающую бомбу и оглушает выбранного врага на 3 хода");
                int i = Program.InBattleEnemyChoose();
                enemy.enemies[i].StanCounter = 2;
                Hero.Inventory.Remove(ItemName);
                Console.WriteLine(Hero.Name + ", оглушаяющая бомба удалена из инвентаря");
            }
        }
    }
}
