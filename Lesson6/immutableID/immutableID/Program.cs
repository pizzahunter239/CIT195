using System;
namespace immutableID
{
    class Program
    {
        class Student
        {
            public int Id { get; init; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public Student()
            {
                Id = 0;
                FirstName = "";
                LastName = "";
            }

            public Student(int i, string First, string Last)
            {
                Id = i;
                FirstName = First;
                LastName = Last;
            }

            public Student(int i)
            {
                Id = i;
                FirstName = "";
                LastName = "";
            }
        }

        public static void Main()
        {
            Student student1 = new Student(1);
            student1.FirstName = "John";
            student1.LastName = "Doe";

            Student student2 = new Student(2, "Jane", "Smith");

            Console.WriteLine($"Student 1: ID = {student1.Id}, Name = {student1.FirstName} {student1.LastName}");
            Console.WriteLine($"Student 2: ID = {student2.Id}, Name = {student2.FirstName} {student2.LastName}");
        }
    }
}
