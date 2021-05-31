using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Animal
    {
        public virtual void Greet()
        {
            Console.WriteLine("Hello, I'm some sort of animal!");
        }
    }

    public class Dog : Animal
    {
        public override void Greet()
        {
            Console.WriteLine("Hello, I'm a dog!");
        }
    }
}
