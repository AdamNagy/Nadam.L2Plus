using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJ05_LINQ
{
    public static class EmployeesTasks
    {
        static IEnumerable<Employee> employees = new[] {
            new Employee { Name = "Bela", Salary = 400},
            new Employee { Name = "Laszlo", Salary = 400},
            new Employee { Name = "Hunor", Salary = 500},
            new Employee { Name = "Aron", Salary = 500},
            new Employee { Name = "Andras", Salary = 420},
            new Employee { Name = "Csaba", Salary = 250},
            new Employee { Name = "David", Salary = 300},
            new Employee { Name = "Endre", Salary = 620},
            new Employee { Name = "Ferenc", Salary = 350},
            new Employee { Name = "Gabor", Salary = 410},
            new Employee { Name = "Imre", Salary = 900},
            new Employee { Name = "Janos", Salary = 600},
            new Employee { Name = "Karoly", Salary = 700},
        };

        public static void Run()
        {
            SameSalary();
        }

        static void BiggestSalary()
        {
            var biggestSalary = employees.MaxByProperty(p => p.Salary);
            Console.WriteLine(biggestSalary);
        }

        // TODO: check if possible to write 1 query
        static void BelowAvarage()
        {
            var avg = employees.Average(p => p.Salary);
            var lessThanAvg = employees.Where(p => p.Salary < avg);
        }

        // Task: Display the name of employees who earn the same amount and sort the result by salaries then names in an ascending order
        static void SameSalary()
        {
            var query = employees.GroupBy(p => p.Salary)
                .Where(q => q.Count() > 1)
                .OrderBy(r => r.Key)
                .ToDictionary(p => p.Key, q => q.OrderBy(r => r.Name).Select(s => s.Name));

            foreach (var group in query)
            {
                Console.WriteLine($"group: {group.Key}");
                foreach (var item in group.Value)                
                    Console.WriteLine(item);                
            }
        }

        // Group the employees in the following salary ranges: 200-399, 400-599, 600-799, 800-999
        public static void SalaryGroups()
        {

        }

        public static Dictionary<TKey, IEnumerable<T>> MyGroupBy<T, TKey>(this IEnumerable<T> subject, Func<T, TKey> groupper)
        {
            throw new NotImplementedException();
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }
}
