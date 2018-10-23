using MovieApp.Models;
using MovieApp.Services;
using MovieApp.ViewModels;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieService _service;

        public MoviesController()
        {
            _service = new MovieService();
        }

        // GET: Movie
        public ActionResult Index()
        {
            var movies = _service.GetMovies();
            return View(movies);
        }

        public ActionResult New()
        {
            var genres = _service.GetGenres();
            var viewModel = new MovieViewModel
            {
                Genres = genres,
                Heading = "New Movie",
                Movie = new Movie()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _service.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieViewModel
            {
                Genres = _service.GetGenres(),
                Movie = movie,
                Heading = "Edit Movie"
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            var movieId = movie.Id;

            if (movieId == 0)
                _service.AddMovie(movie);

            _service.UpdateMovie(movie);

            return RedirectToAction("Index");
        }
    }
}