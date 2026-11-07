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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> C)
        {
            C.HasKey(C => C.Id);
            C.Property(C => C.Name)
                .HasColumnType("varchar(100)")
                .IsRequired(true);
            C.Property(C => C.Description)
                .HasColumnType("varchar(500)")
                .IsRequired(false);
            C.Property(C => C.ParentCategoryId)
                .IsRequired(false);
            C.HasOne(C => C.ParentCategory)
                .WithMany(C => C.SubCategories)
                .HasForeignKey(C => C.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            C.HasMany(C => C.courses)
                .WithOne(CO => CO.category)
                .HasForeignKey(CO => CO.CategoryId);
            C.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Programming",
                    Description = "Programming Courses",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = 2,
                    Name = "Backend",
                    Description = "Backend Development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 3,
                    Name = "Frontend",
                    Description = "Frontend Development",
                    ParentCategoryId = 1
                },
                new Category
                {
                    Id = 4,
                    Name = "ASP.NET Core",
                    Description = "ASP.NET Core Courses",
                    ParentCategoryId = 2
                },
                new Category
                {
                    Id = 5,
                    Name = "Database",
                    Description = "Database Courses",
                    ParentCategoryId = 1
                }
);

        }
    }
}
