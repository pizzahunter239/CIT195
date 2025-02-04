using System;

namespace SimpleInheritance
{
    class Animal
    {
        public string name;

        public Animal()
        {
            name = "";
        }

        public Animal(string name)
        {
            this.name = name;
        }

        public void display()
        {
            Console.WriteLine($"I am an animal, my name is {name}\n");
        }
    }

    class Giraffe : Animal
    {
        public string color;
        public double height;
        public int weight;

        public Giraffe() : base()
        {
            color = "";
            height = 0;
            weight = 0;
        }

        public Giraffe(string name, string color, double height, int weight) : base(name)
        {
            this.color = color;
            this.height = height;
            this.weight = weight;
        }

        public void displayGiraffeInfo()
        {
            Console.WriteLine("Giraffe Information...");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Height: {height}");
            Console.WriteLine($"Weight: {weight}\n");
        }
    }

    class Kangaroo : Animal
    {
        public int age;
        public double height;
        public int weight;

        public Kangaroo() : base()
        {
            age = 0;
            height = 0;
            weight = 0;
        }

        public Kangaroo(string name, int age, double height, int weight) : base(name)
        {
            this.age = age;
            this.height = height;
            this.weight = weight;
        }

        public void displayKangarooInfo()
        {
            Console.WriteLine("Kangaroo Information...");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Height: {height}");
            Console.WriteLine($"Weight: {weight}\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal myPet = new Animal("Sparky");
            myPet.display();

            Giraffe myGiraffe1 = new Giraffe();
            myGiraffe1.name = "Gerald the Giraffe";
            myGiraffe1.color = "Golden Brown";
            myGiraffe1.height = 18;
            myGiraffe1.weight = 2600;
            myGiraffe1.displayGiraffeInfo();

            Kangaroo myKangaroo1 = new Kangaroo();
            myKangaroo1.name = "Kevin the Kangaroo";
            myKangaroo1.age = 8;
            myKangaroo1.height = 5.5;
            myKangaroo1.weight = 200;
            myKangaroo1.displayKangarooInfo();

            Giraffe myGiraffe2 = new Giraffe("Gina the Giraffe", "Spotted Yellow", 16.5, 2400);
            myGiraffe2.displayGiraffeInfo();

            Kangaroo myKangaroo2 = new Kangaroo("Kylie the Kangaroo", 6, 5.2, 180);
            myKangaroo2.displayKangarooInfo();
        }
    }
}
