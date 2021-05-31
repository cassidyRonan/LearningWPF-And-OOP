using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCashRegister
{
    class CashRegister
    {
        //Static Variables
        public static decimal overallTotal = 0;
        public static int overallItems = 0;


        //Local Variables
        private decimal total;
        public decimal Total
        {
            get
            {
                return this.total;
            }
        }

        private int quantity = 0;
        public decimal Quantity
        {
            get
            {
                return this.quantity;
            }
        }




        public void AddItem(decimal price)
        {
            total += price;
            overallTotal += price;

            quantity++;
            overallItems++;

            Console.WriteLine($"Adding an item worth {price}.");
        }

        public void Display()
        {
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Number of Items: {quantity}");
        }

    }
}
