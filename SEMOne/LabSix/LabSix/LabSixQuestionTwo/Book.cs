using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSixQuestionTwo
{
    class Book
    {
        //Variables
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        protected decimal price;
        public virtual decimal Price { get { return price; }  set { price = value; } }

        //Constructors
        public Book()
        {
        }

        public Book(string isbn, string title, string author, decimal price)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            Price = price;
        }

        public override string ToString()
        {
            return string.Format($"ISBN:{ISBN}  Title:{Title}  Author:{Author}  Price:{Price}  Type: {GetType().Name}");
        }
    }

    class TextBook : Book
    {
        public string StudentYear { get; private set; }
        public override decimal Price
        {
            get { return price; }

            set
            {
                if (value >= 20 && value <= 80)
                {
                    price = value;
                }
                
            }
        }

        public TextBook(string isbn, string title, string author, decimal price,string studentYear): base(isbn,title,author,price)
        {
            StudentYear = studentYear;
        }

        public override string ToString()
        {
            return base.ToString() + $"  Student Year:{StudentYear}";
        }
    }

    class CoffeeTableBook : Book
    {
        public override decimal Price
        {
            get { return price; }
            set
            {
                if (value >= 35 && value <= 100)
                {
                    price = value;
                }

            }
        }

        public CoffeeTableBook(string isbn, string title, string author, decimal price) : base(isbn, title, author, price)
        {
            
        }
    }
}
