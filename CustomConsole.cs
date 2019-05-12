using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{

    
    class CustomConsole
    {
    //------------------(Constructors)------------------
        /// <summary>
        /// Initialise a customised Console, setting title and allowing sub functions to be called
        /// </summary>
        public CustomConsole()
        {
            Console.Title = "Shopping Cart Code Demo";
        }

    //------------------(Custom Writes)------------------
        /// <summary>
        /// Types '>>>' in color green before changing to white for input.
        /// <c>TDLR: </c> console.ResetColor();
        /// </summary>
        private void TypePrompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(">>>");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Formats error messages to be red
        /// </summary>
        /// <param name="_message">the error message to be displayed</param>
        public void Error(String _message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_message);
            Console.ResetColor();
        }

        /// <summary>
        /// Turn supplied Array into a menu via console.WriteLine
        /// </summary>
        /// <param name="_menuOptions"> Array of options that are to be in the menu</param>
        /// <returns></returns>
        public int DisplayMenu(Array _menuOptions)
        {
            int menuLength = 0;
            foreach (string menuOption in _menuOptions)
            {
                Console.WriteLine("(" + menuLength++ + ") " + menuOption);
            }
            return menuLength; //ie allow error check to ensure all menu options were displayed
        }

        /// <summary>
        /// Prompts for user to enter a Int value and checks if contained in _validKeys if not continues
        /// </summary>
        /// <param name="_prompt"> The prompt for user to advise what we are wanting </param>
        /// <param name="_min"> The Minimal value permimmited </param>
        /// <param name="_validKeys"> the Keys that input is to be compared against</param>
        /// <returns>The int value selected by user </returns>
        public int IntPrompt(String _prompt, int _min, Dictionary<int, Item>.KeyCollection _validKeys)
        {
            int input;
            while (true)
            {
                Console.WriteLine(_prompt);
                TypePrompt();
                bool convertSuccess = int.TryParse(Console.ReadLine(), out input); //try passing the input to int (output onto input) if fail advise on convertSuccess
                Console.ResetColor();
                if (convertSuccess)
                {
                    //range check
                    if (input >= _min && _validKeys.Contains(input))
                    {
                        return input;
                    }
                }
                Error("\tError:\n Please confirm the number you entered is listed for a product");
            }
            
        }
        /// <summary>
        /// Similar to key version, performs a range check on int value entered 
        /// </summary>
        /// <param name="_prompt">The prompt for user to advise what we are wanting</param>
        /// <param name="_min">The Minimal value permimmited  user </param>
        /// <param name="_max"> The Maximal value permimmited from user </param>
        /// <returns>The int value selected by user </returns>
        public int IntPrompt(String _prompt, int _min, int _max)
        {
            int input;
            while (true)
            {
                Console.WriteLine(_prompt);
                TypePrompt();
                bool convertSuccess = int.TryParse(Console.ReadLine(), out input); //try passing the input to int (output onto input) if fail advise on convertSuccess
                Console.ResetColor();
                if (convertSuccess)
                {
                    //range check
                    if (input >= _min && input < _max)
                    {
                        return input; 
                    }
                }
                Error("\tError:\n Please confirm the number you entered is between " + _min + " and " + _max);
            }

        }

        //------------------(Custom Reads)------------------
        /// <summary>
        ///     Read input for a int between _minSize and _maxSize
        /// </summary>
        /// <param name="_minSize"> minimal accepted input value</param>
        /// <param name="_maxSize"> maximum accepted input value - 1</param>
        /// <returns></returns>
        public int ReadIntOption(int _minSize, int _maxSize)
        {
            int input = (_minSize - 1);
            bool loop = true;
            while (loop)
            {
                TypePrompt();

                bool convertSuccess = int.TryParse(Console.ReadLine(), out input); //try passing the input to int (output onto input) if fail advise on convertSuccess
                Console.ResetColor();
                if (convertSuccess)
                {
                    //range check
                    if (input >= _minSize && input < _maxSize)
                    {
                        return input;
                    }
                }//end conversion check
                Error("\t(!) Error:\nPlease enter a whole number between 0 and " + (_maxSize - 1) + "\n");
            }
            return -1;
        }

        /// <summary>
        /// Prior to refID being used, I instead used the name for Add/Remove
        /// </summary>
        /// <param name="_itemList"> value key values </param>
        /// <param name="csv"> boolean check whether user input is comma seperated</param>
        /// <returns></returns>
        public ArrayList ReadStrDictOption(Dictionary<String, Item> _itemList, bool csv) //could re-implement as a alt. to refID check
        {
            /**
             * Type a input prompt, and read line,
             * if CSV enabled, split on ', '
             * otherwise just assign input to the array used if split
             * (reset colors to ensure standard)
             * for each CSV from input check if it is a valid key
             * 
             * */
            Dictionary<String, Item>.KeyCollection keys = _itemList.Keys;
            ArrayList itemsFound = new ArrayList();
            String input = null;
            String[] inputArray = null;
            Item aItem;
            TypePrompt();
            input = Console.ReadLine(); //try passing the input to int (output onto input) if fail advise on convertSuccess
            if (csv)
            {
                // inputArray = input.Split(new Char[] { ',' });
                inputArray = input.Split(new string[] { ", " }, StringSplitOptions.None);
            }
            else
            {
                inputArray = new String[] { input };
            }
            Console.ResetColor();
            foreach (String aInput in inputArray)
            {
                // aInput.ToUpperInvariant();
                if (keys.Contains(aInput.ToLower()))
                {
                    if (_itemList.TryGetValue(aInput, out aItem))
                    {
                        itemsFound.Add(aItem);
                    }

                }
            }
            return itemsFound;
        }
    }//End class
}
