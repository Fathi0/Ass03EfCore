using Ass03EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Operations
{
    public class StudentOperations
    {
        public static void AddStudent(AppDbcontext context)
        {
            Student student = new Student
            {
                FullName = "Ahmed Mohamed",
                Email = "ahmed2026@gmail.com",
                DateOfBirth = new DateTime(2002, 5, 15)
            };
            var AlradyExist = context.Students.Any(S => S.Email == student.Email);
            if (AlradyExist)
            {
                Console.WriteLine("Student Alrady Exist");
            }
            else
            {
                context.Students.Add(student);
                context.SaveChanges();
            }
        }
        public static void GetAllStudents(AppDbcontext context)
        {
            var AllStudents = context.Students.ToList();
            foreach (var Student in AllStudents)
            {
                Console.WriteLine($"ID: {Student.Id}");
                Console.WriteLine($"Full Name: {Student.FullName}");
                Console.WriteLine($"Email: {Student.Email}");
                Console.WriteLine($"DOB: {Student.DateOfBirth}");
                Console.WriteLine("------------------");
            }

        }
        public static void GetStudentById(AppDbcontext context, int StudentId)
        {
            var Student = context.Students.FirstOrDefault(S => S.Id == StudentId);
            if (Student == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                Console.WriteLine($"ID: {Student.Id}");
                Console.WriteLine($"Full Name: {Student.FullName}");
                Console.WriteLine($"Email: {Student.Email}");
                Console.WriteLine($"DOB: {Student.DateOfBirth}");
                Console.WriteLine("------------------");
            }
        }
        public static void UpdateStudent(AppDbcontext context, int StudentId)
        {
            var Student = context.Students.FirstOrDefault(S => S.Id == StudentId);
            if (Student == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                Student.FullName = "AhmedAli";
                context.SaveChanges();

            }
        }
        public static void DeleteStudent(AppDbcontext context, int STudentId)
        {
            var Student = context.Students.FirstOrDefault(S => S.Id == STudentId);
            if (Student == null)
            {
                Console.WriteLine("Student Not Found");
            }
            else
            {
                context.Students.Remove(Student);
                context.SaveChanges();
            }
        }
    }
}
