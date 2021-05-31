using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight TestFlight = new Flight();

            TestFlight.airlineName = "United Airlines";
            TestFlight.flightNumber = 489;
            TestFlight.row = 14;
            TestFlight.seat = 'C';

            TestFlight.Display();
        }
    }
}
