using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's hire some employees!");
            System.Threading.Thread.Sleep(1250);

            List<Employee> employees = new List<Employee>();

            Console.WriteLine("First, let's hire you!");
            System.Threading.Thread.Sleep(1250);

            Employee you = new Employee();
            employees += you;
            Console.WriteLine("We are happy to have you, {0}.  Your ID is {1}", you.Name, you.ID);
            System.Threading.Thread.Sleep(1500);

            // Replay the program if the user wants to
            bool retry = true;
            while (retry)
            {
                Console.WriteLine("Now let's add some more Employees!\n");

                // Add more employees until one of the employees has the same ID as you.
                int hiringQuota = 5;       // The number of emplyees that need to be hired.  Must be > i
                for (int i = 0; i < hiringQuota; i++)
                {
                    // If we are on the last iteration of this loop, intentionally make an Employee with the same ID.
                    Employee newEmployee = i == hiringQuota - 1 ? new Employee(you.ID) : new Employee();

                    Console.WriteLine("{0,30}      has joined the team! ID: {1,5}", newEmployee.Name, newEmployee.ID);
                    employees += newEmployee;
                    System.Threading.Thread.Sleep(1250);

                    // Use the overloaded == to compare Employees.
                    if (newEmployee == you)
                    {
                        Console.WriteLine("\nWait a minute...");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("{0} has the same ID as you!:  {1}", newEmployee.Name, newEmployee.ID);
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("STOP HIRING\n");
                        break;
                    }

                    // Got this from https://stackoverflow.com/questions/18547354/c-sharp-linq-find-duplicates-in-list
                    bool duplicateEmployee = employees.GroupBy(x => x.ID).Any(g => g.Count() > 1);

                    // If there are any duplicate IDs in the list that don't match your id, exit the loop.
                    if (duplicateEmployee)
                    {
                        Console.WriteLine("\nWait a minute...");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("Two of the employees have the same IDs!");
                        System.Threading.Thread.Sleep(2000);
                        Console.WriteLine("STOP HIRING\n");
                        break;
                    }
                }

                System.Threading.Thread.Sleep(1000);
                Console.Write("Do you want to retry that, " + you.Name + "? (y or n) ");
                string retryChoice = Console.ReadLine();
                if (retryChoice != "y")
                {
                    Console.WriteLine("Have a nice day!");
                    break;
                }

                employees.Clear();
            }
            
            Console.Read();
        }
    }
}
