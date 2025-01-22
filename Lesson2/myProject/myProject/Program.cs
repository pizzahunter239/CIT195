using System;

namespace myProject
{
    class Workout
    {
        private int _duration;
        private string _exerciseType;
        private double _caloriesBurned;

        public Workout()
        {
            _duration = 0;
            _exerciseType = "";
            _caloriesBurned = 0.0;
        }

        public Workout(int duration, string exerciseType, double caloriesBurned)
        {
            _duration = duration;
            _exerciseType = exerciseType;
            _caloriesBurned = caloriesBurned;
        }

        public int GetDuration()
        {
            return _duration;
        }

        public void SetDuration(int duration)
        {
            _duration = duration;
        }

        public string GetExerciseType()
        {
            return _exerciseType;
        }

        public void SetExerciseType(string exerciseType)
        {
            _exerciseType = exerciseType;
        }

        public double GetCaloriesBurned()
        {
            return _caloriesBurned;
        }

        public void SetCaloriesBurned(double caloriesBurned)
        {
            _caloriesBurned = caloriesBurned;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Workout morningYoga = new Workout();
            morningYoga.SetDuration(30);
            morningYoga.SetExerciseType("Yoga");
            morningYoga.SetCaloriesBurned(150.5);

            Workout eveningRun = new Workout();
            eveningRun.SetDuration(45);
            eveningRun.SetExerciseType("Running");
            eveningRun.SetCaloriesBurned(400.0);

            Workout weightTraining = new Workout(60, "Weight Training", 300.2);
            Workout swimming = new Workout(40, "Swimming", 350.0);

            Console.WriteLine("Daily Workout Summary");
            DisplayWorkout("Morning Workout", morningYoga);
            DisplayWorkout("Evening Workout", eveningRun);
            DisplayWorkout("Strength Session", weightTraining);
            DisplayWorkout("Pool Session", swimming);

            double totalCalories = morningYoga.GetCaloriesBurned() +
                                 eveningRun.GetCaloriesBurned() +
                                 weightTraining.GetCaloriesBurned() +
                                 swimming.GetCaloriesBurned();

            Console.WriteLine($"Total calories burned today: {totalCalories}");
        }

        static void DisplayWorkout(string sessionName, Workout workout)
        {
            Console.WriteLine($"{sessionName}:");
            Console.WriteLine($"Exercise Type: {workout.GetExerciseType()}");
            Console.WriteLine($"Duration: {workout.GetDuration()} minutes");
            Console.WriteLine($"Calories Burned: {workout.GetCaloriesBurned()}");
        }
    }
}