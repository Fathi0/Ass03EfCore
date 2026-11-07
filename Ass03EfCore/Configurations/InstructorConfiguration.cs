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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> I)
        {
            I.HasKey(I => I.Id);
            I.Property(I => I.FullName)
                .HasColumnType("varchar(150)")
                .IsRequired(true);
            I.Property(I => I.Email)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            I.Property(I => I.Bio)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
            I.Property(I => I.JoinedDate)
                .IsRequired(true);
            I.HasMany(I => I.courses)
                .WithOne(C => C.instructor)
                .HasForeignKey(C => C.InstructorId);
            I.HasData
            (
                new Instructor
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "ahmed@example.com",
                    Bio = "Backend Developer",
                    JoinedDate = new DateTime(2022, 1, 10)
                },
                new Instructor
                {
                    Id = 2,
                    FullName = "Sara Ali",
                    Email = "sara@example.com",
                    Bio = "Frontend Developer",
                    JoinedDate = new DateTime(2023, 5, 15)
                },
                new Instructor
                {
                    Id = 3,
                    FullName = "Omar Hassan",
                    Email = "omar@example.com",
                    Bio = "Database Specialist",
                    JoinedDate = new DateTime(2021, 8, 20)
                }
            );
        }
    }
}
