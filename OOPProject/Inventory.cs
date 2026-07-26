using System;
using System.Collections.Generic;

namespace rpg
{
    public class Inventory
    {
        public List<Item> Items { get; set; }


        public Inventory()
        {
            Items = new List<Item>();
        }


        public void AddItem(Item item)
        {
            Items.Add(item);
        }


        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }


        public void ShowInventory()
        {
            Console.WriteLine("===== Inventory =====");


            if (Items.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }


            foreach (Item item in Items)
            {
                Console.WriteLine("- " + item.Name);
            }
        }
    }
}
