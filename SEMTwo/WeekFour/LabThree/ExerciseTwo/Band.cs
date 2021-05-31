using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTwo
{
    public class Band
    {
        public string BandName { get; set; }
        public string imageURL { get; set; }

        public Band(string name, string imageUrl)
        {
            BandName = name;
            imageURL = imageUrl;
        }

        public override string ToString()
        {
            return BandName;
        }
    }
}
