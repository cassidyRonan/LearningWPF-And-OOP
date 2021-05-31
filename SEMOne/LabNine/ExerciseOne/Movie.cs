using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseOne
{
    class Movie
    {
        //Variables
        public string Title { get; set; }
        public enum Genre {Action,Adventure,War,Drama,Thriller,Fantasy,SciFi,Animated,Unknown};
        public Genre Type { get; set; }
        public int Rating { get; set; }

        #region Constructors
        public Movie(): this("Movie", Genre.Unknown, 0)
        {
        }

        public Movie(string title) : this(title,Genre.Unknown,0)
        {
        }

        public Movie(string title, Genre genre) : this(title, genre, 0)
        {
        }

        public Movie(string title, Genre genre, int rating)
        {
            Title = title;
            Type = genre;
            Rating = rating;
        }
        #endregion

        //Override
        public override string ToString()
        {
            return string.Format(Title + ", " + Type.ToString() + ", " + Rating + " Stars");
        }

        //Methods
        static public Genre GenreConvert(string toConvert)
        {
            Genre convert;
            if (!Enum.TryParse(toConvert, out convert))
                convert = Movie.Genre.Unknown;
            return convert;
        }
    }
}
