using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Dog doggo = new Dog();

            animal.Greet();
            doggo.Greet();

            Console.ReadKey();
        }
    }
}
