using Ass03EfCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CourseLevel Level { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public Instructor instructor { get; set; }

        public int InstructorId { get; set; }
        public Category category { get; set; }
        public int CategoryId { get; set; }
        public Enrollment[] enrollments { get; set; }
    }
}
