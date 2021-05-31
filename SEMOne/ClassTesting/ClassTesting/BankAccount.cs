using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTesting
{
    class BankAccount
    {
        //Variables
        private int account_Number;
        public int accountNumber
        {
            get
            {
                return account_Number;
            }

            set
            {
                account_Number = value;
            }
        }

        private double account_Balance;
        public double accountBalance
        {
            get
            {
                return account_Balance;
            }

            set
            {
                account_Balance = value;
            }
        }

        private string account_name;
        public string accountName
        {
            get
            {
                return account_name;
            }

            set
            {
                account_name = value;
            }
        }

        public BankAccount(int accountNumber,string accountName, double accountBalance)
        {
            account_Number = 0;
            account_name = "";
            account_Balance = 0;

            account_Number = accountNumber;
            account_name = accountName;
            account_Balance = accountBalance;
        }

        public void Display()
        {
            Console.WriteLine("Account Number:" + accountNumber);
            Console.WriteLine("Account Name:" + accountName);
            Console.WriteLine("Account Balance:" + accountBalance);
        }

        public void Deposit(int amount)
        {
            Console.WriteLine("Deposit:" + amount);
            accountBalance += amount;
            Console.WriteLine("New Balance:" + accountBalance);
            Console.ReadKey();
        }
    }
}
