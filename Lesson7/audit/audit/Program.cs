using System;

namespace Audit
{
    class Auditor
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    class Business
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public Auditor Auditor { get; set; }

        public void Display()
        {
            Console.WriteLine("\nBusiness Information");
            Console.WriteLine("--------------------");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Address: " + Address);

            Console.WriteLine("\nAssigned Auditor Information");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Name: " + Auditor.Name);
            Console.WriteLine("Phone Number: " + Auditor.PhoneNumber);
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Business Audit Containment Example");

            Auditor auditor = new Auditor
            {
                Name = "John Doe",
                PhoneNumber = "123-456-7890"
            };

            Business business = new Business
            {
                Name = "Corporation Inc.",
                Type = "Software Development",
                Address = "123 Developer Drive, Cleveland, OH 12345",
                Auditor = auditor
            };

            business.Display();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}