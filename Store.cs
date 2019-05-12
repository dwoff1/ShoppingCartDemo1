using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{
    class Store
    {
        Dictionary<int, Item> items;
        CustomConsole activeConsole;

        public Store(Dictionary<int, Item> _items, CustomConsole _activeConsole)
        {
            items = _items;
            activeConsole = _activeConsole;
        }

        public void ListItems()
        {
            if (items != null)
            {
                Console.WriteLine("\tStore Contains:\n--------------------------------\nID\t\tName\tCost\tDescription");
                Dictionary<int, Item>.Enumerator em = items.GetEnumerator();
                Item aItem;
                while (em.MoveNext())
                {
                    aItem = em.Current.Value;

                    if (aItem != null)
                        Console.WriteLine(" " + aItem.RefID + "\t" + aItem.Name + "\t$" + Math.Round(aItem.Cost, 4) + "\t" + aItem.Description + "\n");
                    else
                    {
                        activeConsole.Error("ERROR with aItem");
                        Console.ReadLine();
                    }
                }
                Console.WriteLine("--------------------------------\nNumber of Items: " + items.Count);
            }
        }

        public Dictionary<int, Item>.KeyCollection getIDKeys()
        {
            return items.Keys;
        }
        public Item ItemCheck(int _refID)
        {
            Item aItem;
            if (items.TryGetValue(_refID, out aItem))
            {
                return aItem;
            }
            else
            {
                return null;
            }
        }

        public Item getItem(int _refID)
        {
            Item theItem;
            if (items.TryGetValue(_refID, out theItem))
                return theItem;
            else
                return null;
        }
    }
}
