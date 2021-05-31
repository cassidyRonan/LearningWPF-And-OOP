using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne_Console
{
    public delegate void BinaryOp(int x, int y);

    public class SimpleMaths
    {
        public static void Add(int a, int b)
        {
            Console.WriteLine($"The sum of {a} and {b} is {a + b}");
        }

        public static void Subtract(int a, int b)
        {
            Console.WriteLine($"The result of {a} - {b} is {a - b}");
        }
    }
}
