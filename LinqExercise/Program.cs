using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            var average = numbers.Average();
  
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Average: { average}");

            //Order numbers in ascending order and decsending order. Print each to console.
            var ascending = numbers.OrderBy(x => x);
            Console.WriteLine("Ascending:");


            foreach (var num in ascending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(" ");

            var descending = numbers.OrderByDescending(x => x);
            Console.WriteLine("Descending:");

            foreach (var num in descending)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("");

            //Print to the console only the numbers greater than 6

            Console.WriteLine("Printing the numbers greater than 6");
            var six = numbers.Where(x => x > 6);

            foreach (var num in six)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("");

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            var order = numbers.OrderBy(x => x);
            Console.WriteLine("Ordered list with first 4 numbers:");

            foreach (var num in order.Take(4))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("");

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 27;

            Console.WriteLine("Updated descending list with my age included:");
            foreach (var item in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("");
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();


            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            Console.WriteLine("Employees with first name starting with C or S:");
            var cors =
                employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S'))
                .OrderBy(x => x.FirstName);

            foreach (var name in cors)
            {
                Console.WriteLine(name.FullName);
            }

            Console.WriteLine("");

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            Console.WriteLine("List of employees over the age of 26:");

            var twentySix =
                employees.Where(x => x.Age > 26)
                .OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var employee in twentySix)
            {
                Console.WriteLine($"{employee.FullName} {employee.Age}");
            }

            Console.WriteLine("");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoe = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

            var yoesum = yoe.Sum(x => x.YearsOfExperience);

            var yoeavg = yoe.Average(x => x.YearsOfExperience);

            Console.WriteLine($"Sum of employees over 35 years of experience: {yoesum}\n" +
                $"Average of employees years of experience: {yoeavg}");

            Console.WriteLine("");
            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Added a new employee to the end of the list! Check it out:");
            employees = employees.Append(new Employee("Saba", "Arefaine", 27, 2)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.Age}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
