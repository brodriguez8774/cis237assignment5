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

        //Get the search query from the user
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
            Console.WriteLine("What is the new items Id?");
            Console.Write("> ");
            string id = Console.ReadLine();
            Console.WriteLine("What is the new items Description?");
            Console.Write("> ");
            string description = Console.ReadLine();
            Console.WriteLine("What is the new items Pack?");
            Console.Write("> ");
            string pack = Console.ReadLine();

            return new string[] { id, description, pack };
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

        //Display All Items
        public void DisplayAllItems(string[] allItemsOutput)
        {
            Console.WriteLine();
            foreach (string itemOutput in allItemsOutput)
            {
                Console.WriteLine(itemOutput);
            }
        }

        //Display All Items Error
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        //Display Item Found Success
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
