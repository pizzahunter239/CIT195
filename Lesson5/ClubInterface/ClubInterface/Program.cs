using System;

interface IClub
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName();
}

class ClubMember : IClub
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MembershipType { get; set; }
    public int YearsOfMembership { get; set; }
    public string Email { get; set; }

    public ClubMember()
    {
        Id = 0;
        FirstName = "Unknown";
        LastName = "Unknown";
        MembershipType = "Standard";
        YearsOfMembership = 0;
        Email = "Not Provided";
    }

    public ClubMember(int id, string firstName, string lastName, string membershipType, int yearsOfMembership, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MembershipType = membershipType;
        YearsOfMembership = yearsOfMembership;
        Email = email;
    }

    public string FullName()
    {
        return $"{FirstName} {LastName}";
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id}\nName: {FullName()}\nMembership Type: {MembershipType}\nYears of Membership: {YearsOfMembership}\nEmail: {Email}\n");
    }
}

class Program
{
    static void Main()
    {
        ClubMember member = new ClubMember(1, "John", "Doe", "Premium", 4, "johndoe@email.com");
        member.DisplayInfo();

        ClubMember member2 = new ClubMember();
        member2.Id = 2;
        member2.FirstName = "Jane";
        member2.LastName = "Smith";
        member2.MembershipType = "Standard";
        member2.YearsOfMembership = 3;
        member2.Email = "janesmith@email.com";
        member2.DisplayInfo();
    }
}