using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NJ05_LINQ
{
    public static class EmployeesTasks
    {
        static IEnumerable<Employee> employees = new[] {
            new Employee { Name = "Andras", Salary = 420},
            new Employee { Name = "Bela", Salary = 400},
            new Employee { Name = "Laszlo", Salary = 400},
            new Employee { Name = "Hunor", Salary = 500},
            new Employee { Name = "Aron", Salary = 500},
            new Employee { Name = "David", Salary = 300},
            new Employee { Name = "Csaba", Salary = 250},
            new Employee { Name = "Endre", Salary = 620},
            new Employee { Name = "Ferenc", Salary = 350},
            new Employee { Name = "Gabor", Salary = 410},
            new Employee { Name = "Imre", Salary = 900},
            new Employee { Name = "Janos", Salary = 600},
            new Employee { Name = "Karoly", Salary = 700},
        };

        public static void Run()
        {
            BiggestSalary();
            BelowAvarage();
            SameSalary();
            SalaryGroups();
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
            Console.WriteLine("************************************\nGroup the employees in the following salary ranges: 200-399, 400-599, 600-799, 800-999");
            var query1 = employees.MyToDictionary<string, Employee>(SalaryGroups_Groupper);
            var query2 = employees.ToLookup(SalaryGroups_Groupper);
            var query3 = employees.GroupBy(SalaryGroups_Groupper);

            Console.WriteLine("Solution 1");
            foreach (var group in query1)
            {
                Console.WriteLine($"\ngroup: {group.Key}");
                foreach (var item in group.Value)
                    Console.WriteLine(item);
            }

            Console.WriteLine("Solution 2");
            foreach (var group in query2)
            {
                Console.WriteLine($"\ngroup: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine(item);
            }

            Console.WriteLine("Solution 3");
            foreach (var group in query3)
            {
                Console.WriteLine($"\ngroup: {group.Key}");
                foreach (var item in group)
                    Console.WriteLine(item);
            }
        }

        // groups: 200-399, 400-599, 600-799, 800-999
        private static string SalaryGroups_Groupper(Employee employee)
        {
            if (employee.Salary < 400)
                return "200-399";
            else if (employee.Salary < 600)
                return "400-599";
            else if (employee.Salary < 800)
                return "600-799";
            else
                return "800-999";
        }

        /******************************************************
        Just playing around by implementing existing operations
        ******************************************************/

        // convert the input list to a Dictionary, and put elements with same key into a list
        public static Dictionary<TKey, IEnumerable<T>> MyToDictionary<TKey, T>(this IEnumerable<T> subject, Func<T, TKey> groupper)
        {
            var dict = new Dictionary<TKey, IEnumerable<T>>();
            foreach (var item in subject)
            {
                if (!dict.ContainsKey(groupper(item)))
                    dict.Add(groupper(item), new List<T>());
                
                (dict[groupper(item)] as IList).Add(item);
            }         

            return dict;
        }

        // convert the input list into a list of (id, value) tuple list
        public static IEnumerable<(TKey, T)> MyGroupBy<TKey, T>(this IEnumerable<T> subject, Func<T, TKey> groupper)
        {
            var groups = subject.Select(p => (id: groupper(p), value: p))
                                .OrderBy(q => q.id);
            return groups;
        }
    }
     
    // this struct is similar to (id, value) tuple
    struct Group<TKey, T>
    {
        public TKey Header { get; set; }
        public IEnumerable<T> Body { get; set; }
    }

    // just helper class to have a type
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name,-8} , Salaray: {Salary}";
        }
    }
}
