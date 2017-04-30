/*  Midterm Project
 *  Library Terminal
 *  Group:  Lanna, Alex, Theresa
 *  Date Last Modified:  4/30/17
 */


// ****** TO DO:

// split into lines 

// put the column info into anoabject of type book 

// put the book into ur list 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Program
    {
        static void Main(string[] args)
        {

            // Change Font Color
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            // Declare Console Title
            Console.Title = ("Grand Library Terminal");


            // Welcome Message
            Console.WriteLine("Welcome to the Grand Library!\n");


            // Start of Menu
            Console.WriteLine("\nWhat Can We Help You With Today at The Grand Library?\n\n");


            // Start of Continue Loop
            while (true)
            {

                // Call Get Option Method to Show Menu and Get User Input
                GetOption();





                // Continue Loop
                if (!Validation.GetContinue())
                {
                    Console.WriteLine("Thanks And Have A Great Day!!");
                    return;
                }
            }
        }






        // **********  Methods Begin Here  ********** \\


        // Method to Get User Option of What They Would Like to Do Within The Menu
        public static void GetOption()
        {

            int Option;

            // User Chooses to Check In a Book, Check Out a Book, Donate a Book, or Search for a Book
            string[] MenuValues = { "Check-Out a Book", "Return a Book", "Search for a Book by Title", "Search for a Book by Author", "Donate a Book" };

            // Print List of Menu Values with Select Numbers
            for (int i = 0; i < MenuValues.Length; i++)
            {

                Console.WriteLine($"{i + 1}.)\t{MenuValues[i]}");
            }


            // Get User Choice
            Console.Write("\n\nPlease Type the Number Associated With The Option You'd Like\n\n   ----->  ");


            // User Choice Output
            string Choice;
            Option = Validation.GetRange(1, 5);
            Console.WriteLine();
            Console.WriteLine($"\nYou Chose The Option To {MenuValues[Option - 1]}.\n\n");


            // ***** Functions For Each Option ***** //
            // Function For Option #1
            if (Option == 1)
            {
                // User Input
                Console.WriteLine("Please Select a Book to Check Out From the List Below:");
                Console.WriteLine("-------------------------------------------------------------\n");



                // Show User List of Books to Choose From
                PrintList(GetList());
                Console.Write("\n---->  ");

                Checkout(GetList());

                //Choice = Validation.GetValidString();
                //Console.WriteLine("\nThank You For Checking Out " + Choice + ".  The Due Date is Two Weeks From Today's Date.");


            }


            // Function For Option #2
            else if (Option == 2)
            {

                PrintList(GetList());
                Console.Write("Please Type in The Title of The Book You Are Returning:\n---->  ");

                Return(GetList());

                //Choice = Validation.GetValidString();
                //Console.WriteLine("Thank You For Returning " + Choice);
            }


            // Function For Option #3
            else if (Option == 3)
            {
                Console.WriteLine("Please Type in The Name of The Book You Are Looking For:\n---->  ");
                Choice = Validation.GetValidString();
            }


            // Function For Option #4
            else if (Option == 4)
            {
                Console.WriteLine("Please Type in The Author of The Book You Are Looking For:\n---->  ");
                Choice = Validation.GetValidString();
            }


            // Function For Option #5
            else if (Option == 5)
            {

                //string ChoiceTitle;
                //string ChoiceAuthor;
                //Console.WriteLine("Please Enter in The Information For The Book You Are Donating:\n");
                //Console.Write("Book Title: ");
                //ChoiceTitle = Validation.GetValidString();
                //Console.Write("Book Author: ");
                //ChoiceAuthor = Validation.GetValidString();
                //string Status = ("Available");
                //List<Books> NewList = new List<Books>();
                //NewList.Add(new Books(ChoiceTitle, ChoiceAuthor, Status));
                //List<Books> DonationList = AddBook(GetList());
                //Console.WriteLine("Thank You For Donating " + ChoiceTitle + " By " + ChoiceAuthor);
            }
        }




        // Method to Populate List of Books
        public static List<Books> GetList()
        {

            //new list called catalogue
            List<Books> Catalogue = new List<Books>();
            StreamReader reader = new StreamReader("../../TextFile1.txt ");
            //this is one line from text file or one book
            char[] comma = { ',' };
            for (int i = 0; i < 14; i++)

            {
                string line = reader.ReadLine();
                //string[] book = new string[4];
                string[] book = line.Split(comma);
                string Title = book[0];
                string Author = book[1];
                string Status = book[2];
                string DueDate = book[3];
                Catalogue.Add(new Books(Title, Author, Status, DueDate));
            }
            reader.Close();
            return Catalogue;
        }



        // Method To Print List
        public static void PrintList(List<Books> InputList)
        {
            foreach (var item in InputList)
            {
                Console.WriteLine("Title:\t" + item.BTitle);
                Console.WriteLine("Author:\t" + item.BAuthor);
                Console.WriteLine("Status:\t" + item.BStatus);
                Console.WriteLine("Due Date:\t" + item.BDueDate);
                Console.WriteLine("\n=====================================\n");
            }
        }



        // Method to Add a Book
        //public static List<Books> AddBook(List<Books> InputList)
        //{
        //    string Title = Validation.GetValidString();
        //    string Author = Validation.GetValidString();
        //    string Status = "Available";
        //    InputList.Add(new Books(Title, Author, Status));
        //    return InputList;
        //}


        // Method To Write To File
        public static void WriteToText(List<Books> inputList)
        {
            StreamWriter sw = new StreamWriter("../../TextFile1.txt", false);

            foreach (var item in inputList)
            {
                sw.WriteLine(item.BTitle + "," + item.BAuthor + "," + item.BStatus + ","
                    + item.BDueDate);

            }
            sw.Close();
        }



        public static void Checkout(List<Books> inputCatalogue)
        {
            Console.Write("Check out: ");
            string ItemToCheckOut = Console.ReadLine().ToLower(); // add validation here
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToCheckOut && !(item.BStatus == "Checked-out"))
                {
                    item.BStatus = "Checked-out";
                    item.BDueDate = myDateTime.AddDays(14).ToShortDateString();
                    Console.WriteLine($"{item.BTitle} is checked out.");
                    Console.WriteLine($"and is due on {item.BDueDate}");
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("not available");
            }

            WriteToText(inputCatalogue);

        }


        public static void Return(List<Books> inputCatalogue)
        {
            Console.Write("Return: ");
            string ItemToReturn = Console.ReadLine().ToLower();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string Titlelower = item.BTitle.ToLower();
                if (Titlelower == ItemToReturn && !(item.BStatus == "Avaiable"))
                {
                    item.BStatus = "Available";
                    item.BDueDate = "N/A";
                    Console.WriteLine($"thank you for returning {item.BTitle}.");
                    //if (Convert.ToDouble(item.BDueDate) > Convert.ToDouble(myDateTime))
                    //{
                    //    Console.WriteLine("your item is late you owe us money");
                    //}
                }
                else
                {
                    count++;
                }

            }
            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("that book is already returned or not in our system");
            }

            WriteToText(inputCatalogue);


        }



        //// Method to Get Book Status
        //public static StatusValues GetBookStatus()
        //{

        //    int choice = 0;

        //    StatusValues UserChoice = StatusValues.Available;

        //    switch (choice)
        //    {
        //        case 1:
        //            UserChoice = StatusValues.Available;
        //            break;

        //        case 2:
        //            UserChoice = StatusValues.CheckedOut;
        //            break;
        //    }

        //    return UserChoice;
        //}
    }
}