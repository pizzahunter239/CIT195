using System;

abstract class Animal
{
    //Property
    public abstract string Name { get; set; }
    //Methods
    public abstract string Describe();
    public string WhatAmI()
    {
        return "I am an animal";
    }
}

class Dog : Animal
{
    public override string Name { get; set; }
    public string Breed { get; set; }
    public int Age { get; set; }

    public Dog()
    {
        Name = "Rufus";
        Breed = "Golden Retriever";
        Age = 2;
    }

    public Dog(string name, string breed, int age)
    {
        Name = name;
        Breed = breed;
        Age = age;
    }

    public override string Describe()
    {
        return $"Name: {Name}\nBreed: {Breed}\nAge: {Age}\n";
    }
}

class Program
{
    static void Main()
    {
        Dog defaultDog = new Dog();
        Dog paraDog = new Dog("Buddy", "Australian Shepard", 3);

        Console.WriteLine(defaultDog.WhatAmI());
        Console.WriteLine(defaultDog.Describe());

        Console.WriteLine(paraDog.WhatAmI());
        Console.WriteLine(paraDog.Describe());
    }
}
