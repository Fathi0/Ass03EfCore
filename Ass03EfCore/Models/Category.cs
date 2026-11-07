using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Category? ParentCategory { get; set; }

        public int? ParentCategoryId { get; set; }
        public Course[] courses { get; set; }
        public Category[] SubCategories { get; set; }
    }
}
