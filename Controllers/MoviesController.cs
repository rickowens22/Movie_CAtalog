using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MovieCatalog.Models;

namespace MovieCatalog.Controllers
{
    public class MoviesController : Controller
    {
        private readonly string filePath;
        private List<Movie> movies;

        public MoviesController()
        {
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MovieCatalog");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            filePath = Path.Combine(directory, "movies.json");

            if (System.IO.File.Exists(filePath))
            {
                var jsonData = System.IO.File.ReadAllText(filePath);
                movies = JsonSerializer.Deserialize<List<Movie>>(jsonData) ?? new List<Movie>();
            }
            else
            {
                movies = new List<Movie>();
                SaveToFile();
            }
        }

        public IActionResult Index()
        {
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = movies.Any() ? movies.Max(m => m.Id) + 1 : 1;
                movies.Add(movie);
                SaveToFile();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

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
                SaveToFile();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            movies.Remove(movie);
            SaveToFile();
            return RedirectToAction("Index");
        }

        private void SaveToFile()
        {
            var jsonData = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, jsonData);
        }
    }
}
