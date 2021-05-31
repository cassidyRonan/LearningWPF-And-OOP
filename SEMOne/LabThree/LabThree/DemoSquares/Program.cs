using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] sqObj = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //for (int i = 1; i <= sqObj.Length; i++)
            //{
            //    Square SQ = new Square(i); 
            //}

            Square[] sqObj = new Square[10];
            for (int i = 0; i < sqObj.Length; i++)
            {
                sqObj[i] = new Square((i) + 1);
            }

            Console.ReadKey();
        }
    }
}
