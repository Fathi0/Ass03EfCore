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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> E)
        {
            E.HasKey(E => new { E.StudentId, E.CourseId });
            E.Property(E => E.EnrollmentDate)
                .IsRequired(true);
            E.Property(E => E.ProgressPercentage)
                .HasPrecision(10, 2)
                .IsRequired(true);
            E.Property(E => E.Status)
                .IsRequired(true);
            E.Property(E => E.FinalGrade)
                .IsRequired(false);
            E.HasOne(E => E.student)
                .WithMany(S => S.enrollments)
                .HasForeignKey(E => E.StudentId);
            E.HasOne(E => E.course)
                .WithMany(C => C.enrollments)
                .HasForeignKey(E => E.CourseId);
        }
    }
}
