using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [StringLength(60,MinimumLength =2)]
        public string Title { get; set; }
        [Display(Name ="Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string Genre { get; set; }

        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
        public bool InCinema { get; set; }

       // [EnumDataType(typeof(AgeLevel))]
        public AgeLevel Age { get; set; }
    }

    public enum AgeLevel { Zero=0,Five=5, Ten=10, Twenty=20}

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set;}
    }
}