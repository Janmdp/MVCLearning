using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }

        public Movie(int id, string title, DateTime releaseDate, string genre, decimal price)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            Price = price;  
        }

        public Movie()
        {

        }
    }
}
