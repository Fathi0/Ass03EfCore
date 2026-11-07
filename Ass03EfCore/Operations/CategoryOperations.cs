using Ass03EfCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass03EfCore.Operations
{
    public class CategoryOperations
    {
        public static void AddCategory(AppDbcontext context)
        {
            Category category = new Category
            {
                Name = "JavaScript",
                Description = "JavaScript Programming",
                ParentCategoryId = null
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }
        public static void GetAllCaegoris(AppDbcontext context)
        {
            var AllCaregories = context.Categories.ToList();
            foreach (var category in AllCaregories)
            {
                Console.WriteLine($"ID: {category.Id}");
                Console.WriteLine($" Name: {category.Name}");
                Console.WriteLine($"Parent Category Id : {category.ParentCategoryId}");
                Console.WriteLine("------------------");
            }

        }
        public static void GetCategoryById(AppDbcontext context, int CategoryId)
        {
            var category = context.Categories.FirstOrDefault(C => C.Id == CategoryId);
            if (category == null)
            {
                Console.WriteLine("Category Not Found");
            }
            else
                Console.WriteLine($"ID: {category.Id}");
            Console.WriteLine($" Name: {category.Name}");
            Console.WriteLine($"Parent Category Id : {category.ParentCategoryId}");
            Console.WriteLine("------------------");
        }
        public static void UpdateCategory(AppDbcontext context, int CategoryId)
        {
            var category = context.Categories.FirstOrDefault(C => C.Id == CategoryId);
            if (category == null)
            {
                Console.WriteLine("Category Not Found");
            }
            else
            {
                category.Name = "JavaScript Advanced";
                context.SaveChanges();

            }
        }
        public static void DeleteCategory(AppDbcontext context, int CategoryId)
        {
            var category = context.Categories.FirstOrDefault(C => C.Id == CategoryId);

            if (category == null)
            {
                Console.WriteLine("Category Not Found");
                return;
            }

            bool HasSubCategories = context.Categories
                .Any(C => C.ParentCategoryId == CategoryId);

            if (HasSubCategories)
            {
                Console.WriteLine("Cannot Delete Category Because It Has SubCategories");
                return;
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            Console.WriteLine("Category Deleted Successfully");
        }
    }
}
