﻿/*  Midterm Project
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


            // Start of Menu
            Console.WriteLine("\nWhat Can We Help You With Today at The Grand Library?\n\n");


            // Start of Continue Loop
            while (true)
            {
                // Call Get Option Method to Show Menu and Get User Input
                GetOption();
                GetInfo();



                // Continue Loop
                if (!Validation.GetContinue())
                {

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
            Console.WriteLine($"You Chose The Option To {MenuValues[Option - 1]}.");
            Console.WriteLine("-----------------------------------------------------------------------------\n");
            //Console.WriteLine(GetInfo());
        }



        // Method to Allow User to Go Forward With Their Choice
        public static void GetInfo()
        {
            int Option = 1;
            string Choice = "";

            if (Option == 1)
            {

                // Print List of Books Here
                Console.WriteLine("Please Select a Book to Check Out From the List Above:\n");
                Choice = Validation.GetValidString(Console.ReadLine().ToUpper());
            }

            else if (Option == 2)
            {

                Console.WriteLine("Please Type in The Title of The Book You Are Returning:\n");
                Choice = Validation.GetValidString(Console.ReadLine().ToUpper());
                Console.WriteLine("Thank You For Returning " + Choice);
            }

            else if (Option == 3)
            {

                Console.WriteLine("Please Type in The Name of The Book You Are Looking For:\n");
                Choice = Validation.GetValidString(Console.ReadLine().ToUpper());
            }

            else if (Option == 4)
            {

                Console.WriteLine("Please Type in The Author of The Book You Are Looking For:\n");
                Choice = Validation.GetValidString(Console.ReadLine().ToUpper());
            }

            else if (Option == 5)
            {

                Console.WriteLine("Please Enter in The Information For The Book You Are Donating:\n");
                Choice = Validation.GetValidString(Console.ReadLine().ToUpper());
            }

            //return Choice;
        }



        // Method to Get Book Status
        public static StatusValues GetBookStatus()
        {

            int choice = 0;

            StatusValues UserChoice = StatusValues.Available;

            switch (choice)
            {
                case 1:
                    UserChoice = StatusValues.Available;
                    break;

                case 2:
                    UserChoice = StatusValues.CheckedOut;
                    break;
            }

            return UserChoice;
        }
    }
}

