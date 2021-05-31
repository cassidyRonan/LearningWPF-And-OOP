using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseNine
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GetCustomers().Where(n => n.City == "Dublin"))
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }

        private static List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer {Name="Tom", City="Dublin" },
                new Customer {Name="Sally", City="Galway" },
                new Customer {Name="George", City="Cork" },
                new Customer {Name="Molly", City="Dublin" },
                new Customer {Name="Joe", City="Galway" }
            };
        }
    }

    class Customer
    {
        public string Name;
        public string City;

        public override string ToString()
        {
            return string.Format($"Name:{Name} \tCity:{City}");
        }
    }
}
