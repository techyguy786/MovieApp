using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public Movie()
        {
            ReleaseDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}