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
        const int maxMenuChoice = 6;


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
            selection = this.GetInput();

            //While the response is not valid
            while (!this.VerifySelectionIsValid(selection))
            {
                //display error message
                this.DisplayMenuSelectionErrorMessage();

                //display the prompt again
                this.DisplayUserPrompt();

                //get the selection again
                selection = this.GetInput();
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
            return GetInput();
        }

        /// <summary>
        /// Get New Item Information From The User.
        /// </summary>
        /// <returns>String array of new item information.</returns>
        public string[] GetNewItemInformation()
        {
            string id = "";
            bool validBool = false;

            // Loop until user enters valid ID.
            while (!validBool)
            {
                Console.WriteLine();
                Console.WriteLine("What is the new item's Id? Must be 6 Characters.");
                Console.Write("> ");
                id = GetInput();

                // Validates ID.
                validBool = ValidateID(id);

                // Error message.
                if (!validBool)
                {
                    DisplayItemAlreadyExistsError();
                }
            }

            string[] tempString = GetUpdateItemInformation();
            tempString[0] = id;

            return tempString;
        }

        /// <summary>
        /// Gets Update Item information from User.
        /// </summary>
        /// <returns>String of update item information.</returns>
        public string[] GetUpdateItemInformation()
        {
            string price = "";
            string active = "";
            bool validBool = false;

            // Gets user input for name and pack.
            Console.WriteLine("What is the new item's Name?");
            Console.Write("> ");
            string name = GetInput();
            Console.WriteLine("What is the new item's Pack?");
            Console.Write("> ");
            string pack = GetInput();

            // Loop until user enters valid Price.
            validBool = false;
            while (!validBool)
            {
                Console.WriteLine("What is the new item's Price?" + Environment.NewLine +
                                    "Please enter in #.## format");
                Console.Write("> ");
                price = GetInput();

                validBool = ValidatePrice(price);

                if (!validBool)
                {
                    Console.WriteLine("Invalid Price.");
                }
            }

            // Loop until user enters valid Active.
            validBool = false;
            while (!validBool)
            {
                Console.WriteLine("Is the new item going to be immediately Active?" + Environment.NewLine +
                                    "Please enter 'T' or 'F'");
                Console.Write("> ");
                active = GetInput().ToLower();
                validBool = ValidateActive(active);

                if (!validBool)
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            return new string[] { "a", name, pack, price, active };
        }

        /// <summary>
        /// Displays output of all items inside linked list.
        /// </summary>
        /// <param name="allItemsOutput">Linked List filled with strings from database information.</param>
        public void DisplayAllListItems(GenericLinkedList<string> allItemsOutput)
        {
            Console.WriteLine();
            int indexInt = 0;
            while (indexInt < allItemsOutput.Length)
            {
                Console.WriteLine(allItemsOutput.Retrieve(1).Data);
                allItemsOutput.DeQueue();
                indexInt++;
            }
        }

        /// <summary>
        /// Display All Items Error.
        /// </summary>
        public void DisplayAllItemsError()
        {
            Console.WriteLine();
            Console.WriteLine("There are no items in the list to print");
        }

        /// <summary>
        /// Display Item Found Success.
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

        /// <summary>
        /// Display Add Wine Item Success.
        /// </summary>
        public void DisplayAddWineItemSuccess()
        {
            Console.WriteLine();
            Console.WriteLine("The Item was successfully added");
        }

        /// <summary>
        /// Display Item Already Exists Error
        /// </summary>
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
            return beverage.id.Trim() + "   " + beverage.name.Trim() + "   " + beverage.pack.Trim() + "   " + beverage.price.ToString().Trim() + "   " + beverage.active.ToString().Trim();
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
            Console.WriteLine("1. Print The Entire List Of Items");
            Console.WriteLine("2. Search For An Item");
            Console.WriteLine("3. Add New Item To The List");
            Console.WriteLine("4. Update Item on list");
            Console.WriteLine("5. Remove Item from List");
            Console.WriteLine("6. Exit Program");
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
        private string GetInput()
        {
            return Console.ReadLine().Trim();
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

        /// <summary>
        /// Checks for valid ID input.
        /// </summary>
        /// <param name="id">Input ID.</param>
        /// <returns>If Id is valid.</returns>
        private bool ValidateID(string id)
        {
            // Load up beverage collection for single method.
            BeverageCollection beverageCollection = BeverageCollection.get();

            // If ID is not found within beverage database, end loop.
            if (beverageCollection.FindById(id) == null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks for valid Price input.
        /// </summary>
        /// <param name="price">Input Price.</param>
        /// <returns>If Price is valid.</returns>
        private bool ValidatePrice(string price)
        {
            try
            {
                decimal priceDecimal = Convert.ToDecimal(price);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks for valid Active input.
        /// </summary>
        /// <param name="active">Input Active.</param>
        /// <returns>If Active is valid.</returns>
        private bool ValidateActive(string active)
        {
            // If input is either 't' or 'f', return true.
            if (active == "t")
            {
                return true;
            }

            if (active == "f")
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
