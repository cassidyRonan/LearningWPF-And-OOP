using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();

            Console.ReadKey();
        }

        #region Menu
        static void Menu()
        {
            Console.WriteLine("Choose an option:");
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine($"{i }.Question {i }");
            }
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    QuestionOne();
                    break;

                case 2:
                    QuestionTwo();
                    break;

                case 3:
                    QuestionThree();
                    break;

                case 4:
                    QuestionFour();
                    break;

                case 5:
                    QuestionFive();
                    break;

                case 6:
                    QuestionSix();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }

            Console.ReadKey();
        }
        #endregion Menu

        //Question One
        static void QuestionOne()
        {
            Console.Write("Please Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine(AgeCheck(age)); 
        }

        static bool AgeCheck(int userAge)
        {
            bool access = false;

            if(userAge >= 18 && userAge <= 21)
            {
                access = true;
            }

            return access;
        }

        //Question Two
        static void QuestionTwo()
        {
            Console.Write("Please Enter Product Name: ");
            string productName = Console.ReadLine();
            Console.WriteLine(PriceCheck(productName));
        }

        static double PriceCheck(string product)
        {
            double productPrice = 0.0;
            product = product.ToUpper();

            switch (product)
            {
                case "JEANS":
                    productPrice = 67.99;
                    break;

                case "JACKET":
                    productPrice = 68.99;
                    break;

                case "BOOTS":
                    productPrice = 34.99;
                    break;

                case "SCARVES":
                case "BELTS":
                case "SOCKS":
                    productPrice = 10.0;
                    break;

                default:
                    productPrice = -999;
                    break;
            }

            return productPrice;
        }

        //QuestionThree
        static void QuestionThree()
        {
            int[] example = { 24, 50, 49, 21, 88, 100 };
            foreach (var item in example)
            {
                Console.Write(item + ",");
            }

            Zero(example);

            foreach (var item in example)
            {
                Console.Write(item + ",");
            }

        }

        static void Zero(int[] argArray)
        {
            for (int i = 0; i < argArray.Length; i++)
            {
                argArray[i] = 0;
            }
            Console.WriteLine("Converted");
        }

        //Question Four
        static void QuestionFour()
        {
            Console.Write("Please enter first number: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Please enter second number: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Total: " + Sum(num1,num2));
        }

        static int Sum(int n1, int n2)
        {
            int total = 0;

            while(n1 <= n2)
            {
                if (n1 % 2 == 0)
                {
                    total += n1;
                }

                n1++;
            }

            return total;
        }

        //Question Five
        static void QuestionFive()
        {
            int storeStock = 25;

            Console.WriteLine("Store Stock:"  + storeStock);

            Console.Write("Sales Amount: ");
            int sales = int.Parse(Console.ReadLine());
            StockCheck(ref storeStock, sales);
            Console.WriteLine("Store Stock:" + storeStock);
        }

        static bool StockCheck(ref int stock, int sales)
        {
            bool stockUpdated = false;

            if(sales <= stock)
            {
                stock -= sales;
                stockUpdated = true;
            }

            return stockUpdated;
        }

        //Question Six
        static void QuestionSix()
        {
            //Variables
            string lineReadIn = "";
            string[] data = new string[2];
            string message;

            const string FORMAT = "{0,10}{1,20}{2,30}";
            //const string FORMAT_TITLE = "{0,-0}{1,15}";

            int Sales = 0;
            int totalSales = 0;
            int counter = 0;

            //File Read
            FileStream fs = new FileStream(@"sales.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine("Sales Report");
            Console.WriteLine(FORMAT,"Store ID", "Sales","Performance");

            lineReadIn = sr.ReadLine();

            do
            {
                data = lineReadIn.Split(',');
                Sales = int.Parse(data[1]);

                if (Sales < 1000)
                {
                    message = "Needs attention";
                }
                else if (Sales < 2000 && Sales >= 1000)
                {
                    message = "Moderate";
                }
                else if(Sales > 2000)
                {
                    message = "Very good";
                }
                else
                {
                    message = "Error";
                }

                totalSales += Sales;
                counter++;
                Console.WriteLine(FORMAT,data[0],data[1],message);

                lineReadIn = sr.ReadLine();
            }
            while (lineReadIn != null);

            Console.WriteLine("Total Sales: " + totalSales);
            Console.WriteLine("Average Sales: " + (totalSales/counter) );
            
        }
    }
}
