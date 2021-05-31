using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryOp del1 = new BinaryOp(SimpleMaths.Add);
            BinaryOp del2 = new BinaryOp(SimpleMaths.Subtract);

            del1 += del2;

            DoWork(del1);

            Console.ReadLine();
        }

        static void DoWork(BinaryOp del)
        {
            del(20, 10);
        }
    }

   

}
