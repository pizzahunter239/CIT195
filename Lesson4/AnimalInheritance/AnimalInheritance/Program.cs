using System;

namespace AnimalInheritance
{
    class Animal
    {
        private string name;
        protected string type;
        public string color;

        public void setName(string name)
        {
            this.name = name;
        }
        public virtual string getName()
        {
            return this.name;
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public virtual string getType()
        {
            return this.type;
        }
    }

    class Horse : Animal
    {
        public string breed;
        protected int height;
        private int weight;

        public void setHeight(int height)
        {
            this.height = height;
        }
        public int getHeight()
        {
            return height;
        }
        public void setWeight(int weight)
        {
            this.weight = weight;
        }
        public int getWeight()
        {
            return weight;
        }

        public override string getName()
        {
            return base.getName();
        }

        public override string getType()
        {
            return type;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Animal critter = new Animal();
            critter.setName("Sparky");
            critter.setType("Dog");
            critter.color = "White";

            Console.WriteLine("Animal Information");
            Console.WriteLine($"Name= {critter.getName()}");
            Console.WriteLine($"Type= {critter.getType()}");
            Console.WriteLine($"Color= {critter.color}\n");

            Horse myHorse = new Horse();
            myHorse.setName("Sam");
            myHorse.setType("Horse");
            myHorse.color = "Black";
            myHorse.breed = "Stallion";
            myHorse.setHeight(7);
            myHorse.setWeight(1500);

            Console.WriteLine("Horse Information");
            Console.WriteLine($"Name= {myHorse.getName()}");
            Console.WriteLine($"Type= {myHorse.getType()}");
            Console.WriteLine($"Color= {myHorse.color}");
            Console.WriteLine($"Breed = {myHorse.breed}");
            Console.WriteLine($"Height= {myHorse.getHeight()} Hands");
            Console.WriteLine($"Weight= {myHorse.getWeight()}");

            Console.ReadLine();
        }
    }
}
