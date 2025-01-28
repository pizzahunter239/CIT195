using System;

class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();

        Console.Write("Enter the number of random integers to generate: ");
        int count = int.Parse(Console.ReadLine());

        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            numbers[i] = r.Next(1, 11);
        }

        int total = Add(numbers);
        int product = Multiply(numbers);

        Console.WriteLine("Random numbers:");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        Console.WriteLine($"Total of the numbers array = {total}");
        Console.WriteLine($"Product of the numbers array = {product}");
    }

    static int Add(params int[] numbers)
    {
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        return total;
    }

    static int Multiply(params int[] numbers)
    {
        int total = 1;
        foreach (int number in numbers)
        {
            total *= number;
        }
        return total;
    }
}
