using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        IList<FamousPeople> stemPeople = new List<FamousPeople>()
        {
            new FamousPeople() { Name = "Michael Faraday", BirthYear = 1791, DeathYear = 1867 },
            new FamousPeople() { Name = "James Clerk Maxwell", BirthYear = 1831, DeathYear = 1879 },
            new FamousPeople() { Name = "Marie Skłodowska Curie", BirthYear = 1867, DeathYear = 1934 },
            new FamousPeople() { Name = "Katherine Johnson", BirthYear = 1918, DeathYear = 2020 },
            new FamousPeople() { Name = "Jane C. Wright", BirthYear = 1919, DeathYear = 2013 },
            new FamousPeople() { Name = "Tu YouYou", BirthYear = 1930 },
            new FamousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear = 1947 },
            new FamousPeople() { Name = "Lydia Villa-Komaroff", BirthYear = 1947 },
            new FamousPeople() { Name = "Mae C. Jemison", BirthYear = 1956 },
            new FamousPeople() { Name = "Stephen Hawking", BirthYear = 1942, DeathYear = 2018 },
            new FamousPeople() { Name = "Tim Berners-Lee", BirthYear = 1955 },
            new FamousPeople() { Name = "Terence Tao", BirthYear = 1975 },
            new FamousPeople() { Name = "Florence Nightingale", BirthYear = 1820, DeathYear = 1910 },
            new FamousPeople() { Name = "George Washington Carver", DeathYear = 1943 },
            new FamousPeople() { Name = "Frances Allen", BirthYear = 1932, DeathYear = 2020 },
            new FamousPeople() { Name = "Bill Gates", BirthYear = 1955 }
        };

        //Birthdates after 1900
        Console.WriteLine("Birthdates after 1900:");
        var query1 = from person in stemPeople
                     where person.BirthYear > 1900
                     select person;
        foreach (var person in query1)
        { 
            Console.WriteLine($"{person.Name} - Born: {person.BirthYear}");
        }
        Console.WriteLine();

        //Two lowercase L's
        Console.WriteLine("Two lowercase L's in their name");
        var query2 = from person in stemPeople
                     where person.Name.ToLower().Count(c => c == 'l') >= 2
                     select person;
        foreach (var person in query2)
        {
            Console.WriteLine($"{person.Name}");
        }
        Console.WriteLine();

        //Birthdates after 1950
        Console.WriteLine("Number of people with birthdays after 1950:");
        var query3 = from person in stemPeople
                     where person.BirthYear > 1950
                     select person;
        int birthCount1950 = query3.Count();
        Console.WriteLine($"{birthCount1950}");
        Console.WriteLine();

        //Birth years between 1920 and 2000
        Console.WriteLine("People with birth years between 1920 and 2000:");
        var query4 = from person in stemPeople
                     where person.BirthYear >= 1920
                     where person.BirthYear <= 2000
                     select person;
        foreach (var person in query4)
        {
            Console.WriteLine($"{person.Name} Born: {person.BirthYear}");
        }

        var birthCount = query4.Count();
        Console.WriteLine($"Count: {birthCount}");
        Console.WriteLine();

        //Sort by Birth Year
        Console.WriteLine("Sorted by birth year:");
        var query5 = from person in stemPeople
                     where person.BirthYear != null
                     orderby person.BirthYear
                     select person;
        foreach (var person in query5)
        {
            Console.WriteLine($"{person.Name} Born: {person.BirthYear}");
        }
        Console.WriteLine();

        //Death year after 1960 before 2015
        Console.WriteLine("Peopel who died between 1960 and 2015");
        var query6 = from person in stemPeople
                     where person.DeathYear > 1960
                     where person.DeathYear < 2015
                     orderby person.Name
                     select person;
        foreach(var person in query6)
        {
            Console.WriteLine($"{person.Name} Died: {person.DeathYear}");
        }

    }
}

class FamousPeople
{
    public string Name { get; set; }
    public int? BirthYear { get; set; } = null;
    public int? DeathYear { get; set; } = null;
}
