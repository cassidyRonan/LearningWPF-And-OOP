using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassTesting;

namespace ClassTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount BA1 = new BankAccount(245006,"Ronan",200.50);
            //BankAccount BA2 = new BankAccount();
            //BA1.accountNumber = 245006;
            //BA1.accountName = "Ronan";
            //BA1.accountBalance = 200.00;

            BA1.Display();

            BA1.Deposit(240);

            Console.ReadKey();
        }
    }
}
