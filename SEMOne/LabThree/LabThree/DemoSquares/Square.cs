using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquares
{
    class Square
    {
        private int area = 0;
        public int Area
        {
            get
            {
                return area;
            }
        }

        private int length = 0;
        public int Length
        {
            get
            {
                return length;
            }
        }

        public Square(int sqLength)
        {
            length = sqLength;
            area = CalculateArea(length);
            Display();

        }

        private int CalculateArea(int squareLength)
        {
            squareLength *= squareLength;
            return squareLength;
        }

        private void Display()
        {
            Console.WriteLine($"The area of a {Length} by {Length} square is {Area}");
        }
    }
}
