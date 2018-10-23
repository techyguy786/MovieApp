using AutoMapper;
using MovieApp.DTOs;
using MovieApp.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace MovieApp.Controllers.api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList()
                .Select(Mapper.Map<Movie, MovieDTO>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id),
                movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            Mapper.Map<MovieDTO, Movie>(movieDto, movie);
            //movie.Name = movieDto.Name;
            //movie.DateAdded = movieDto.DateAdded;
            //movie.ReleaseDate = movieDto.ReleaseDate;
            //movie.GenreId = movieDto.GenreId;
            //movie.NumberInStock = movieDto.NumberInStock;

            _context.SaveChanges();
            return Ok(movie);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);
        }
    }
}
