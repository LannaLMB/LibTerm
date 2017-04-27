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
            // Change Console Color
            Console.ForegroundColor = ConsoleColor.DarkBlue;


            // Welcome Message
            Console.WriteLine("Welcome to the Grand Library!\n");



            // Declare Variables





            // Call Get Option Method to Show Menu and Get User Input
            GetOption();




        }





        // **********  Methods Begin Here  ********** \\

        public static int GetOption()
        {
            int Option;
            // User Chooses to Check In a Book, Check Out a Book, Donate a Book, or Search for a Book
            Console.WriteLine("What Can We Help You With Today at The Grand Library?\n");
            Console.Write("\t1.)\tCheck-Out a Book\n\t2.)\tReturn a Book\n\t3.)\tSearch for a Book by Title\n\t4.)\tSearch for a Book by Author\n\nPlease Type the Number Associated With The Option You'd Like\n   ----->  ");
            Option = Validation.GetRange(1, 4);
            return Option;
        }
    }
}
