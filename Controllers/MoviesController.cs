using Microsoft.AspNetCore.Mvc;
using MovieCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieCatalog.Controllers
{
    public class MoviesController : Controller
    {
        // Статический список фильмов, чтобы изменения сохранялись между запросами
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "The Shawshank Redemption", Genre = "Drama", ReleaseDate = new DateTime(1994,9,23), Price = 9.99m },
            new Movie { Id = 2, Title = "The Godfather", Genre = "Crime", ReleaseDate = new DateTime(1972,3,24), Price = 14.99m },
            new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", ReleaseDate = new DateTime(2008,7,18), Price = 12.99m }
        };

        // Отображение списка фильмов
        public IActionResult Index()
        {
            return View(movies);
        }

        // GET: Создание фильма (форма)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Создание фильма (сохранение)
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                int newId = movies.Any() ? movies.Max(m => m.Id) + 1 : 1;
                movie.Id = newId;
                movies.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Редактирование фильма (форма)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // POST: Редактирование фильма (сохранение)
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existing = movies.FirstOrDefault(m => m.Id == movie.Id);
                if (existing == null) return NotFound();

                existing.Title = movie.Title;
                existing.Genre = movie.Genre;
                existing.ReleaseDate = movie.ReleaseDate;
                existing.Price = movie.Price;

                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Удаление фильма (подтверждение)
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // POST: Удаление фильма
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            movies.Remove(movie);
            return RedirectToAction("Index");
        }
    }
}
