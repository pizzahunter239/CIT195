using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Workout.Model;

namespace Workout.Data
{
    public class WorkoutContext : DbContext
    {
        public WorkoutContext (DbContextOptions<WorkoutContext> options)
            : base(options)
        {
        }

        public DbSet<Workout.Model.Exercise> Exercise { get; set; } = default!;
        public DbSet<Workout.Model.User> User { get; set; } = default!;
        public DbSet<Workout.Model.WorkoutLog> WorkoutLog { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "John Doe", Email = "jdoe@email.com"},
                new User { Id = 2, Name = "James Smith", Email = "jsmith@email.com"}
                );
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name= "Bulgarian Split Squat", Type=Workout.Model.Type.Strength, MuscleGroup = "Quads", Reps=12, Sets=3 },
                new Exercise { Id = 2, Name = "Romanian Deadlift", Type = Workout.Model.Type.Strength, MuscleGroup = "Hamstrings", Reps = 10, Sets = 3 },
                new Exercise { Id = 3, Name = "Bench Press", Type = Workout.Model.Type.Strength, MuscleGroup = "Chest", Reps = 8, Sets = 4 },
                new Exercise { Id = 4, Name = "Fixed Row", Type = Workout.Model.Type.Strength, MuscleGroup = "Traps", Reps = 12, Sets = 4 },
                new Exercise { Id = 5, Name = "Pulldown", Type = Workout.Model.Type.Strength, MuscleGroup = "Lats", Reps = 12, Sets = 4 },
                new Exercise { Id = 6, Name = "Stationary Bike", Type = Workout.Model.Type.Cardio, MuscleGroup = "Legs", Duration = 45 }
                );
            modelBuilder.Entity<WorkoutLog>().HasData(
                new WorkoutLog { Id = 1, Date = DateTime.Today, UserId = 1, ExerciseId = 1 },
                new WorkoutLog { Id = 2, Date = DateTime.Today, UserId = 1, ExerciseId = 2}
                );
        }
    }
}
