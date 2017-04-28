/*  Midterm Project
 *  Library Terminal
 *  Group:  Lanna, Alex, Theresa
 *  Date Last Modified:  4/28/17
 */


// ****** TO DO:
// read the whole text file 

// split into lines 

// split each line into columns 

// putb the column info into an abject of type book 

// put the book into ur list 

using System;
using System.Collections.Generic;
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


            // Declare Variables



            // Call Get Option Method to Show Menu and Get User Input
            GetOption();


        }

        




        // **********  Methods Begin Here  ********** \\


        // Method to Get User Option of What They Would Like to Do Within The Menu
        public static int GetOption()
        {

            int Option;

            // User Chooses to Check In a Book, Check Out a Book, Donate a Book, or Search for a Book
            Console.WriteLine("What Can We Help You With Today at The Grand Library?\n");
            string[] MenuValues = { "Check-Out a Book", "Return a Book", "Search for a Book by Title", "Search for a Book by Author", "Donate a Book" };
            
            // Print List of Menu Values with Select Numbers
            for (int i = 0; i < MenuValues.Length; i++)
            {

                Console.WriteLine($"{i + 1}.)\t{MenuValues[i]}");
            }

            Console.Write("\nPlease Type the Number Associated With The Option You'd Like\n\n   ----->  ");



            // Genre Choice Output
            Option = Validation.GetRange(1, 5);
            Console.WriteLine();
            Console.WriteLine($"You Chose The Option To {MenuValues[Option - 1]}.");
            Console.WriteLine("-----------------------------------------------------------------------------\n");

            return Option;
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

