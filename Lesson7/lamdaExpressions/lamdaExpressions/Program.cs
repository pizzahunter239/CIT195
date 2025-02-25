using System;

namespace lambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda Expressions");

            Console.Write("Enter the first number: ");
            
            double num1;
            while (!double.TryParse(Console.ReadLine(), out num1))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            Console.Write("Enter the second number: ");
            
            double num2;
            while (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.Write("Invalid input. Please enter a number: ");
            }

            // Addition
            Func<double, double, double> add = (x, y) => x + y;

            // Multiplication
            Func<double, double, double> multiply = (x, y) => x * y;

            // Find Smaller
            Func<double, double, double> findSmaller = (x, y) =>
            {
                if (x < y)
                    return x;
                else
                    return y;
            };

            Console.WriteLine("\nResults:");
            Console.WriteLine($"Addition: {num1} + {num2} = {add(num1, num2)}");
            Console.WriteLine($"Multiplication: {num1} * {num2} = {multiply(num1, num2)}");
            Console.WriteLine($"Smaller value between {num1} and {num2} is {findSmaller(num1, num2)}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}