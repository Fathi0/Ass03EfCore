using Ass03EfCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Operations
{
    public class EnrollmentOperations
    {
        public static void AddEnrollment(AppDbcontext context)
        {
            int StudentId = 1;
            int CourseId = 1;
            var Student = context.Students.FirstOrDefault(S => S.Id == StudentId);
            if (Student == null)
            {
                Console.WriteLine("Student Not Found");
                return;
            }
            var Course = context.Courses.FirstOrDefault(C => C.Id == CourseId);
            if (Course == null)
            {
                Console.WriteLine("Course Not Found");
                return;
            }
            if (!Course.IsPublished)
            {
                Console.WriteLine("Cannot Enroll in an Unpublished Course");
                return;
            }
            bool alreadyEnrolled = context.Enrollments
    .Any(E => E.StudentId == StudentId && E.CourseId == CourseId);
            if (alreadyEnrolled)
            {
                Console.WriteLine("Student Already Enrolled");
                return;
            }
            Enrollment enrollment = new Enrollment
            {
                StudentId = StudentId,
                CourseId = CourseId,
                Status = EnrollmentStatus.Active,
                ProgressPercentage = 0,
                FinalGrade = null
            };
            context.Enrollments.Add(enrollment);
            context.SaveChanges();

            Console.WriteLine("Enrollment Added Successfully");

        }
        public static void GetAllEnrollments(AppDbcontext context)
        {
            var AllEnrollments = context.Enrollments.ToList();
            foreach (var Enrollment in AllEnrollments)
            {
                Console.WriteLine($"Student ID: {Enrollment.StudentId}");
                Console.WriteLine($" CourseId: {Enrollment.CourseId}");
                Console.WriteLine($"Status : {Enrollment.Status}");
                Console.WriteLine($"Progress Percentage : {Enrollment.ProgressPercentage}");
                Console.WriteLine($"Final Grade : {Enrollment.FinalGrade}");


                Console.WriteLine("------------------");
            }

        }
        public static void GetEnrollmentById(AppDbcontext context, int StudentId, int CourseId)
        {
            var Enrollment = context.Enrollments.FirstOrDefault(E => E.StudentId == StudentId && E.CourseId == CourseId);
            if (Enrollment == null)
            {
                Console.WriteLine("Enrollment Not Found");
            }
            else
            {
                Console.WriteLine($"Student ID: {Enrollment.StudentId}");
                Console.WriteLine($" CourseId: {Enrollment.CourseId}");
                Console.WriteLine($"Status : {Enrollment.Status}");
                Console.WriteLine($"Progress Percentage : {Enrollment.ProgressPercentage}");
                Console.WriteLine($"Final Grade : {Enrollment.FinalGrade}");
            }
        }
        public static void UpdateEnrollment(AppDbcontext contxet, int StudentId, int CourseId, int Progress)
        {
            var Enrollment = contxet.Enrollments.FirstOrDefault(E => E.StudentId == StudentId && E.CourseId == CourseId);
            if (Enrollment == null)
            {
                Console.WriteLine("Enrollment Not Found");
                return;
            }
            if (Progress < 0 || Progress > 100)
            {
                Console.WriteLine("Progress Must Be Between 0 And 100");
                return;
            }
            Enrollment.ProgressPercentage = Progress;
            if (Progress == 100)
            {
                Enrollment.Status = EnrollmentStatus.Completed;
            }
            contxet.SaveChanges();

            Console.WriteLine("Enrollment Updated Successfully");
        }
        public static void DeleteEnrollmentById(AppDbcontext context, int StudentId, int CourseId)
        {
            var Enrollment = context.Enrollments.FirstOrDefault(E => E.StudentId == StudentId && E.CourseId == CourseId);
            if (Enrollment == null)
            {
                Console.WriteLine("Enrollment Not Found");
                return;
            }
            else
            {
                context.Enrollments.Remove(Enrollment);
            }
        }
        public static void UpdateFinalGrade(AppDbcontext context, decimal Grade, int StudentId, int CourseId)
        {
            var Enrollment = context.Enrollments.FirstOrDefault(E => E.StudentId == StudentId && E.CourseId == CourseId);
            if (Enrollment == null)
            {
                Console.WriteLine("Enrollment Not Found");
                return;
            }
            if (Enrollment.Status != EnrollmentStatus.Completed)
            {
                Console.WriteLine("Course Not Completed Yet");
                return;
            }
            Enrollment.FinalGrade = Grade;

            context.SaveChanges();

            Console.WriteLine("Final Grade Updated Successfully");
        }
        public static void BulkDeleteDroppedEnrollments(AppDbcontext context)
        {
            int DeletedRows = context.Enrollments
                .Where(E => E.Status == EnrollmentStatus.Dropped)
                .ExecuteDelete();

            Console.WriteLine($"{DeletedRows} Dropped Enrollments Deleted Successfully");
        }
    }
}
