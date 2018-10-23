using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public string Heading { get; set; }
        public Movie Movie { get; set; }
    }
}