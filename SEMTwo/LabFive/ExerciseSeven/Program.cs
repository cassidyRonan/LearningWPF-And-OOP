using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query1 = names
                        .OrderBy(n => n);

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
