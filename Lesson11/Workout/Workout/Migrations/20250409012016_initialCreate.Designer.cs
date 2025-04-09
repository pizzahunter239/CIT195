﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workout.Data;

#nullable disable

namespace Workout.Migrations
{
    [DbContext(typeof(WorkoutContext))]
    [Migration("20250409012016_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Workout.Model.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Equipment")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MuscleGroup")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Sets")
                        .HasColumnType("int");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Equipment = "",
                            MuscleGroup = "Quads",
                            Name = "Bulgarian Split Squat",
                            Reps = 12,
                            Sets = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Equipment = "",
                            MuscleGroup = "Hamstrings",
                            Name = "Romanian Deadlift",
                            Reps = 10,
                            Sets = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Equipment = "",
                            MuscleGroup = "Chest",
                            Name = "Bench Press",
                            Reps = 8,
                            Sets = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            Equipment = "",
                            MuscleGroup = "Traps",
                            Name = "Fixed Row",
                            Reps = 12,
                            Sets = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Equipment = "",
                            MuscleGroup = "Lats",
                            Name = "Pulldown",
                            Reps = 12,
                            Sets = 4,
                            Type = 1
                        },
                        new
                        {
                            Id = 6,
                            Duration = 45,
                            Equipment = "",
                            MuscleGroup = "Legs",
                            Name = "Stationary Bike",
                            Type = 0
                        });
                });

            modelBuilder.Entity("Workout.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdoe@email.com",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jsmith@email.com",
                            Name = "James Smith"
                        });
                });

            modelBuilder.Entity("Workout.Model.WorkoutLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutLog");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            ExerciseId = 1,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            ExerciseId = 2,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Workout.Model.WorkoutLog", b =>
                {
                    b.HasOne("Workout.Model.Exercise", "Exercise")
                        .WithMany("WorkoutLog")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workout.Model.User", "User")
                        .WithMany("WorkoutLog")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Workout.Model.Exercise", b =>
                {
                    b.Navigation("WorkoutLog");
                });

            modelBuilder.Entity("Workout.Model.User", b =>
                {
                    b.Navigation("WorkoutLog");
                });
#pragma warning restore 612, 618
        }
    }
}
