using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Validation
    {

        public static int GetValidInt()
        {
       
            int number;

            // Validate Input
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine();

                // Number Validation with Colors
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.Write("You Must Select A Valid Number From The Menu:  --->   ");
                Console.ForegroundColor = ConsoleColor.Green;

            }
            return number;
        }


        // Method to Get Input and Validate That Number is Between 0 and 4.
        public static int GetRange(int min, int max)
        {

            // Get a Valid Int from Previous Method
            int number = GetValidInt();

            while (number < min || number > max)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"You MUST Enter a Number That is in Between {min} and {max}  --->   ");
                Console.ForegroundColor = ConsoleColor.Green;
                number = GetValidInt();
            }
            return number;

        }
    }
}
