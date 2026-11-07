using Ass03EfCore.Enums;
using Ass03EfCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> CO)
        {
            CO.HasKey(CO => CO.Id);
            CO.Property(CO => CO.Title)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            CO.Property(CO => CO.Description)
                .HasColumnType("varchar(1000)")
                .IsRequired(false);
            CO.Property(CO => CO.Price)
                .HasPrecision(10, 2)
                .IsRequired(true);
            CO.Property(CO => CO.Level)
                .IsRequired(true);
            CO.Property(CO => CO.IsPublished)
                .IsRequired(true);
            CO.Property(CO => CO.PublishedDate)
                .IsRequired(false);
            CO.HasOne(CO => CO.instructor)
                .WithMany(I => I.courses)
                .HasForeignKey(CO => CO.InstructorId);
            CO.HasOne(CO => CO.category)
                .WithMany(C => C.courses)
                .HasForeignKey(CO => CO.CategoryId);
            CO.HasMany(CO => CO.enrollments)
                .WithOne(E => E.course)
                .HasForeignKey(E => E.CourseId);
            CO.HasData
            (
                new Course
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "Learn C# from scratch",
                    Price = 500,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2024, 1, 10),
                    InstructorId = 1,
                    CategoryId = 1
                },
                new Course
                {
                    Id = 2,
                    Title = "ASP.NET Core",
                    Description = "Learn Web Development",
                    Price = 1000,
                    Level = CourseLevel.Intermediate,
                    IsPublished = true,
                    PublishedDate = new DateTime(2024, 2, 15),
                    InstructorId = 1,
                    CategoryId = 4
                },
                new Course
                {
                    Id = 3,
                    Title = "HTML and CSS",
                    Description = "Frontend Basics",
                    Price = 400,
                    Level = CourseLevel.Beginner,
                    IsPublished = true,
                    PublishedDate = new DateTime(2024, 3, 20),
                    InstructorId = 2,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 4,
                    Title = "JavaScript Advanced",
                    Description = "Advanced JavaScript",
                    Price = 700,
                    Level = CourseLevel.Advanced,
                    IsPublished = true,
                    PublishedDate = new DateTime(2024, 4, 10),
                    InstructorId = 2,
                    CategoryId = 3
                },
                new Course
                {
                    Id = 5,
                    Title = "SQL Server",
                    Description = "Database Fundamentals",
                    Price = 600,
                    Level = CourseLevel.Beginner,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 5
                },
                new Course
                {
                    Id = 6,
                    Title = "Database Design",
                    Description = "Advanced Database Design",
                    Price = 900,
                    Level = CourseLevel.Advanced,
                    IsPublished = false,
                    PublishedDate = null,
                    InstructorId = 3,
                    CategoryId = 5
                }
            );
        }
    }
}
