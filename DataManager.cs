using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{
    class DataManager
    {
        //CustomConsole activeConsole = new CustomConsole();
    //--------------(instance vars.)-----------------
        static Dictionary<String, Array> menus = new Dictionary<string, Array>(); //stores the menus for the program
        static Dictionary<int, Item> items = new Dictionary<int, Item>(); //stores items that can be put in cart
        String requirement = "So the idea is that the software should have preset items. In the basket I can have n amount of these items, where n is just however many I want. Each item has a price, obv. I should be able to add, remove and modify items - it should also be able to produce a total command line shopping basket to be more precise its a scenario where you're essentially programming in the intricacies of doing the weekend shopping";

    //------------------(Constructors)------------------
        /// <summary>
        /// Create a instance of a Data Managment Class (Menus, items and static strings)
        /// </summary>
        public DataManager()
        {
            CreateBaseItems();
            CreateBaseMenus();
        }

    //------------------(Exclusive GETs) //ie get only
        /// <summary>
        /// Retrieve the Demo's 'project' requirements / User Stories
        /// </summary>
        /// <returns> The Demo's requirements </returns>
        public String getRequirement()
        {
            return requirement;
        }

        /// <summary>
        /// Retrieves a menu from menus Dictionary if the _key exists
        /// </summary>
        /// <param name="_key"> Linked Key to be used in retrieving the menu option 'value' </param>
        /// <returns></returns>
        public Array GetMenu(String _key)
        {
            Array menu;
            if (menus.TryGetValue(_key, out menu))
            {
                return menu;
            }
            return menu;
        }

        /// <summary>
        /// Retrieve the Hardcoded Items for Store
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Item> GetItems()
        {
            return items;
        }

        //To be Implemented (Item Dictionary Push to Store Copy)

    //------------------(Data Create)
        /// <summary>
        /// Fill the 'menus' Dictionary with the options for a menu set
        /// </summary>
        private void CreateBaseMenus()
        {
            menus.Add("mainMenu", new String[] { "View cart", "Add to cart", "Remove from cart", "Code Requirements", "Exit" });
        }
        /// <summary>
        /// Step 1 to Fill out 'items' Dictionary with a freshly created Item
        /// </summary>
        private void CreateBaseItems()
        {
            CreateStoreItem("Chocolate", "a block of chocolate to enjoy", 3.50m); //m appended to Number for Decimal format
            CreateStoreItem("Red Apple", "a apple a day will make your dentist happy", 1.50m);
            CreateStoreItem("Chiko Roll", "Its a long way to the top for a Chiko Roll", 0.70m);
            CreateStoreItem("Coke 24x600ml", "Holiday's are coming, Holiday's ....", 18.50m);
        }
        /// <summary>
        /// Automates the Item creation and Dictionary.add()
        /// </summary>
        /// <param name="_name"> Item's Name</param>
        /// <param name="_description"> Items Description </param>
        /// <param name="_cost"> Items Cost (ensure m is appended)</param>
        private void CreateStoreItem(String _name, String _description, decimal _cost)
        {
            Item aItem = new Item(_name, _description, _cost);
            items.Add(aItem.RefID, aItem);
        }
    }
}
