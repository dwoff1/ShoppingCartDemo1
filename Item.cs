using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketDemo
{
    class Item
    {
    //--------------(instance vars.)-----------------
        private int refID;
        private String name;
        private String description;
        private decimal cost;
  
        public static int itemCount; //a static var to assign unique refID's

    //------------------(Constructors)------------------
        /// <summary>
        /// Create instance of a Item
        /// </summary>
        /// <param name="_name"> Name of Item</param>
        /// <param name="_description"> Description for Item</param>
        /// <param name="_cost"> The Cost to buy the Item </param>
        public Item(String _name, String _description, decimal _cost)
        {
            refID = itemCount++;
            name = _name;
            description = _description;
            cost = _cost;
        }

    //------------------(GET/SETS)------------------
        /// <summary>
        /// returns RefID when called as itemInstanceName.RefID
        /// </summary>
        public int RefID
        {
            get { return refID; }
        }
        /// <summary>
        /// Used to check current # of items.
        /// </summary>
        public int ItemCount
        {
            get { return itemCount; }
        }
        /// <summary>
        /// Returns or sets the 'name'
        /// </summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        ///  Returns or sets the 'Description'
        /// </summary>
        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Returns or sets the 'Cost'
        /// </summary>
        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

     
    }
}

