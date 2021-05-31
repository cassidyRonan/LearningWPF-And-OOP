using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            School[] schoolList = new School[5];

            for (int i = 0; i < schoolList.Length; i++)
            {
                schoolList[i] = new School();
                EnterInfo(schoolList[i]);
            }

            PrintData(schoolList);
            Array.Sort(schoolList);
            Console.WriteLine("\nOrdered");
            PrintData(schoolList);

            Console.ReadKey();
        }

        static void EnterInfo(School schoolObj)
        {
            Console.Write("Enter School Name: ");
            schoolObj.schoolName = Console.ReadLine();

            Console.Write("Enter Enrollment: ");
            schoolObj.schoolStudentNumbers = int.Parse(Console.ReadLine());
        }

        static void PrintData(School[] list)
        {
            foreach (var school in list)
            {
                Console.WriteLine($"{school.schoolName} has {school.schoolStudentNumbers} students.");
            }
        }
    }
}
