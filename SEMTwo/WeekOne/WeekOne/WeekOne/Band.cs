using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOne
{
    abstract class Band : IComparable
    {
        public string BandName { get; private set; }
        public string YearFormed { get; private set; }
        public List<string> BandMembers { get; private set; }
        public List<Album> Albums { get; private set; }

        /// <param name="bandName"></param>
        /// <param name="yearFormed"></param>
        /// <param name="bandMembers">Split names by comma.</param>
        public Band(string bandName, string yearFormed,string bandMembers,List<Album> albumList)
        {
            BandName = bandName;
            YearFormed = yearFormed;
            BandMembers = new List<string>();
            Albums = albumList;

            string[] data = bandMembers.Split(',');
            foreach (var item in data)
            {
                BandMembers.Add(item.ToString());
            }
        }

        public override string ToString()
        {
            return BandName;
        }

        public int CompareTo(object obj)
        {
            Band That = obj as Band;
            return this.BandName.CompareTo(That.BandName);
        }

        public void AddAlbum(Album album)
        {
            Albums.Add(album);
        }

        public string BandInfo()
        {
            string info = "";
            foreach (var item in BandMembers)
            {
                info += (item + ", ");
            }
            info = info.Remove(info.Length - 2,2);
            info = $"Formed: {YearFormed} \nMembers: {info}";
            return info;
        }

        
    }

    class PopBand : Band
    {
        public PopBand(string bandName, string yearFormed, string bandMembers, List<Album> albumList) : base(bandName, yearFormed, bandMembers,albumList)
        {
        }

        public override string ToString()
        {
            return string.Format(BandName + " - Pop");
        }
    }

    class RockBand : Band
    {
        public RockBand(string bandName, string yearFormed, string bandMembers, List<Album> albumList) : base(bandName, yearFormed, bandMembers, albumList)
        {
        }

        public override string ToString()
        {
            return string.Format(BandName + " - Rock");
        }
    }

    class IndieBand : Band
    {
        public IndieBand(string bandName, string yearFormed, string bandMembers, List<Album> albumList) : base(bandName, yearFormed, bandMembers, albumList)
        {
        }

        public override string ToString()
        {
            return string.Format(BandName + " - Indie");
        }
    }

    class BandSort : IComparer<Band>
    {
        public int Compare(Band x, Band y)
        {
            return string.Compare(x.BandName, y.BandName);
        }
    }
}
