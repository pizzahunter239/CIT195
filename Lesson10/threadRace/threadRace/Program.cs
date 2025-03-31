namespace threadRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read, Set Go...");
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;

            bool raceFinished = false;

            //Creating Threads
            Thread t1 = new Thread(delegate ()
            {
                Thread.CurrentThread.Name = "Speedy Gonzales";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished)
                        MoveIt(ref t1Location, ref raceFinished);
                }

            });
            Thread t2 = new Thread(delegate ()
            {
                Thread.CurrentThread.Name = "Road Runner";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished)
                        MoveIt(ref t2Location, ref raceFinished);

                }
            });
            Thread t3 = new Thread(delegate ()
            {
                Thread.CurrentThread.Name = "Sonic the Hedgehog";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished)
                        MoveIt(ref t3Location, ref raceFinished);
                }
            });
            Thread t4 = new Thread(delegate ()
            {
                Thread.CurrentThread.Name = "Flash";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished)
                        MoveIt(ref t4Location, ref raceFinished);
                }
            });
            Thread t5 = new Thread(delegate ()
            {
                Thread.CurrentThread.Name = "Cade";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished)
                        MoveIt(ref t5Location, ref raceFinished);
                }
            });
            //Executing the methods

            t3.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine($"{t3.Name} has AboveNormal priority");

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();

            Console.WriteLine("Race has ended");
        }
        static void MoveIt(ref int location, ref bool raceFinished)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100 && !raceFinished)
            {
                raceFinished = true;
                Console.WriteLine($"{Thread.CurrentThread.Name} is the winner");
                return;
            }
        }

    }
}