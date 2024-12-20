using System;
using System.ComponentModel.DataAnnotations; 

namespace MovieCatalog.Models
{
    public class Movie : BaseEntity
    {
        [Required(ErrorMessage = "Название фильма обязательно.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Дата выхода обязательна.")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Бюджет обязателен.")]
        [Range(0.01, 1000000000, ErrorMessage = "Бюджет должен быть положительным числом.")]
        public decimal Price { get; set; }

        public Movie()
        {
        }

        public Movie(int id, string title, string genre, DateTime releaseDate, decimal price)
        {
            Id = id;
            Title = title;
            Genre = genre;
            ReleaseDate = releaseDate;
            Price = price;
        }
    }
}
