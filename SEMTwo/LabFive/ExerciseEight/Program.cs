using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEight
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query1 = names
                        .Where(n => n.ToUpper()[0] == 'M');

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
