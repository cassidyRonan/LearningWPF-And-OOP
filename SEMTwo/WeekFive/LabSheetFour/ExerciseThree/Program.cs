using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car("SlugBug", 100, 10);

            c1.AboutToBlow += OnCarEngineEvent;
            c1.Exploded += OnCarEngineEvent;

            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.ReadLine();
        }

        static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("Message from Car Object\n");
            Console.WriteLine(msg);
            Console.WriteLine("******************************");
        }

        static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine(msg.ToUpper());
        }
    }
}
