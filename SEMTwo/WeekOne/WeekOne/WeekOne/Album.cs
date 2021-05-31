using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOne
{
    class Album
    {
        static public Random rnd = new Random();

        public string AlbumName { get; private set; }
        public DateTime Release { get; private set; }
        public int yearsSinceRelease { get; private set; }
        public int Sales { get; private set; }
        public Band bnd { get; private set; }

        public Album(string albumName,int yearReleased)
        {
            AlbumName = albumName;
            Release = new DateTime(yearReleased, 1, 1);
            yearsSinceRelease = rnd.Next(Release.Year,DateTime.Now.Year) - Release.Year;
            Sales = rnd.Next(1,34000000);
        }

        public override string ToString()
        {
            return string.Format($"{AlbumName}\tReleased {yearsSinceRelease} years ago\t{Sales}");
        }
    }
}
