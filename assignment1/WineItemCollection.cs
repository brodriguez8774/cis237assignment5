//Author: David Barnes
//CIS 237
//Assignment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItemCollection
    {
        #region Variables

        BeverageDBEntities beverageEntities = new BeverageDBEntities();

        /* Variables used for reading from CSV file */
        WineItem[] wineItems;
        int wineItemsLength;

        #endregion



        #region Constructor

        /// <summary>
        /// Base Constructor.
        /// </summary>
        public WineItemCollection()
        {

        }

        /// <summary>
        /// //Constuctor which needs size of the collection.
        /// </summary>
        /// <param name="size"></param>
        public WineItemCollection(int size)
        {
            wineItems = new WineItem[size];
            wineItemsLength = 0;
        }

        #endregion



        #region Methods

        /// <summary>
        /// Add a new item to the collection.
        /// </summary>
        /// <param name="id">Unique ID of beverage item.</param>
        /// <param name="name">Name of beverage item.</param>
        /// <param name="pack">Pack Size of beverage item.</param>
        /// <param name="price">Price of beverage pack.</param>
        /// <param name="active">Bool for beverage currently active or not.</param>
        /// <returns>Bool indicating if item was added.</returns>
        public bool AddNewItem(string id, string name, string pack, decimal price, Boolean active)
        {
            // Attempt to create a new beverage.
            try
            {
                // If ID is not already in database.
                if (FindById(id) != null)
                {
                    // Create new beverage with passed in information.
                    Beverage beverage = new Beverage();
                    beverage.id = id;
                    beverage.name = name;
                    beverage.pack = pack;
                    beverage.price = price;
                    beverage.active = active;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        
        //Get The Print String Array For All Items
        public string[] GetPrintStringsForAllItems()
        {
            //Create and array to hold all of the printed strings
            string[] allItemStrings = new string[wineItemsLength];
            //set a counter to be used
            int counter = 0;

            //If the wineItemsLength is greater than 0, create the array of strings
            if (wineItemsLength > 0)
            {
                //For each item in the collection
                foreach (WineItem wineItem in wineItems)
                {
                    //if the current item is not null.
                    if (wineItem != null)
                    {
                        //Add the results of calling ToString on the item to the string array.
                        allItemStrings[counter] = wineItem.ToString();
                        counter++;
                    }
                }
            }
            //Return the array of item strings
            return allItemStrings;
        }

        /// <summary>
        /// Find an item by its ID.
        /// </summary>
        /// <param name="id">String of item's unique ID.</param>
        /// <returns>Null if ID is not present, otherwise string of beverage's information.</returns>
        public string FindById(string id)
        {
            //Declare return string for the possible found item
            string returnString = null;

            //Search through database for ID.
            Beverage foundBeverage = beverageEntities.Beverages.Find(id);

            // If beverage is found in database
            if (foundBeverage != null)
            {
                returnString = foundBeverage.id + " " + foundBeverage.name + Environment.NewLine +
                    foundBeverage.pack + " " + foundBeverage.price + " " + foundBeverage.active;
            }
            
            //Return the returnString
            return returnString;
        }

        #endregion

    }
}
