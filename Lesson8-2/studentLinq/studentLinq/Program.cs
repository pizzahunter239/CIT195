using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "Frank Furter", Age = 55, Major="Hospitality", Tuition=3500.00} ,
            new Student() { StudentID = 2, StudentName = "Gina Host", Age = 21, Major="Hospitality", Tuition=4500.00 } ,
            new Student() { StudentID = 3, StudentName = "Cookie Crumb",  Age = 21, Major="CIT", Tuition=2500.00 } ,
            new Student() { StudentID = 4, StudentName = "Ima Script",  Age = 48, Major="CIT", Tuition=5500.00 } ,
            new Student() { StudentID = 5, StudentName = "Cora Coder",  Age = 35, Major="CIT", Tuition=1500.00 } ,
            new Student() { StudentID = 6, StudentName = "Ura Goodchild" , Age = 40, Major="Marketing", Tuition=500.00} ,
            new Student() { StudentID = 7, StudentName = "Take Mewith" , Age = 29, Major="Aerospace Engineering", Tuition=5500.00 }
        };

        // Student GPA Collection
        IList<StudentGPA> studentGPAList = new List<StudentGPA>() {
            new StudentGPA() { StudentID = 1,  GPA=4.0} ,
            new StudentGPA() { StudentID = 2,  GPA=3.5} ,
            new StudentGPA() { StudentID = 3,  GPA=2.0 } ,
            new StudentGPA() { StudentID = 4,  GPA=1.5 } ,
            new StudentGPA() { StudentID = 5,  GPA=4.0 } ,
            new StudentGPA() { StudentID = 6,  GPA=2.5} ,
            new StudentGPA() { StudentID = 7,  GPA=1.0 }
        };

        // Club collection
        IList<StudentClubs> studentClubList = new List<StudentClubs>() {
            new StudentClubs() {StudentID=1, ClubName="Photography" },
            new StudentClubs() {StudentID=1, ClubName="Game" },
            new StudentClubs() {StudentID=2, ClubName="Game" },
            new StudentClubs() {StudentID=5, ClubName="Photography" },
            new StudentClubs() {StudentID=6, ClubName="Game" },
            new StudentClubs() {StudentID=7, ClubName="Photography" },
            new StudentClubs() {StudentID=3, ClubName="PTK" },
        };

        //Group by GPA and show ID
        Console.WriteLine("a) Students grouped by GPA:");
        var query1 = studentGPAList.GroupBy(s => s.GPA);

        foreach (var gpaGroup in query1)
        {
            Console.WriteLine($"GPA: {gpaGroup.Key}");
            Console.WriteLine("Student IDs: " + string.Join(", ", gpaGroup.Select(s => s.StudentID)));
            Console.WriteLine();
        }
        Console.WriteLine();

        //Sort by Club then group by club and display ID
        Console.WriteLine("Students sorted and grouped by club: ");
        var query2 = studentClubList.OrderBy(c => c.ClubName).GroupBy(c => c.ClubName);

        foreach (var clubGroup in query2)
        {
            Console.WriteLine($"Club: {clubGroup.Key}");
            Console.WriteLine("Student IDs: " + string.Join(", ", clubGroup.Select(s => s.StudentID)));
            Console.WriteLine();
        }
        Console.WriteLine();

        //Number of students with GPA between 2.5 and 4
        var query3 = studentGPAList.Count(s => s.GPA >= 2.5 && s.GPA <= 4.0);
        Console.WriteLine($"Number of students with a GPA between 2.5 and 4.0: {query3}");
        Console.WriteLine();

        //Average tuition
        var query4 = studentList.Average(s => s.Tuition);
        Console.WriteLine($"Average tuition: ${query4:F2}");
        Console.WriteLine();

        //Highest tuition display name, major, and tuition
        Console.WriteLine("Student paying the highest tuition:");
        var query5 = studentList.Max(s => s.Tuition);
        foreach (var student in studentList)
        {
            if (student.Tuition == query5)
            {
                Console.WriteLine($"Name: {student.StudentName}, Major: {student.Major}, Tuition: ${student.Tuition:F2}");
            }
        }
        Console.WriteLine();

        //Join student list and student GPA list on student ID and display the student's name, major, and GPA
        Console.WriteLine("Students with their GPA:");
        var query6 = studentList.Join(
            studentGPAList,
            student => student.StudentID,
            gpa => gpa.StudentID,
            (student, gpa) => new
            {
                student.StudentName,
                student.Major,
                gpa.GPA
            }
            );

        foreach (var studentGpa in query6)
        {
            Console.WriteLine($"Name: {studentGpa.StudentName}, Major: {studentGpa.Major}, GPA: {studentGpa.GPA}");
        }
        Console.WriteLine();

        //Join the student list and student club list. Display names of students in game club
        Console.WriteLine("g) Students in the Game club:");
        var query7 = studentList.Join(
            studentClubList.Where(c => c.ClubName == "Game"),
            student => student.StudentID,
            club => club.StudentID,
            (student, club) => student.StudentName
        );

        foreach (var studentName in query7)
        {
            Console.WriteLine(studentName);
        }
    }
}

public class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
    public double Tuition { get; set; }
}

public class StudentClubs
{
    public int StudentID { get; set; }
    public string ClubName { get; set; }
}

public class StudentGPA
{
    public int StudentID { get; set; }
    public double GPA { get; set; }
}
