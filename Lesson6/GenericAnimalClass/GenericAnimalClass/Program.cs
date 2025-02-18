using System;

public class Animal<T>
{
    public T data;

    public Animal(T data)
    {
        this.data = data;
    }

    public T getAnimal()
    {
        return data;
    }
}

class Program
{
    static void Main()
    {
        Animal<string> animalName = new Animal<string>("Bengal Tiger");
        Animal<string> animalHabitat = new Animal<string>("Tropical and subtropical Asian forests");
        Animal<bool> endangered = new Animal<bool>(true);
        Animal<bool> extinct = new Animal<bool>(false);
        Animal<int> averageLifespan = new Animal<int>(20);

        Console.WriteLine("Animal Information:");
        Console.WriteLine($"Name: {animalName.getAnimal()}");
        Console.WriteLine($"Habitat: {animalHabitat.getAnimal()}");
        Console.WriteLine($"Endangered: {endangered.getAnimal()}");
        Console.WriteLine($"Extinct: {extinct.getAnimal()}");
        Console.WriteLine($"Average Lifespan: {averageLifespan.getAnimal()} years");
    }
}
