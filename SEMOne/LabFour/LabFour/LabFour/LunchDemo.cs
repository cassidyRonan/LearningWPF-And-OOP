using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabFour
{
    class LunchDemo
    {
        static void Main(string[] args)
        {
            //Lunch Objects
            Lunch Hamburger = new Lunch("Hamburger", "Fries", "Cola");
            Lunch HotDog = new Lunch("Hot Dog", "Chips", "Lemonade");
            Lunch Pizza = new Lunch("Pizza", "Salad", "Iced Tea");
            Lunch Tuna = new Lunch("Tuna Sandwhich", "Fruit Cup", "Water");
            Lunch PBSandwich = new Lunch("Peanut Butter Sandwich", "Cookie", "Milk");

            //Output
            Console.WriteLine("{0,-23}{1,-12}{2,-9}","Entree","Side","Drink");
            Display(Hamburger);
            Display(HotDog);
            Display(Pizza);

            Console.WriteLine("\n{0,-23}{1,-12}{2,-9}", "Entree", "Side", "Drink");
            Display(Hamburger);
            Display(HotDog);
            Display(Pizza);
            Display(Tuna);

            Console.WriteLine("\n{0,-23}{1,-12}{2,-9}", "Entree", "Side", "Drink");
            Display(Hamburger);
            Display(HotDog);
            Display(Pizza);
            Display(Tuna);
            Display(PBSandwich);


            Console.ReadKey();
            
        }

        static void Display(Lunch input)
        {
            Console.WriteLine("{0,-23}{1,-12}{2,-9}",input.Entree,input.SideDish,input.Drink);
        }
    }
}
