using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Models
{
    public class Enrollment
    {
        public Student student { get; set; }
        public int StudentId { get; set; }
        public Course course { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal ProgressPercentage { get; set; }
        public EnrollmentStatus Status { get; set; }
        public decimal? FinalGrade { get; set; }
    }
}
