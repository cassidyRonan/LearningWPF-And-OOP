using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA12017
{
    class Program
    {
        //Global Variables
        const decimal TRAVEL_COST_RATE = 0.45m;
        const decimal FITTING_COST_RATE = 3.25m;


        static void Main(string[] args)
        {
            //Variables
            decimal TotalCost = 0;
            int NumOfFittings = 0;

            decimal distanceInput = 0;
            decimal carpetSize = 0;
            decimal fittingCost = 0;
            decimal averageCost = 0;

            int userInput = 1;

            
            Console.WriteLine("The Carpet Fitting Cost Calculator");
            do
            {
                Console.Write("\nEnter a 0 to End or 1 to Input another fitting detail: ");
                userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    //Inputs
                    Console.Write("Enter a distance in Kilometers: ");
                    distanceInput = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter a carpet size: ");
                    carpetSize = decimal.Parse(Console.ReadLine());

                    //Process
                    fittingCost = CalculateCosts(distanceInput, carpetSize,ref TotalCost,ref NumOfFittings);
                    fittingCost = Math.Round(fittingCost, 2);

                    //Output
                    Console.WriteLine($"Cost of Fitting: EUR {fittingCost}");
                    fittingCost = 0;
                }
                else
                {
                    averageCost = Math.Round((TotalCost / NumOfFittings),2);
                    TotalCost = Math.Round(TotalCost, 2);

                    Console.WriteLine($"Total Cost: EUR {TotalCost}");
                    Console.WriteLine($"Average Cost: EUR {averageCost}");
                }
            }
            while (userInput == 1);

            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }

        static decimal CalculateCosts(decimal distance,decimal carpet, ref decimal TotalCost, ref int numFittings)
        {
            decimal total = 0;
            total += (distance * TRAVEL_COST_RATE);
            total += (carpet * FITTING_COST_RATE);

            if(total > 250)
            {
                total -= (total / 10);
            }

            TotalCost += total;
            numFittings++;
            return total;
        }
    }
}
