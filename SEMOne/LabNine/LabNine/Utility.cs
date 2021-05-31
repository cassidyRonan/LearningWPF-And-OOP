using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabNine
{
    class Utility
    {
        static public Random rnd = new Random();

        static public int RandomNext(int max)
        {
            return rnd.Next(max);
        }

        static public int RandomNext(int min,int max)
        {
            return rnd.Next(min,max);
        }
    }
}
