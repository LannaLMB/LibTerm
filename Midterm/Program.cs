/*  Midterm Project
 *  Library Terminal
 *  Group:  Lanna, Alex, Theresa
 *  Date Last Modified:  5/01/17
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
            // Starts Playing a Song When You Run the Program
            FileStream fs = new FileStream(@"C:\Users\Jake & Lanna\Desktop\projects\Midterm\Midterm\jammin.wav", FileMode.Open, FileAccess.Read);
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(fs);
            sp.Play();

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


                // Continue Loop Choice
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
                SearchbyKeyWord(GetList());
            }


            // Function For Option #4
            else if (Option == 4)
            {
                // Call Method to Search By Author
                SearchByAuthor(GetList());

            }


            // Function For Option #5
            else if (Option == 5)
            {
                WriteToText(AddBooks(GetList()));
            }
        }



        // Method to Populate List of Books
        public static List<Books> GetList()
        {

            //new list called catalogue
            List<Books> Catalogue = new List<Books>();
            StreamReader reader = new StreamReader("../../OurDataBase.txt ");

            //this is one line from text file or one book
            char[] comma = { ',' };
            var lineCount = File.ReadLines("../../OurDataBase.txt").Count();
            for (int i = 0; i < lineCount; i++)

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



        //This Method Passes in a List<Books> and it Prompts the User to Enter in a Title to Checkout, 
        //it Then Goes and Changes the Values from Avaiable to Checked Out and Changes N/A to a Due Date (2 weeks)
        public static void Checkout(List<Books> inputCatalogue)
        {

            Console.Write("Please Enter The Name Of The Book You Would Like To Check Out: ");
            string ItemToCheckOut = Validation.GetValidString();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string TitleUpper = item.BTitle.ToUpper();

                if (TitleUpper == ItemToCheckOut && !(item.BStatus == "Checked-out"))
                {

                    item.BStatus = "Book is Checked-out";
                    item.BDueDate = myDateTime.AddDays(14).ToShortDateString();
                    Console.WriteLine($"{item.BTitle} is checked out.");
                    Console.WriteLine($"and is Due Back On {item.BDueDate}");
                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {

                Console.WriteLine("Book is Not Available");
            }

            WriteToText(inputCatalogue);
        }



        // This Method Returns a Book and Updates the Text File
        public static void Return(List<Books> inputCatalogue)
        {
            Console.Write("Please Enter The Name Of The Book You Would Like To Return: ");
            string ItemToReturn = Console.ReadLine().ToUpper();
            DateTime myDateTime = new DateTime();
            myDateTime = DateTime.Now;
            int count = 0;
            foreach (var item in inputCatalogue)
            {
                string TitleUpper = item.BTitle.ToUpper();
                if (TitleUpper == ItemToReturn && !(item.BStatus == "Avaiable"))
                {
                    item.BStatus = "Available";
                    item.BDueDate = "N/A";
                    Console.WriteLine($"Thank You for Returning {item.BTitle}.");
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
                Console.WriteLine("That Book is Already Returned or Not in Our System.");
            }
            WriteToText(inputCatalogue);
        }




        // This Method Writes Over the Text File - It is Called in the Return and Checkout Methods
        public static void WriteToText(List<Books> inputList)
        {
            StreamWriter sw = new StreamWriter("../../OurDataBase.txt", false);
            foreach (var item in inputList)
            {
                sw.WriteLine(item.BTitle + "," + item.BAuthor + "," + item.BStatus + ","
                    + item.BDueDate);
            }
            sw.Close();
        }




        // Method to Search By Title
        public static void SearchbyKeyWord(List<Books> inputCatalogue)
        {
            Console.WriteLine("Enter a Keyword to Search for a Book By Title: ");
            int count = 0;
            char[] space = { ' ' };
            string KeyWordSearch = Console.ReadLine().ToUpper();

            foreach (var item in inputCatalogue)
            {
                string titleToUpper = item.BTitle.ToUpper();
                if (titleToUpper.Split(space).Contains(KeyWordSearch))
                {
                    Console.WriteLine("Yes We Have: ");

                    Console.WriteLine("Title:\t" + item.BTitle);
                    Console.WriteLine("Author:\t" + item.BAuthor);
                    Console.WriteLine("Status:\t" + item.BStatus);
                    Console.WriteLine("DueDate:\t" + item.BDueDate);
                    Console.WriteLine("\n=====================================\n");
                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("That Does Not Match Anything in Our Records");
            }
        }



        //// Search for Book by Author
        public static void SearchByAuthor(List<Books> inputCatalogue)
        {
            Console.WriteLine("Enter a Keyword to Search for a Book By Author: ");
            int count = 0;
            char[] space = { ' ' };
            string KeyWordSearch = Console.ReadLine().ToUpper();

            foreach (var item in inputCatalogue)
            {
                string authorToUpper = item.BAuthor.ToUpper();
                if (authorToUpper.Split(space).Contains(KeyWordSearch))
                {
                    Console.WriteLine("Yes We Have: ");

                    Console.WriteLine("Title:\t" + item.BTitle);
                    Console.WriteLine("Author:\t" + item.BAuthor);
                    Console.WriteLine("Status:\t" + item.BStatus);
                    Console.WriteLine("DueDate:\t" + item.BDueDate);
                    Console.WriteLine("\n=====================================\n");
                }

                else
                {
                    count++;
                }
            }

            if (count == inputCatalogue.Count)
            {
                Console.WriteLine("That Does Not Match Anything in Our Records");
            }
        }



        //public static void SearchByAuthor(List<Books> inputCatalogue)
        //{
        //    Console.Write("Please Type in The Author of The Book You Are Looking For:\n---->  ");
        //    string AuthorSearch = Console.ReadLine().ToUpper();

        //    int count = 0;
        //    foreach (var item in inputCatalogue)
        //    {
        //        string TitleUpper = item.BAuthor.ToUpper();

        //        if (TitleUpper == AuthorSearch)
        //        {
        //            Console.WriteLine("Yes we have: ");
        //            Console.WriteLine("Title:\t" + item.BTitle);
        //            Console.WriteLine("Author:\t" + item.BAuthor);
        //            Console.WriteLine("Status:\t" + item.BStatus);
        //            Console.WriteLine("DueDate:\t" + item.BDueDate);
        //            Console.WriteLine("\n=====================================\n");
        //        }

        //        else
        //        {
        //            count++;
        //        }
        //    }

        //    if (count == inputCatalogue.Count)
        //    {

        //        Console.WriteLine("We Do Not Have That Title.");
        //    }
        //    WriteToText(inputCatalogue);
        //}



        // Method to Add Book/Donate Option
        public static List<Books> AddBooks(List<Books> inputList)
        {

            string ChoiceTitle;
            string ChoiceAuthor;
            Console.WriteLine("Please Enter in The Information For The Book You Are Donating:\n");
            Console.Write("Book Title: ");
            ChoiceTitle = Validation.GetValidString();
            Console.Write("Book Author: ");
            ChoiceAuthor = Validation.GetValidString();
            string Status = "Available";
            string DueDate = "N/A";

            inputList.Add(new Books(ChoiceTitle, ChoiceAuthor, Status, DueDate));
            Console.WriteLine("Thank You For Donating " + ChoiceTitle + " By " + ChoiceAuthor);

            return inputList;

        }
    }
}