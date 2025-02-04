using System;

namespace PrivateMultipleObjects
{
    class Club
    {
        private string _Name;
        private string _Location;
        private int _MemberCount;

        public Club()
        {
            _Name = string.Empty;
            _Location = string.Empty;
            _MemberCount = 0;
        }

        public Club(string name, string location, int memberCount)
        {
            _Name = name;
            _Location = location;
            _MemberCount = memberCount;
        }

        public string GetName() { return _Name; }
        public string GetLocation() { return _Location; }
        public int GetMemberCount() { return _MemberCount; }
        public void SetName(string name) { _Name = name; }
        public void SetLocation(string location) { _Location = location; }
        public void SetMemberCount(int memberCount) { _MemberCount = memberCount; }

        public virtual void AddChange()
        {
            try
            {
                Console.Write("Club Name: ");
                SetName(Console.ReadLine());
                Console.Write("Location: ");
                SetLocation(Console.ReadLine());
                Console.Write("Member Count: ");
                SetMemberCount(int.Parse(Console.ReadLine()));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for Member Count.");
            }
        }

        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"  Club Name: {GetName()}");
            Console.WriteLine($"  Location: {GetLocation()}");
            Console.WriteLine($"  Members: {GetMemberCount()}");
        }
    }

    class GamingClub : Club
    {
        private string _GameType;
        private bool _HasTournaments;

        public GamingClub() : base()
        {
            _GameType = string.Empty;
            _HasTournaments = false;
        }

        public GamingClub(string name, string location, int memberCount, string gameType, bool hasTournaments)
            : base(name, location, memberCount)
        {
            _GameType = gameType;
            _HasTournaments = hasTournaments;
        }

        public void SetGameType(string gameType) { _GameType = gameType; }
        public void SetHasTournaments(bool hasTournaments) { _HasTournaments = hasTournaments; }
        public string GetGameType() { return _GameType; }
        public bool GetHasTournaments() { return _HasTournaments; }

        public override void AddChange()
        {
            base.AddChange();

            try
            {
                Console.Write("Game Type: ");
                SetGameType(Console.ReadLine());
                Console.Write("Has Tournaments (true/false): ");
                SetHasTournaments(bool.Parse(Console.ReadLine()));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input for Tournaments. Please enter true or false.");
            }
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"  Game Type: {GetGameType()}");
            Console.WriteLine($"  Has Tournaments: {GetHasTournaments()}");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Club Management System");

            int maxClubs = GetValidInput("How many general clubs do you want to enter?");
            Club[] clubs = new Club[maxClubs];

            int maxGamingClubs = GetValidInput("How many gaming clubs do you want to enter?");
            GamingClub[] gamingClubs = new GamingClub[maxGamingClubs];

            int clubCounter = 0, gamingClubCounter = 0;
            int choice;

            while (true)
            {
                choice = Menu();

                if (choice == 4) break;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddClub(ref clubs, ref gamingClubs, ref clubCounter, ref gamingClubCounter);
                            break;
                        case 2:
                            ChangeClub(clubs, gamingClubs, clubCounter, gamingClubCounter);
                            break;
                        case 3:
                            PrintClubs(clubs, gamingClubs, clubCounter, gamingClubCounter);
                            break;
                        default:
                            Console.WriteLine("Invalid selection, try again");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred: {e.Message}");
                }
            }

            Console.WriteLine("Exiting Club Management System. Goodbye!");
        }

        private static int GetValidInput(string prompt)
        {
            int input;
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out input) && input >= 0)
                    return input;
                Console.WriteLine("Please enter a valid positive whole number");
            }
        }

        private static void AddClub(ref Club[] clubs, ref GamingClub[] gamingClubs, ref int clubCounter, ref int gamingClubCounter)
        {
            int type = GetClubType();

            if (type == 1)
            {
                if (gamingClubCounter < gamingClubs.Length)
                {
                    gamingClubs[gamingClubCounter] = new GamingClub();
                    gamingClubs[gamingClubCounter].AddChange();
                    gamingClubCounter++;
                }
                else
                    Console.WriteLine("The maximum number of gaming clubs has been added");
            }
            else
            {
                if (clubCounter < clubs.Length)
                {
                    clubs[clubCounter] = new Club();
                    clubs[clubCounter].AddChange();
                    clubCounter++;
                }
                else
                    Console.WriteLine("The maximum number of clubs has been added");
            }
        }

        private static void ChangeClub(Club[] clubs, GamingClub[] gamingClubs, int clubCounter, int gamingClubCounter)
        {
            Console.Write("Enter the record number you want to change: ");
            if (!int.TryParse(Console.ReadLine(), out int rec))
            {
                Console.WriteLine("Invalid record number");
                return;
            }
            rec--;

            if (rec >= 0 && rec < gamingClubCounter)
                gamingClubs[rec].AddChange();
            else if (rec >= 0 && rec < clubCounter)
                clubs[rec].AddChange();
            else
                Console.WriteLine("Invalid record number");
        }

        private static void PrintClubs(Club[] clubs, GamingClub[] gamingClubs, int clubCounter, int gamingClubCounter)
        {
            if (clubCounter > 0)
            {
                Console.WriteLine("\nGeneral Clubs:");
                for (int i = 0; i < clubCounter; i++)
                    clubs[i].Display();
            }
            else
            {
                Console.WriteLine("No general clubs entered.");
            }

            if (gamingClubCounter > 0)
            {
                Console.WriteLine("\nGaming Clubs:");
                for (int i = 0; i < gamingClubCounter; i++)
                    gamingClubs[i].Display();
            }
            else
            {
                Console.WriteLine("No gaming clubs entered.");
            }

            Environment.Exit(0);
        }

        private static int Menu()
        {
            while (true)
            {
                Console.WriteLine("\nPlease make a selection from the menu");
                Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");

                if (int.TryParse(Console.ReadLine(), out int selection) && selection >= 1 && selection <= 4)
                    return selection;

                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
            }
        }

        private static int GetClubType()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 for Gaming Club or 2 for General Club");
                if (int.TryParse(Console.ReadLine(), out int type) && (type == 1 || type == 2))
                    return type;
                Console.WriteLine("Invalid input. Please enter 1 or 2.");
            }
        }
    }
}