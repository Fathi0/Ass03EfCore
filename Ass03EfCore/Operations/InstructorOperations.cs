using Ass03EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Operations
{
    public class InstructorOperations
    {
        public static void AddInstructor(AppDbcontext context)
        {
            Instructor instructor = new Instructor
            {
                FullName = "Mohamed Ali",
                Email = "mohamed@gmail.com",
                Bio = "C# Developer",
                JoinedDate = DateTime.Now
            };
            context.Instructors.Add(instructor);
            context.SaveChanges();
            Console.WriteLine($"Instructor Added Successfully. ID: {instructor.Id}");
        }
        public static void GetAllInstructor(AppDbcontext context)
        {
            var AllInstructors = context.Instructors.ToList();
            foreach (var Instructors in AllInstructors)
            {
                Console.WriteLine($"ID: {Instructors.Id}");
                Console.WriteLine($"Full Name: {Instructors.FullName}");
                Console.WriteLine($"Email: {Instructors.Email}");
                Console.WriteLine("------------------");
            }

        }
        public static void GetInstructorsById(AppDbcontext context, int InstructorId)
        {
            var Instructor = context.Instructors.FirstOrDefault(I => I.Id == InstructorId);
            if (Instructor == null)
            {
                Console.WriteLine("Instructor Not Found");
            }
            else
            {
                Console.WriteLine($"ID: {Instructor.Id}");
                Console.WriteLine($"Full Name: {Instructor.FullName}");
                Console.WriteLine($"Email: {Instructor.Email}");
                Console.WriteLine("------------------");
            }
        }
        public static void UpdateInstructor(AppDbcontext context, int InstructorId)
        {
            var Instructor = context.Instructors.FirstOrDefault(I => I.Id == InstructorId);
            if (Instructor == null)
            {
                Console.WriteLine("Instructor Not Found");
            }
            else
            {
                Instructor.FullName = "MohamedAhmed";
                context.SaveChanges();

            }
        }
        public static void DeleteInstructor(AppDbcontext context, int InstructorId)
        {
            var Instructor = context.Instructors.FirstOrDefault(I => I.Id == InstructorId);
            if (Instructor == null)
            {
                Console.WriteLine("Instructor Not Found");
            }
            else
            {
                context.Instructors.Remove(Instructor);
                context.SaveChanges();
            }
        }
    }
}
