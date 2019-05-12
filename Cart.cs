using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{
    class Cart
    {
        //--------------(instance vars.)-----------------
        //ArrayList itemsInCart = new ArrayList();
        Dictionary<int, Item> itemsInCart = new Dictionary<int, Item>();
        int itemsCount; //count of items in cart
        //------------------(Constructors)------------------
        /// <summary>
        /// Creates instance of the users cart
        /// </summary>
        public Cart()
        {
            itemsCount = 0;
        }

        /// <summary>
        /// Adds a supplied Item Obj to the carts itemsInCart ArrayList
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public bool addToCart(Item _item)
        {
            itemsCount = itemsInCart.Count;
            Item freshItem = new Item(_item.Name, _item.Description, _item.Cost);
            itemsInCart.Add(freshItem.RefID, freshItem);
            if (itemsCount < itemsInCart.Count)
            {
                itemsCount = itemsInCart.Count;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveFromCart(int _id)
        {

            itemsCount = itemsInCart.Count;
            if (itemsInCart.ContainsKey(_id))
            {
                itemsInCart.Remove(_id);
                
                if (itemsCount > itemsInCart.Count)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public int GetItemsCount()
        {
            return (itemsCount = itemsInCart.Count);
        }

        /*public decimal CartSum()
        {
            decimal totalCost = 0;
            foreach (Item aItem in itemsInCart)
            {
                totalCost += aItem.Cost;
            }
            return totalCost;
        }*/
        public Item GetItemsCount(int _id)
        {
            Item aItem;

            if (itemsInCart.TryGetValue(_id, out aItem))
                return aItem;
            else
                return null;
        }
        public void DisplayCart()
        {
            Item aItem;
            decimal cartTotal = 0;
            /*
            Console.WriteLine("\tCart Contains:\n--------------------------------\n");
            foreach (Item aItem in itemsInCart)
            {
                Console.WriteLine(aItem.RefID + "\t" + aItem.Name + "\t" + aItem.Description + "\n" + Math.Round(aItem.Cost, 2));
            }
            Console.WriteLine("--------------------------------\nNumber of Items: " + itemsCount);
            Console.WriteLine("Cart Total: $" + CartSum()); */
            Console.WriteLine("\tCart Contains:\n--------------------------------\n");
            Dictionary<int, Item>.Enumerator em = itemsInCart.GetEnumerator();
            while (em.MoveNext())
            {
                aItem = em.Current.Value;
                cartTotal += aItem.Cost;
                Console.WriteLine(aItem.RefID + "\t" + aItem.Name + "\t" + Math.Round(aItem.Cost, 2) + "\t" + aItem.Description + "\n");
            }
            Console.WriteLine("--------------------------------\nNumber of Items: " + GetItemsCount());
            Console.WriteLine("Cart Total: $" + cartTotal);
        }
    }
}
