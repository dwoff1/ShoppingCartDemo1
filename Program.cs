using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{
    class Program
    {
    //--------------(instance vars.)-----------------
        private static CustomConsole activeConsole = new CustomConsole();
        private static DataManager dm = new DataManager();
        private static Store thisStore = new Store(dm.GetItems(), activeConsole);
        public static Cart myCart;

    //--------------(Misc. Methods)-----------------
        static void Main(string[] args)
        {
            Console.WriteLine("\tCart 1.0\nInitializing---------------------");
            bool loop = true; //loop main menu till exit option triggered
            myCart = new Cart();

            Console.WriteLine("\n\nMenu\n----------------------------------");
            while (loop)
            {
                //display menu
                 int menuSize = activeConsole.DisplayMenu(dm.GetMenu("mainMenu"));
                 int input = activeConsole.ReadIntOption(0, menuSize);
                //act on input
                switch (input)
                {
                    case 0: //view cart
                            myCart.DisplayCart();
                        break;
                    case 1: //add to cart
                        AttemptItemAdd();
                        break;
                    case 2: //remove from cart
                        AttempItemRemove();
                        break;
                    case 3: //see the req. of task
                        Console.WriteLine("The requirements for this demo was to:\n" + dm.getRequirement());
                        break;
                    case 4: //exit
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("<<Press Enter To Continue>>");
                Console.ReadLine();//pause (and then consume the LfCr
            }
        }
    //--------------(Cart Methods)-----------------
        /// <summary>
        /// Attempts to add x 'copies' of a selected product to the users cart
        /// </summary>
        public static void AttemptItemAdd()
        {
            //display options
            thisStore.ListItems();
            //ask user to choose
            int itemID = activeConsole.IntPrompt("Please select the item to add your cart by ID", 0, thisStore.getIDKeys());
            int quanity = activeConsole.IntPrompt("Please type (as a Whole Number) the quantity you wish to buy of " + thisStore.getItem(itemID).Name, 0, 50);
            if (quanity > 0)
            {//add to cart (x) times
                for (int i = 0; i < quanity; i++)
                    myCart.addToCart(thisStore.getItem(itemID));
            }
            else
            {
                activeConsole.Error("\n Quantity < 0, returning to Menu.");
            }
        }

        /// <summary>
        /// Attempts to remove x 'copies' of a selected product from the users cart
        /// </summary>
        public static void AttempItemRemove()
        {
            myCart.DisplayCart();
            if (myCart.GetItemsCount() > 0)
            {
                ArrayList removalList = activeConsole.csvPrompt("Please select the item to remove from your cart by ID", 0, Item.itemCount);
                //int itemID = activeConsole.IntPrompt("Please select the item to remove from your cart by ID", 0, Item.itemCount);
               // int quanity = activeConsole.IntPrompt("Please type (as a Whole Number) the quantity you wish to remove from your cart for " + myCart.GetItemsCount(itemID).Name, 0, 20);
                //for (int i = 0; i < quanity; i++)
                foreach(int itemID in removalList)
                    myCart.RemoveFromCart(itemID);
            }
            else
            {
                activeConsole.Error("\n No Items to remove, returning to Menu.");
            }
        }
    }
}
