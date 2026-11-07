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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> S)
        {
            S.HasKey(S => S.Id);
            S.Property(S => S.FullName)
                .HasColumnType("varchar(150)")
                .IsRequired(true);
            S.Property(S => S.Email)
                .HasColumnType("varchar(200)")
                .IsRequired(true);
            S.Property(S => S.DateOfBirth)
                .IsRequired(true);
            S.HasMany(S => S.enrollments)
                .WithOne(E => E.student)
                .HasForeignKey(E => E.StudentId);
        }
    }
}
