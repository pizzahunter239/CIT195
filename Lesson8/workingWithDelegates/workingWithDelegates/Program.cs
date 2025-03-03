namespace Assignment8ex2
{
    public class MathSolutions
    {
        public delegate double SumDelegate(double x, double y);
        public double GetSum(double x, double y)
        {
            return x + y;
        }
        public double GetProduct(double a, double b)
        {
            return a * b;
        }
        public void GetSmaller(double a, double b)
        {
            if (a < b)
                Console.WriteLine($" {a} is smaller than {b}");
            else if (b < a)
                Console.WriteLine($" {b} is smaller than {a}");
            else
                Console.WriteLine($" {b} is equal to {a}");
        }
        static void Main(string[] args)
        {
            // create a class object
            MathSolutions answer = new MathSolutions();
            Random r = new Random();
            double num1 = Math.Round(r.NextDouble() * 100);
            double num2 = Math.Round(r.NextDouble() * 100);
            Console.WriteLine("Original Method Calls");
            Console.WriteLine($" {num1} + {num2} = {answer.GetSum(num1, num2)}");
            Console.WriteLine($" {num1} * {num2} = {answer.GetProduct(num1, num2)}");
            answer.GetSmaller(num1, num2);

            Console.WriteLine("\nUsing Delegates");
            SumDelegate sumDelegate = answer.GetSum;
            double sumResult = sumDelegate(num1, num2);
            Console.WriteLine($"{num1} + {num2} = {sumResult}");

            Func<double, double, double> productFunc = answer.GetProduct;
            double productResult = productFunc(num1, num2);
            Console.WriteLine($"{num1} * {num2} = {productResult}");

            Action<double, double> smallerAction = answer.GetSmaller;
            smallerAction(num1, num2);

            Console.WriteLine("\nUsing anonymous methods:");

            Func<double, double, double> anonymousProduct = (a, b) => a * b;
            Console.WriteLine($"{num1} * {num2} = {anonymousProduct(num1, num2)}");

            Action<double, double> anonymousSmaller = (a, b) => {
                if (a < b)
                    Console.WriteLine($" {a} is smaller than {b}");
                else if (b < a)
                    Console.WriteLine($" {b} is smaller than {a}");
                else
                    Console.WriteLine($" {b} is equal to {a}");
            };
            anonymousSmaller(num1, num2);
        }
    }
}