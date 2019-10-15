using System;

namespace HighLevel
{
    class Program
    {
        static void CommonSort<T>(T[] sortArray, Func<T,T,bool> compareMethod)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Length - 1; i++)
                {
                    if (compareMethod(sortArray[i],sortArray[i + 1]))
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        static void Main(string[] args)
        {
            Employee[] employees = new Employee[]
            {
                new Employee("gh",35),
                new Employee("re",65),
                new Employee("df",24),
                new Employee("yhu",58),
                new Employee("fg",124),
                new Employee("fc",69)
            };
            CommonSort<Employee>(employees, Employee.Compare);
            foreach(Employee em in employees)
            {
                Console.WriteLine(em.ToString());
            }
            Console.ReadKey();
        }
    }
}
