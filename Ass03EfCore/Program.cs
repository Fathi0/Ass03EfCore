using Ass03EfCore.Models;
using Ass03EfCore.Operations;

namespace Ass03EfCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbcontext context = new AppDbcontext();
            if (!context.Students.Any())
            {
                var Students = new List<Student>
                {
                    new Student
                    {
                                    FullName = "Mohamed Ahmed",
            Email = "mohamed@example.com",
            DateOfBirth = new DateTime(2000, 5, 10)
                    },
                    new Student
                    {
                                    FullName = "Ali Hassan",
            Email = "ali@example.com",
            DateOfBirth = new DateTime(1999, 8, 15)
                    },
                    new Student
                    {
                                    FullName = "Sara Mohamed",
            Email = "sara@example.com",
            DateOfBirth = new DateTime(2001, 3, 20)
                    },
                    new Student
                    {
                                    FullName = "Omar Khaled",
            Email = "omar@example.com",
            DateOfBirth = new DateTime(1998, 12, 5)
                    },
                    new Student
                    {
                                    FullName = "Mona Ali",
            Email = "mona@example.com",
            DateOfBirth = new DateTime(2002, 7, 25)
                    }

                };
                context.Students.AddRange(Students);

                context.SaveChanges();
            }
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        StudentId = 1,
                        CourseId = 1,
                        EnrollmentDate = new DateTime(2026, 1, 10),
                        ProgressPercentage = 50,
                        Status = EnrollmentStatus.Active
                    },
                    new Enrollment
                    {
                                    StudentId = 1,
            CourseId = 2,
            EnrollmentDate = new DateTime(2026, 1, 15),
            ProgressPercentage = 100,
            Status = EnrollmentStatus.Completed,
            FinalGrade = 95
                    },
                    new Enrollment
                    {
                                    StudentId = 2,
            CourseId = 1,
            EnrollmentDate = new DateTime(2026, 2, 1),
            ProgressPercentage = 20,
            Status = EnrollmentStatus.Active
                    },
                    new Enrollment
                    {
                                    StudentId = 2,
            CourseId = 3,
            EnrollmentDate = new DateTime(2026, 2, 5),
            ProgressPercentage = 100,
            Status = EnrollmentStatus.Completed,
            FinalGrade = 88
                    },
                    new Enrollment
                    {
                                    StudentId = 3,
            CourseId = 2,
            EnrollmentDate = new DateTime(2026, 3, 1),
            ProgressPercentage = 0,
            Status = EnrollmentStatus.Dropped
                    },
                    new Enrollment
                    {
                                    StudentId = 3,
            CourseId = 4,
            EnrollmentDate = new DateTime(2026, 3, 5),
            ProgressPercentage = 60,
            Status = EnrollmentStatus.Active
                    },
                    new Enrollment
                    {
                                    StudentId = 4,
            CourseId = 3,
            EnrollmentDate = new DateTime(2026, 4, 1),
            ProgressPercentage = 100,
            Status = EnrollmentStatus.Completed,
            FinalGrade = 92
                    },
                    new Enrollment
                    {
                                    StudentId = 5,
            CourseId = 4,
            EnrollmentDate = new DateTime(2026, 4, 10),
            ProgressPercentage = 30,
            Status = EnrollmentStatus.Dropped
                    }

                };
                context.Enrollments.AddRange(enrollments);
                context.SaveChanges();
            }
            //Student Test
            //StudentOperations.AddStudent(context);
            //StudentOperations.AddStudent(context); //->Not Added
            //StudentOperations.GetAllStudents(context);
            //StudentOperations.GetStudentById(context, 1);
            //StudentOperations.UpdateStudent(context, 1);
            //StudentOperations.DeleteStudent(context, 6);
            //Instructor Test
            //InstructorOperations.AddInstructor(context);
            //InstructorOperations.GetAllInstructor(context);
            //InstructorOperations.GetInstructorsById(context, 1);
            //InstructorOperations.UpdateInstructor(context, 1);
            //InstructorOperations.DeleteInstructor(context, 4);
            //Category Test
            //CategoryOperations.AddCategory(context);
            //CategoryOperations.GetAllCaegoris(context);
            //CategoryOperations.GetCategoryById(context, 1);
            //CategoryOperations.UpdateCategory(context, 1);
            //CategoryOperations.DeleteCategory(context, 1);
        }
    }
}
