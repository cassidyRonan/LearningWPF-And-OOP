using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            ComputerGame GM1 = new ComputerGame("Kingdom Hearts 3", 75.00m, new DateTime(2024, 12, 25),"12");
            ComputerGame GM2 = new ComputerGame("Batman", 35.00m, new DateTime(2013, 05, 21), "18");

            //Game Ex1 = new Game("Monopoly", 19.99m, new DateTime(1970, 01, 31));
            //Game Ex2 = new Game("Cluedo", 29.99m, new DateTime(1979, 11, 21));

            //Game Ex2 = new Game() { Price = 19.99m, ReleaseDate = new DateTime(2000, 6, 15) };

            //Process
            DisplayGame(GM1);
            DisplayGame(GM2);
            //DisplayGame(Ex1); No longer working due to class bein changed to abstract
            //DisplayGame(Ex2);


            //Output
            Console.WriteLine();
            Console.ReadKey();
        }

        //Methods
        static void DisplayGame(Game game)
        {
            Console.WriteLine(game.ToString());
        }
    }
}
