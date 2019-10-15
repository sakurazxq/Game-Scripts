using System;
using System.Collections.Generic;
using System.Text;

namespace HighLevel
{
    class Employee
    {
        public string Name { get; private set; }
        public int Salary { get; private set; }

        public Employee(string name,int salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        public static bool Compare(Employee e1,Employee e2)
        {
            if (e1.Salary > e2.Salary) return true;
            return false;
        }

        public override string ToString()
        {
            return Name + ":" + Salary;
        }
    }
}
