using System;
using System.Collections.Generic;
using System.Linq;
using MovieCatalog.Models;

namespace MovieCatalog.Services
{
    public class MovieService : BaseService<Movie>
    {
        private readonly List<Movie> movies = new List<Movie>();

        public MovieService()
        {
            movies.Add(new Movie(1, "Побег из Шоушенка", "Драма", new DateTime(1994, 9, 23), 9.99m));
            movies.Add(new Movie(2, "Крестный отец", "Криминал", new DateTime(1972, 3, 24), 14.99m));
            movies.Add(new Movie(3, "Темный рыцарь", "Приключения", new DateTime(2008, 7, 18), 12.99m));
        }

        public override IEnumerable<Movie> GetAll()
        {
            return movies;
        }

        public override Movie GetById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public override void Add(Movie movie)
        {
            int newId = movies.Any() ? movies.Max(m => m.Id) + 1 : 1;
            movie.Id = newId;
            movies.Add(movie);
        }

        public override void Update(Movie movie)
        {
            var existing = GetById(movie.Id);
            if (existing == null)
                throw new ArgumentException($"Movie with Id={movie.Id} does not exist.");

            existing.Title = movie.Title;
            existing.Genre = movie.Genre;
            existing.ReleaseDate = movie.ReleaseDate;
            existing.Price = movie.Price;
        }

        public override void Delete(int id)
        {
            var movie = GetById(id);
            if (movie == null)
                throw new ArgumentException($"Cannot delete. Movie with Id={id} does not exist.");
            
            movies.Remove(movie);
        }
    }
}
