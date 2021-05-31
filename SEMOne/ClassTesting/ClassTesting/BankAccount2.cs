using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTesting
{
    public class BankAccount
    {               //Class declaration

        private int _accountNumber;         //Declare private properties
        private string _accountHolder;
        private double _balance;

        public BankAccount(int AccountNumber, string AccountHolder, double Balance) //Constructor - parameterized to initialize properties in new Bank Account object and enable short syntax for creating new objects
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolder = AccountHolder;
            this.Balance = Balance;
        }

        public BankAccount()                     //Constructor - for new objects with no parameters passed
        {
        }

        public int AccountNumber
        {
            get { return _accountNumber; }      //Auto-implemented Property - so we don't need full getter/setter syntax
            set { _accountNumber = value; }
        }

        public string AccountHolder
        {
            get { return _accountHolder; }
            set { _accountHolder = value; }
        }

        public double Balance
        {
            get { return _balance; }
            set                                 //Setter with validation code to ensure no balance of less than zero is entered
            {
                if (value > 0)
                {
                    this._balance = value;
                }
                else
                {
                    this._balance = 0;
                }
            }
        }

        public void DisplayAccounts()           //Method to Display Account details  - called from Main - e.g. ba1.DisplayAccounts();
        {										// NOTE - .NETFiddle didn't like $" {AccountNumber}" syntax so used + here
            Console.WriteLine("BankAccount Number: " + AccountNumber +
                "\nAccount Holder: " + AccountHolder +
                "\nBalance: " + Balance + "  \n");
        }

        public void Deposit(double amount)      //Method to add deposit amount to Balance - called from Main or other methods/classes - e.g. ba1.Deposit(50);
        {
            Balance += amount;
            Console.WriteLine("Deposit Confirmed - Amount:  " + amount + "\n______________________________________");
            DisplayAccounts();
        }

        public void Withdraw(double amount)     //Method to add withdraw amount from Balance - called from Main or other methods/classes - e.g. ba1.Withdraw(100);
        {
            Balance -= amount;
            Console.WriteLine("Withdrawal Confirmed - Amount:  " + amount + "\n______________________________________");
            DisplayAccounts();
        }


    }

    public class KidsAccount : BankAccount
    {
        public KidsAccount()
        {
        }

        public KidsAccount(int AccountNumber, string AccountHolder, double Balance) //Constructor - parameterized to initialize properties in new Bank Account object and enable short syntax for creating new objects
        {
            this.AccountNumber = AccountNumber;
            this.AccountHolder = AccountHolder;
            this.Balance = Balance;
        }
    }
}


