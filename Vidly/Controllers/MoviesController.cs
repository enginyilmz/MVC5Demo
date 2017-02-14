using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }

        public ActionResult Create()
        {
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = GetGenres()
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = GetGenres()
            };

            return View("MovieForm", viewModel);
        }

        private static string[] GetGenres()
        {
            return new[] {"Action","Thriller","Family","Romance","Comedy" };
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            //else
            //{
            //    var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

            //    movieInDb.Name = movie.Name;
            //    movieInDb.Genre = movie.Genre;
            //    movieInDb.NumberInStock = movie.NumberInStock;
            //    movieInDb.ReleaseDate = movie.ReleaseDate;
            //    //movieInDb.DateAdded = DateTime.Now;
            //}

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            
            return RedirectToAction("Index", "Movies");
        }
    }
}