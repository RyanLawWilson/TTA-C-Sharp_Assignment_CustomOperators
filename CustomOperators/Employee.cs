using System;
using System.Collections.Generic;
using System.Text;

namespace CustomOperators
{
    public class Employee
    {
        public Employee ()
        {
            ID = rand.Next(0, 10);
            FirstName = NAMES[rand.Next(0, NAMES.Count)];
            LastName = NAMES[rand.Next(0, NAMES.Count)];
            Name = FirstName + " " + LastName;
        }

        public Employee (int id)
        {
            ID = id;
            FirstName = NAMES[rand.Next(0, NAMES.Count)];
            LastName = NAMES[rand.Next(0, NAMES.Count)];
            Name = FirstName + " " + LastName;
        }

        private Random rand = new Random();
        private static List<string> NAMES = new List<string>()
            { "Joe", "Kyle", "Samantha", "Albert", "Johnny", "Dude",
              "Mike", "Mikey", "George", "Jenny", "Mario",
              "Cid", "Boldur", "Kratos", "John", "Cortana", "Jul",
              "Luigi", "Toad", "Michael", "Grunt", "Grundy", "LITERALLY-BATMAN",
              "Ronald", "Harry", "Borris", "Reese", "Mald", "Maul",};

        public int ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; }     

        // If you want to overload ==, you must also overload !=
        // Warnings appear if you overload == and !=.  Need to override .Equals() and .GetHashCode()

        public static bool operator== (Employee emp1, Employee emp2)
        {
            return emp1.ID == emp2.ID ? true : false;
        }

        public static bool operator!= (Employee emp1, Employee emp2)
        {
            return emp1.ID == emp2.ID ? false : true;
        }

        public override bool Equals(Object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public static List<Employee> operator+ (List<Employee> employees, Employee employee)
        {
            employees.Add(employee);
            return employees;
        }
    }
}
