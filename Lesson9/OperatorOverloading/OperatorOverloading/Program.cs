namespace OperatorOverloadingEx1
{
    public class Calculator
    {
        public int number { get; set; }

        // Overload unary operators ++ and -- 
        public static Calculator operator ++(Calculator c)
        {
            c.number++;
            return c;
        }

        public static Calculator operator --(Calculator c)
        {
            c.number--;
            return c;
        }

        // Overload Comparison Operators > and <
        public static bool operator >(Calculator c1, Calculator c2)
        {
            return c1.number > c2.number;
        }

        public static bool operator <(Calculator c1, Calculator c2)
        {
            return c1.number < c2.number;
        }

        // Overload Binary Operators + and -
        public static Calculator operator +(Calculator c1, Calculator c2)
        {
            Calculator result = new Calculator();
            result.number = c1.number + c2.number;
            return result;
        }

        public static Calculator operator -(Calculator c1, Calculator c2)
        {
            Calculator result = new Calculator();
            result.number = c1.number - c2.number;
            return result;
        }

        static void Main(string[] args)
        {
            Random r = new Random();
            // create object array
            Calculator[] numbers = new Calculator[10];
            // place random numbers into array and print values
            Console.Write("Original Numbers= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = new Calculator(); // creates the object
                numbers[i].number = r.Next(1, 100);  // places a value in the object
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();
            // if divisible by 2, add 1 to value using operator ++ method
            // otherwise subtract 1 from value using operator -- method
            Console.Write("New Numbers +1 or -1= ");
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].number % 2 == 0)
                {
                    // Code goes here to increment numbers[i] by 1
                    numbers[i]++;
                }
                else
                {
                    // Code goes here to decrement numbers[i] by 1
                    numbers[i]--;
                }
                Console.Write(" " + numbers[i].number);
            }
            Console.WriteLine();
            // random Calculator object to add
            Calculator numToAdd = new Calculator();
            numToAdd.number = r.Next(1, 20);
            // Using operator +, add numToAdd.number to each element in the array
            // Print the results
            Console.Write($"Numbers + {numToAdd.number} = ");
            // Insert a for loop that adds numToAdd to numbers[i]
            for (int i = 0; i < numbers.Length; i++)
            {
                Calculator result = numbers[i] + numToAdd;
                Console.Write(" " + result.number);
            }
            Console.WriteLine();
            // random Calculator object to subtract
            Calculator numToSub = new Calculator();
            numToSub.number = r.Next(1, 20);
            // Using operator -, subtract numToSub.number from each element in the array
            // Print the results
            Console.Write($"Numbers - {numToSub.number}= ");
            // Insert a for loop that subtracts numToSub from numbers[i]
            for (int i = 0; i < numbers.Length; i++)
            {
                Calculator result = numbers[i] - numToSub;
                Console.Write(" " + result.number);
            }
            Console.WriteLine();
            // random Calculator object for comparison
            Calculator numToCompare = new Calculator();
            numToCompare.number = r.Next(1, 100);
            // Using operator > and operator <, compare each element to numToCompare.number
            // print if the element is higher, lower or equal to the number you are comparing to
            Console.WriteLine($"Numbers above or below {numToCompare.number}");
            // Insert a for loop
            for (int i = 0; i < numbers.Length; i++)
            {
                // Inside the for loop insert a nested if/else that checks numbers[i] > numberToCompare
                if (numbers[i] > numToCompare)
                {
                    // followed by a message that the number is higher
                    Console.WriteLine($"{numbers[i].number} is higher.");
                }
                // Then it should check numbers[i] < numToCompare
                else if (numbers[i] < numToCompare)
                {
                    // followed by a message that the number is lower
                    Console.WriteLine($"{numbers[i].number} is lower.");
                }
                else
                {
                    // if the number isn't higher or lower, the message should indicate they are equal
                    Console.WriteLine($"{numbers[i].number} is equal.");
                }
            }
        }
    }
}