//Author: David Barnes
// Edit: Brandon Rodriguez

/*  ASK ABOUT:
 * 1) Solution Requirements:
 *      "4 classes", including a Beverage and Beverages? Isn't Beverage provided by beverages database?
 * 2) Error with foreach entry in database.
 * 3) When to use singletons. (Only one instance of beverage collection is needed. Should that be static or singleton? Or neither? Same with UI)
 * */


/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set a constant for the size of the collection
            //const int wineItemCollectionSize = 4000;

            //Set a constant for the path to the CSV File
            //const string pathToCSVFile = "../../../datafiles/winelist.csv";

            //Create an instance of the UserInterface class
            UserInterface userInterface = new UserInterface();

            //Create an instance of the WineItemCollection class
            BeverageCollection beverageCollection = new BeverageCollection();

            // Load in/connect to Beverages from database.
            BeverageDBEntities beverageEntities = new BeverageDBEntities();

            //Display the Welcome Message to the user
            userInterface.DisplayWelcomeGreeting();

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 5)
            {
                switch (choice)
                {
                    case 1:
                        //Print Entire List Of Items
                        GenericLinkedList<string> stringList = beverageCollection.GetStringListForAllItems();
                        if (stringList.Length > 0)
                        {
                            //Display all of the items in linked list.
                            userInterface.DisplayAllListItems(stringList);
                        }
                        else
                        {
                            //Display error message for all items.
                            userInterface.DisplayAllItemsError();
                        }
                        break;

                    case 2:
                        //Search For An Item
                        string searchQuery = userInterface.GetSearchQuery();

                        Beverage beverageToFind = beverageEntities.Beverages.Where(a => a.id == searchQuery).First();
                        Beverage otherBeverageToFind = beverageEntities.Beverages.Find(searchQuery);

                        if (otherBeverageToFind != null)
                        {
                            userInterface.DisplayItemFound(otherBeverageToFind.id);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        /*string itemInformation = beverageCollection.FindById(searchQuery);
                        if (itemInformation != null)
                        {
                            userInterface.DisplayItemFound(itemInformation);
                        }
                        else
                        {
                            userInterface.DisplayItemFoundError();
                        }*/
                        break;

                    case 3:
                        //Add A New Item To The List
                        
                    
                    
                        /*string[] newItemInformation = userInterface.GetNewItemInformation();
                        if (beverageCollection.FindById(newItemInformation[0]) == null)
                        {
                            beverageCollection.AddNewItem(newItemInformation[0], newItemInformation[1], newItemInformation[2]);
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            userInterface.DisplayItemAlreadyExistsError();
                        }*/
                        break;

                    case 4:
                        // Delete item from list.
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
