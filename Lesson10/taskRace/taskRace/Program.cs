using System;
using System.Threading;
using System.Threading.Tasks;

namespace taskRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ready, Set, Go...");
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;

            bool raceFinished = false;

            // Creating Tasks
            Task t1 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Speedy Gonzales";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished && t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t1Location, ref raceFinished);
                }
            });

            Task t2 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Road Runner";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished && t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t2Location, ref raceFinished);
                }
            });

            Task t3 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Sonic the Hedgehog";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished && t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t3Location, ref raceFinished);
                }
            });

            Task t4 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Flash";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished && t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t4Location, ref raceFinished);
                }
            });

            Task t5 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Quicksilver";
                for (int i = 0; i < 100; i++)
                {
                    if (!raceFinished && t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t5Location, ref raceFinished);
                }
            });

            // Wait for any of the tasks to complete
            Task.WaitAll(t1, t2, t3, t4, t5);

            Console.WriteLine("Race has ended");
        }

        static void MoveIt(ref int location, ref bool raceFinished)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100 && !raceFinished)
            {
                raceFinished = true;
                Console.WriteLine($"{Thread.CurrentThread.Name} is the winner!");
                return;
            }
        }
    }
}