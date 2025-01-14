using System;
namespace NoException
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            char more;
            do
            {
                try
                {
                    Console.WriteLine("Enter a number:");
                    int number = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter another number to divide by");
                    int divisor = int.Parse(Console.ReadLine());

                    int result = number / divisor;
                    Console.WriteLine($"The result of division is: {result}");
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input must be a valid number. Please try again.");
                    Console.WriteLine($"Error details: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot divide by zero. Please enter a non-zero divisor");
                    Console.WriteLine($"Error details: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("An unexpected error occured.");
                    Console.WriteLine($"Error details: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                finally
                {
                    Console.WriteLine("DO you want to try again? (Y for yes, any key for no)");
                    while (!char.TryParse(Console.ReadLine(), out more)) ;
                    {
                        Console.WriteLine("Please enter a valid character, try again...");
                    }
                    if (Char.ToLower(more) != 'y')
                        again = false;
                }


            } while (again);
        }
    }
}