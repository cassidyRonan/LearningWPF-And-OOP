using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSeven
{
    abstract class Game
    {
        //Variables
        public readonly string Name;
        protected decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }

        //Constructors
        public Game(string name,decimal price,DateTime releaseDate)
        {
            Name = name;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public Game(string name, decimal price) : this(name, price, DateTime.Now)
        {
        }

        public Game() : this("", 0)
        {
        }

        //Methods
        public abstract void UpdatePrice(decimal percentageIncrease);

        //public override string ToString()
        //{
        //    return string.Format($"Name: {Name}   Price: {Price}   Release Date: {ReleaseDate.ToShortDateString()}");
        //}

        //abstract public virtual void UpdatePrice(decimal percentageIncrease)
        //{
        //    Price *= (1 + percentageIncrease);
        //}
    }

    class ComputerGame : Game
    {
        //Variables
        public string PEGI;

        //Constructors
        public ComputerGame(string name, decimal price, DateTime releaseDate, string pegi) : base(name,  price,  releaseDate)
        {
            PEGI = pegi;
        }

        public ComputerGame(string name, decimal price, string pegi) : this(name, price, DateTime.Now,pegi)
        {
        }

        public ComputerGame(string name, decimal price) : this(name, price, DateTime.Now, "Unrated")
        {
        }

        //Methods
        public override string ToString()
        {
            return base.ToString() + $"  PEGI:{PEGI}";
        }

        public decimal GetDiscountPrice()
        {
            return Price * .9m;
        }

        public override void UpdatePrice(decimal percentageIncrease)
        {
            Price *= (1 + percentageIncrease);
            Console.WriteLine($"Price updated to {Price}");
        }
    }
}
