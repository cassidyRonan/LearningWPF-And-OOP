using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int cashRegisterChoice = 1;
            decimal priceInput = 0;

            CashRegister CR1 = new CashRegister();
            CashRegister CR2 = new CashRegister();

            ////Process
            //while (cashRegisterChoice == 1 || cashRegisterChoice == 2)
            //{
            //    Console.WriteLine("Exit by entering a value other than 1 or 2.");
            //    Console.Write("Please choose a cash register: ");
            //    cashRegisterChoice = int.Parse(Console.ReadLine());

            //    if(cashRegisterChoice == 1 || cashRegisterChoice == 2)
            //    {
            //        Console.Write("Please enter amount: ");
            //        priceInput = decimal.Parse(Console.ReadLine());

            //    }

            //    switch (cashRegisterChoice)
            //    {
            //        case 1:
            //            CR1.AddItem(priceInput);
            //            break;

            //        case 2:
            //            CR2.AddItem(priceInput);
            //            break;

            //        default:
            //            break;
            //    }
            //    Console.WriteLine();
            //}

            AddItems(CR1, CR2);

            Console.WriteLine("Cash Register 1:");
            Console.WriteLine($"Total: {CR1.Total}  Number of Items:{CR1.Quantity}");

            Console.WriteLine("\nCash Register 2:");
            Console.WriteLine($"Total: {CR2.Total}  Number of Items:{CR2.Quantity}");

            Console.WriteLine($"\nOverall Total: {CashRegister.overallTotal}");
            Console.WriteLine($"Overall Quantity: {CashRegister.overallItems}");

            Console.ReadKey();

        }

        static void AddItems(CashRegister cr, CashRegister cr2)
        {
            cr.AddItem(12.06m);
            cr.AddItem(1.21m);
            cr.AddItem(3.72m);
            cr.AddItem(8.50m);

            Console.WriteLine("Added item worth 12.06 to Cash Register 1.");
            Console.WriteLine("Added item worth 1.21 to Cash Register 1.");
            Console.WriteLine("Added item worth 3.72 to Cash Register 1.");
            Console.WriteLine("Added item worth 8.50 to Cash Register 1.");

            cr2.AddItem(20.99m);
            cr2.AddItem(0.50m);
            cr2.AddItem(2.29m);
            cr2.AddItem(6.84m);

            Console.WriteLine("Added item worth 20.99 to Cash Register 1.");
            Console.WriteLine("Added item worth 0.50 to Cash Register 1.");
            Console.WriteLine("Added item worth 2.29 to Cash Register 1.");
            Console.WriteLine("Added item worth 6.84 to Cash Register 1.");
        }
    }
}
