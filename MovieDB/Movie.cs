using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB
{
    //------------------------------------------------------------------------------------
    public class MovieResponse
    {
        public string Response { get; set; }
    }
    //------------------------------------------------------------------------------------
    public class Movie : MovieResponse
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        //public string Poster { get; set; }
        //public List<Rating> Ratings { get; set; }
        //public string Metascore { get; set; }
        //public string imdbRating { get; set; }
        //public string imdbVotes { get; set; }
        //public string imdbID { get; set; }
        //public string Type { get; set; }

        public override string ToString()
        {
            string str = "Year:Ё " + Year + 
                "ЁRated:Ё " + Rated + 
                "ЁReleased:Ё " + Released + 
                "ЁRuntime:Ё " + Runtime + 
                "ЁGenre:Ё " + Genre + 
                "ЁDirector:Ё " + Director + 
                "ЁWriter:Ё " + Writer + 
                "ЁActors:Ё " + Actors + 
                "ЁPlot:Ё " + Plot + 
                "ЁLanguage:Ё " + Language +
                "ЁCountry:Ё " + Country + 
                "ЁAwards:Ё " + Awards
                ;

            return  str;  
        }
        
    }
    //------------------------------------------------------------------------------------
    public class SearchMovie : MovieResponse
    {
        public List<MovieShort> Search { get; set; }
    }
    //------------------------------------------------------------------------------------
    public class Rating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
    //------------------------------------------------------------------------------------
    public class MovieShort
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }

        public override string ToString() => $"{Title}, {Year}";
    }
    //------------------------------------------------------------------------------------
}
