using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTen
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = GetCustomers().Where(n => n.City == "Dublin" || n.City == "Galway").OrderBy(n => n);

            foreach (var item in query)
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

    class Customer: IComparable
    {
        public string Name;
        public string City;

        public int CompareTo(object obj)
        {
            var customer = obj as Customer;
            return Name.CompareTo(customer.Name);
        }

        public override string ToString()
        {
            return string.Format($"Name:{Name} \tCity:{City}");
        }
    }
}
