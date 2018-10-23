using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieApp.Services
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies
                .Include(x => x.Genre)
                .ToList();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == id);
        }

        public void AddMovie(Movie movie)
        {
            movie.DateAdded = DateTime.Now;
            //_context.Movies.Add(movie);
            _context.Entry(movie).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}