using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };
            var outputNumbers =
                from number in numbers
                where number > 5
                orderby number descending
                select number;

            //var outputNumbers = numbers
            //    .Where(n => n > 5)
            //    .OrderBy(n => n);

            foreach (var number in outputNumbers)
            {
                Console.WriteLine(number.ToString());
            }

            Console.ReadKey();

        }
    }
}
