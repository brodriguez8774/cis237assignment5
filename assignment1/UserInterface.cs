//Author: David Barnes
// Edit: Brandon Rodriguez

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class UserInterface
    {
        const int maxMenuChoice = 5;


        #region Public Methods

        /// <summary>
        /// Display Welcome Greeting (Pt 1).
        /// </summary>
        public void DisplayWelcomeGreeting()
        {
            Console.WriteLine("Welcome to the wine program" + Environment.NewLine +
                "Connecting to Database...");
        }

        /// <summary>
        /// Display Welcome Greeting (Pt 2).
        /// </summary>
        public void DisplayWelcomeGreetingConnected()
        {
            Console.WriteLine("Connected!");
        }

        /// <summary>
        /// Display Menu And Get Response.
        /// </summary>
        /// <returns></returns>
        public int DisplayMenuAndGetResponse()
        {
            //declare variable to hold the selection
            string selection;

            //Display menu, and prompt
            this.displayMenu();
            this.DisplayUserPrompt();

            //Get the selection they enter
            selection = this.GetSelection();

            //While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                //display error message
                this.DisplayMenuSelectionErrorMessage();

                //display the prompt again
                this.DisplayUserPrompt();

                //get the selection again
                selection = this.GetSelection();
            }
            //Return the selection casted to an integer
            return Int32.Parse(selection);
        }

        /// <summary>
        /// Get the search query from the user
        /// </summary>
        /// <returns>Console Input from user.</returns>
        public string GetSearchQuery()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to search for?");
            Console.Write("> ");
            return Console.ReadLine();
        }

        //Get New Item Information From The User.
        public string[] GetNewItemInformation()
        {
            Console.WriteLine();
            Console.WriteLine("What is the new item's Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new item's Name?");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.WriteLine("What is the new item's Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();
            Console.WriteLine("What is the new item's Price?" + Environment.NewLine +
                                "Please enter in #.## format");
            Console.Write("> ");
            string price = Console.ReadLine();
            Console.WriteLine("Is the new item going to be immediately Active?" + Environment.NewLine +
                                "Please enter 'T' or 'F'");
            Console.Write("> ");
            string active = Console.ReadLine();

            return new string[] { id, name, pack, price, active };
        }

        //Display Import Success
        public void DisplayImportSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("Wine List Has Been Imported Successfully");
        }

        //Display Import Error
        public void DisplayImportError()
        {
            Console.WriteLine();
            Console.WriteLine("There was an error importing the CSV");
        }

        /// <summary>
        /// Displays output of all items inside linked list.
        /// </summary>
        /// <param name="allItemsOutput">Linked List filled with strings from database information.</param>
        public void DisplayAllListItems(GenericLinkedList<string> allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
                allItemsOutput.DeQueue();
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        /// <summary>
        /// Display Item Found Success
        /// </summary>
        /// <param name="itemInformation"></param>
        public void DisplayItemFound(string itemInformation)
        {
            Console.WriteLine();
            Console.WriteLine("Item Found!");
            Console.WriteLine(itemInformation);
        }

        //Display Item Found Error
        public void DisplayItemFoundError()
        {
            Console.WriteLine();
            Console.WriteLine("A Match was not found");
        }

        //Display Add Wine Item Success
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        //Display Item Already Exists Error
        public void DisplayItemAlreadyExistsError()
        {
            Console.WriteLine();
            Console.WriteLine("An Item With That Id Already Exists");
        }

        /// <summary>
        /// Converts Beverage information into full string.
        /// </summary>
        /// <param name="beverage">Beverage to make a string of.</param>
        /// <returns>String of Beverage's information.</returns>
        public static string ItemToString(Beverage beverage)
        {
            return beverage.id + " " + beverage.name + Environment.NewLine +
                    beverage.pack + " " + beverage.price + " " + beverage.active;
        }

        #endregion



        #region Private Methods
        
        /// <summary>
        /// Display the Main Menu.
        /// </summary>
        private void displayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. Load Wine List From CSV");
            Console.WriteLine("2. Print The Entire List Of Items");
            Console.WriteLine("3. Search For An Item");
            Console.WriteLine("4. Add New Item To The List");
            Console.WriteLine("5. Exit Program");
        }

        /// <summary>
        /// Display the User Prompt.
        /// </summary>
        private void DisplayUserPrompt()
        {
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
        }

        /// <summary>
        /// Display the Error Message for Menu Selection.
        /// </summary>
        private void DisplayMenuSelectionErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine("That is not a valid option. Please make a valid choice");
        }

        /// <summary>
        /// Get input from the user.
        /// </summary>
        /// <returns>String of user's input.</returns>
        private string GetSelection()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Verify that a selection from the main menu is valid
        /// </summary>
        /// <param name="selection">String of user's current input.</param>
        /// <returns>Bool indicating if user's input is valid.</returns>
        private bool VerifySelectionIsValid(string selection)
        {
            //Declare a returnValue and set it to false
            bool returnValue = false;

            try
            {
                //Parse the selection into a choice variable
                int choice = Int32.Parse(selection);

                //If the choice is between 0 and the maxMenuChoice
                if (choice > 0 && choice <= maxMenuChoice)
                {
                    //set the return value to true
                    returnValue = true;
                }
            }
            //If the selection is not a valid number, this exception will be thrown
            catch (Exception e)
            {
                //set return value to false even though it should already be false
                returnValue = false;
            }

            //Return the reutrnValue
            return returnValue;
        }

        #endregion

    }
}
