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


            // List of Books
            List<Books> BookList = new List<Books>();

            // read the whole text file 

            // split into lines 

            // split each line into columns 

            // putb the column info into an abject of type book 

            // put the book into ur list 

            //BookList.Add(new Books("Harry Potter and the Curse", "J.K.Rowling", "Available"));
            //BookList.Add(new Books("Red Rain", "R.L.Stine", "Available"));
            //BookList.Add(new Books("Sixteenth Seduction", "James Patterson", "Available"));
            //BookList.Add(new Books("Thirteen Reasons Why", "Jay Asher", "Available"));
            //BookList.Add(new Books("The Third Wave", "Steve Case", "Available"));
            //BookList.Add(new Books("Cat and the Hat", "Dr. Seuss", "Available"));
            //BookList.Add(new Books("Green Eggs and Ham", "Dr. Seuss", "Available"));
            //BookList.Add(new Books("How the Grinch Stole Christmas", "Dr. Seuss", "Available"));
            //BookList.Add(new Books("Anything is Possible", "Elizabeth Strout", "Available"));
            //BookList.Add(new Books("The Secrets of My Life", "Caitlyn Jenner", "Available"));
            //BookList.Add(new Books("The Black Book", "James Patterson", "Available"));
            //BookList.Add(new Books("Hundred Years of Solitude", "Gabiel Garcia Marquez", "Available"));
            //BookList.Add(new Books("Gone Girl", "Gillian Flynn", "Available"));

            Console.Write(BookList);




            // Call Get Option Method to Show Menu and Get User Input
            GetOptionNum();
            int UserChoice = GetOptionNum();

            Console.Write($"You Chose " + UserChoice);
        }

        




        // **********  Methods Begin Here  ********** \\


        // Method to Get User Option of What They Would Like to Do Within The Menu
        public static int GetOptionNum()
        {

            int Option;
            // User Chooses to Check In a Book, Check Out a Book, Donate a Book, or Search for a Book
            Console.WriteLine("What Can We Help You With Today at The Grand Library?\n");
            Console.Write("\n\t1.)\tCheck-Out a Book\n\t2.)\tReturn a Book\n\t3.)\tSearch for a Book by Title\n\t4.)\tSearch for a Book by Author\n\t5.)\tDonate A Book\n\n\nPlease Type the Number Associated With The Option You'd Like\n\n   ----->  ");
            Option = Validation.GetRange(1, 5);
            return Option;
        }


        public static string GetOptionString()
        {

            string MenuValue = "";
            int Option = 0;

            if (Option == 1)
            {
                MenuValue = "You Chose The Option To Check-Out A Book.";
            }

            else if (Option == 2)
            {
                MenuValue = "You Chose The Option To Return A Book.";
            }

            else if (Option == 3)
            {
                MenuValue = "You Chose The Option To Search For A Book By Title.";
            }

            else if (Option == 4)
            {
                MenuValue = "You Chose The Option To Search For A Book By Author.";
            }

            else if (Option == 5)
            {
                MenuValue = "You Chose The Option To Donate A Book.";
            }

            return MenuValue;
        }

            //int choice = 0;
            //string UserChoice = "";

            //switch (choice)
            //{
            //    case 1:
            //        GetOptionNum() = 1;
            //        Console.Write("You Chose The Option To Check-Out A Book.");
            //        break;

            //    case 2:
            //        UserChoice = 2;
            //        Console.Write("You Chose The Option To Return A Book.");
            //        break;

            //    case 3:
            //        UserChoice = 3;
            //        Console.Write("You Chose The Option To Search For A Book By Title.");
            //        break;

            //    case 4:
            //        UserChoice = 4;
            //        Console.Write("You Chose The Option To Search For A Book By Author.");
            //        break;

            //    case 5:
            //        UserChoice = 5;
            //        Console.Write("You Chose The Option To Donate A Book.");
            //        break;
        //    }

        //    return choice;
        //}



        //// Method to Gte Book Status
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

