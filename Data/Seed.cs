using System.Collections.Generic;
using System.Linq;
using test2.Models;

namespace test2.Data
{
    public class Seed
    {
        public static void SeedData(RequestContext context)
        {
            if (!context.Departments.Any())
            {
                AddDepartments(context);
            }
        }

        public static void AddDepartments(RequestContext context)
        {
            var departments = new List<Departments>
            {
                new Departments { Department = "IT"},
                new Departments { Department = "Sales" },
                new Departments { Department = "Marketing" },
                new Departments { Department = "Human Resources" },
                new Departments { Department = "Customer Service" },
                new Departments { Department = "Office Management" },
                new Departments { Department = "Finance" },
            };

            foreach (var department in departments)
            {
                context.Departments.Add(department);
            }

            context.SaveChanges();
        }
    }
}