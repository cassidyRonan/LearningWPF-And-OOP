using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTesting
{
    class Program
    {
        public static void Main(string[] args)			//.NETFiddle required Public Main()
        {


            BankAccount ba1 = new BankAccount();       //Create new object ba1 from BankAccount class
            ba1.AccountNumber = 1;                     //Populate property values
            ba1.AccountHolder = "Mary";
            ba1.Balance = 1000;

            BankAccount ba2 = new BankAccount();
            ba2.AccountNumber = 2;
            ba2.AccountHolder = "Ian";
            ba2.Balance = -20;

            BankAccount ba3 = new BankAccount(3, "Keith", 2000);     //Once we add Constructor, we can create object using this shortened syntax

            KidsAccount Kiddo = new KidsAccount();
            Kiddo.AccountNumber = 1;
            Kiddo.AccountHolder = "Kiddos";
            Kiddo.Balance = 0.01;

            KidsAccount Kids = new KidsAccount(3, "Kids", 2000);


            ba1.DisplayAccounts();  //Call DisplayAccounts method for object ba1
            ba2.DisplayAccounts();
            ba3.DisplayAccounts();
            Kiddo.DisplayAccounts();
            Kids.DisplayAccounts();

            ba1.Deposit(50);        //Call Deposit & Withdrawal methods - passing amounts
            ba2.Deposit(100);
            ba3.Withdraw(100);
            Kiddo.Deposit(20);
            Kids.Withdraw(1000);


            Console.ReadLine();


        }
    }
}
