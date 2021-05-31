using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSixQuestionTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Book bk = new Book("123AB", "Adventure", "Benji Bardle", 20.30m);
            TextBook TxMisadventure = new TextBook("456AB", "Misadventure", "Benji Bardle", 90.30m,"2017");
            TextBook TxBegin = new TextBook("124DE", "Begin", "Michael Bardle", 20.30m, "2017");
            TextBook Txbk = new TextBook("124DE", "Begin", "Michael Bardle", 10.30m, "2017");
            CoffeeTableBook CTB = new CoffeeTableBook("1111", "Nalt", "Barnable Joe", 50.56m);
            CoffeeTableBook CTBook = new CoffeeTableBook("1111", "Nalt", "Barnable Joe", 300.56m);
            CoffeeTableBook CTBk = new CoffeeTableBook("1111", "Nalt", "Barnable Joe", 20.56m);

            Book[] books = { bk, TxBegin, Txbk, TxMisadventure, CTBook, CTB, CTBk };

            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.ReadKey();
        }
    }
}