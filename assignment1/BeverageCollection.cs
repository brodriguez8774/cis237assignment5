//Author: David Barnes
// Edit: Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class BeverageCollection
    {
        #region Variables

        BeverageEntities beverageEntities = new BeverageEntities();

        /* Variables used for reading from CSV file */
        //WineItem[] wineItems;
        //int wineItemsLength;

        #endregion



        #region Singleton Constructor

        private static BeverageCollection beverageCollection;

        /// <summary>
        /// Returns BeverageCollection Singleton.
        /// </summary>
        /// <returns>BeverageCollection Singleton.</returns>
        public static BeverageCollection get()
        {
            if (beverageCollection == null)
            {
                beverageCollection = new BeverageCollection();
            }
            return beverageCollection;
        }

        /// <summary>
        /// Base Constructor.
        /// </summary>
        private BeverageCollection()
        {

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
        public bool AddNewItem(string id, string name, string pack, decimal price, bool active)
        {
            // Attempt to create a new beverage.
            try
            {
                // If ID is not already in database.
                if (FindById(id) == null)
                {
                    // Create new beverage with passed in information.
                    Beverage beverage = new Beverage();
                    beverage.id = id;
                    beverage.name = name;
                    beverage.pack = pack;
                    beverage.price = price;
                    beverage.active = active;

                    beverageEntities.Beverages.Add(beverage);
                    beverageEntities.SaveChanges();
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
        
        public bool UpdateItem(string id, string name, string pack, decimal price, Boolean active)
        {
            // Attempt to update Beverage.
            try
            {
                // Doublecheck that beverage exists.
                Beverage beverageToUpdate = beverageEntities.Beverages.Find(id);

                // Update beverage.
                if (beverageToUpdate != null)
                {
                    beverageToUpdate.name = name;
                    beverageToUpdate.pack = pack;
                    beverageToUpdate.price = price;
                    beverageToUpdate.active = active;
                }
                else
                {
                    return false;
                }

                // Save to database.
                beverageEntities.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Get The Print String Array For All Items
        /// </summary>
        /// <returns>Linked list of all items information.</returns>
        public GenericLinkedList<string> GetStringListForAllItems()
        {
            //Create a linked list to hold all of the printed strings
            GenericLinkedList<string> beveragesList = new GenericLinkedList<string>();          

            // Loops through list and adds each to list.
            foreach (Beverage beverage in beverageEntities.Beverages)
            {
                beveragesList.Enqueue(UserInterface.ItemToString(beverage));
            }

            //Return the List of item strings
            return beveragesList;
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
                returnString = UserInterface.ItemToString(foundBeverage);
            }
            
            //Return the returnString
            return returnString;
        }

        #endregion

    }
}
