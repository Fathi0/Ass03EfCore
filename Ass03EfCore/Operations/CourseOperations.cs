using Ass03EfCore.Enums;
using Ass03EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Operations
{
    public class CourseOperations
    {
        public static void AddCourse(AppDbcontext context)

        {
            var instructorExists = context.Instructors.Any(I => I.Id == 1);
            var categoryExists = context.Categories.Any(c => c.Id == 4);
            if (!instructorExists || !categoryExists)
            {
                Console.WriteLine("Instructor or Category not found");
                return;
            }
            Course course = new Course
            {
                Title = "ASP.NET Core Web API",
                Description = "Learn how to build RESTful APIs using ASP.NET Core",
                Price = 1200,
                Level = CourseLevel.Intermediate,
                IsPublished = true,
                PublishedDate = DateTime.Now,
                InstructorId = 1,
                CategoryId = 4
            };
            context.Courses.Add(course);
            context.SaveChanges();
            Console.WriteLine($"Course Added Successfully. ID: {course.Id}");

        }
        public static void GetAllCourses(AppDbcontext context)
        {
            var AllCourses = context.Courses.ToList();
            foreach (var course in AllCourses)
            {
                Console.WriteLine($"ID: {course.Id}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Price: {course.Price}");
                Console.WriteLine($"Level: {course.Level}");
                Console.WriteLine("------------------");
            }

        }
        public static void GetCourseById(AppDbcontext context, int CourseId)
        {
            var Course = context.Courses.FirstOrDefault(C => C.Id == CourseId);
            if (Course == null)
            {
                Console.WriteLine("Course Not Found");
            }
            else
            {
                Console.WriteLine($"ID: {Course.Id}");
                Console.WriteLine($"Title: {Course.Title}");
                Console.WriteLine($"Price: {Course.Price}");
                Console.WriteLine($"Level: {Course.Level}");
            }
        }
        public static void UpdateCourse(AppDbcontext context, int CourseId)
        {
            var Course = context.Courses.FirstOrDefault(C => C.Id == CourseId);
            if (Course == null)
            {
                Console.WriteLine("Course Not Found");
            }
            else
            {
                Course.Price = 1500;
                context.SaveChanges();

            }
        }
        public static void DeleteCourse(AppDbcontext context, int CourseId)
        {
            var Course = context.Courses.FirstOrDefault(C => C.Id == CourseId);
            if (Course == null)
            {
                Console.WriteLine("Course Not Found");
            }
            else
            {
                context.Courses.Remove(Course);
                context.SaveChanges();
            }
        }
        public static void BulkUpdateCoursePrices(AppDbcontext context)
        {
            context.Courses
                .Where(C => C.Price < 500)
                .ExecuteUpdate(C => C.SetProperty(C => C.Price, C => 500));
            Console.WriteLine("Course Prices Updated Successfully");
        }
        public static void BulkDeleteUnpublishedCourses(AppDbcontext context)
        {
            int DeletedRows = context.Courses
                .Where(C => C.IsPublished == false)
                .ExecuteDelete();

            Console.WriteLine($"{DeletedRows} Unpublished Courses Deleted Successfully");
        }
        public static void BulkIncreaseCoursePrices(AppDbcontext context, CourseLevel level)
        {
            int UpdatedRows = context.Courses
                .Where(C => C.IsPublished && C.Level == level)
                .ExecuteUpdate(S =>
                    S.SetProperty(
                        C => C.Price,
                        C => C.Price * 1.10m));

            Console.WriteLine($"{UpdatedRows} Courses Updated Successfully");
        }
    }
}
