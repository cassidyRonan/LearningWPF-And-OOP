using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabThree
{
    class Flight
    {
        public string airlineName;
        public int flightNumber;
        public int row;
        public char seat;

        public void Display()
        {
            Console.WriteLine($"The flight is #{flightNumber} on {airlineName}.");
            Console.WriteLine($"Row {row} Seat {seat}.");
            Console.Write("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
