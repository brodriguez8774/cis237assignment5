//Author: David Barnes
// Edit: Brandon Rodriguez

/*  ASK ABOUT:
 * 1) Solution Requirements:
 *      "4 classes", including a Beverage and Beverages? Isn't Beverage provided by beverages database?
 * 2) Error with foreach entry in database.
 * 3) When to use singletons. (Only one instance of beverage collection is needed. Should that be static or singleton? Or neither? Same with UI)
 * Martin Fowler: Patterns of Enterprise Application Architecture
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

            //Create an instance of the BeverageCollection class
            BeverageCollection beverageCollection = BeverageCollection.get();

            // Load in/connect to Beverages from database.
            BeverageEntities beverageEntities = new BeverageEntities();

            //Display the Welcome Message to the user and make sure can connect.
            userInterface.DisplayWelcomeGreeting();
            try
            {
                beverageCollection.GetStringListForAllItems();
                userInterface.DisplayWelcomeGreetingConnected();
            }
            catch
            {
                Console.WriteLine("Database Connection Error! Program may not function correctly.");
            }

            //Display the Menu and get the response. Store the response in the choice integer
            //This is the 'primer' run of displaying and getting.
            int choice = userInterface.DisplayMenuAndGetResponse();

            while (choice != 6)
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
                        try
                        {
                            string searchQuery = userInterface.GetSearchQuery();

                            Beverage beverageToFind = beverageEntities.Beverages.Where(a => a.id == searchQuery).First();
                            Beverage otherBeverageToFind = beverageEntities.Beverages.Find(searchQuery);

                            if (beverageToFind != null)
                            {
                                userInterface.DisplayItemFound(UserInterface.ItemToString(beverageToFind));
                            }
                            else
                            {
                                userInterface.DisplayItemFoundError();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error");
                        }
                        break;

                    case 3:
                        //Add A New Item To The List
                        string[] newItemString = userInterface.GetNewItemInformation();

                        decimal aDecimal = Convert.ToDecimal(newItemString[3]);
                        bool aBool = false;
                        if (newItemString[4] == "t")
                        {
                            aBool = true;
                        }
                        if (beverageCollection.AddNewItem(newItemString[0], newItemString[1], newItemString[2], aDecimal, aBool))
                        {
                            userInterface.DisplayAddWineItemSuccess();
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                        break;

                    case 4:
                        // Update Item on List.
                        // Basicall combines add item and search for item.
                        // Redundant code but too lazy to put into methods cuz coding in main is annoying.


                        //Search For An Item
                        try
                        {
                            string updateSearchQuery = userInterface.GetSearchQuery();

                            Beverage beverageToUpdate = beverageEntities.Beverages.Where(aa => aa.id == updateSearchQuery).First();
                            Beverage otherBeverageToUpdate = beverageEntities.Beverages.Find(updateSearchQuery);

                            if (beverageToUpdate != null)
                            {
                                userInterface.DisplayItemFound(beverageToUpdate.id);
                            }
                            else
                            {
                                userInterface.DisplayItemFoundError();
                            }

                            //Update A New Item To The List
                            string[] updateItemString = userInterface.GetUpdateItemInformation();

                            decimal anDecimal = Convert.ToDecimal(updateItemString[3]);
                            bool anBool = false;
                            if (updateItemString[4] == "t")
                            {
                                anBool = true;
                            }
                            if (beverageCollection.UpdateItem(updateItemString[0], updateItemString[1], updateItemString[2], anDecimal, anBool))
                            {
                                userInterface.DisplayAddWineItemSuccess();
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Errorr");
                        }


                        
                        break;
                    case 5:
                        // Delete Item on List.
                        // Again, basically duplicates search.
                        //Search For An Item
                        try
                        {
                            string aasearchQuery = userInterface.GetSearchQuery();

                            Beverage aabeverageToFind = beverageEntities.Beverages.Where(aaa => aaa.id == aasearchQuery).First();
                            Beverage aaotherBeverageToFind = beverageEntities.Beverages.Find(aasearchQuery);

                            if (aabeverageToFind != null)
                            {
                                userInterface.DisplayItemFound(aabeverageToFind.id);

                                // Once found, remove.
                                beverageEntities.Beverages.Remove(aabeverageToFind);

                                beverageEntities.SaveChanges();
                                Console.WriteLine("Item Removed!");
                            }
                            else
                            {
                                userInterface.DisplayItemFoundError();
                            }
                        }
                        catch
                        {
                            userInterface.DisplayItemFoundError();
                        }

                        
                        break;
                }

                //Get the new choice of what to do from the user
                choice = userInterface.DisplayMenuAndGetResponse();
            }

        }
    }
}
