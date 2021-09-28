using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedProgramming.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Premiery")]
        public DateTime ReleaseDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data zobaczenia")]
        [Required]
        public DateTime WatchDate { get; set; }

        [StringLength(25)]
        [Display(Name = "Gatunek")]
        public string? Genre { get; set; }
        [Range(0, 10)]
        [Display(Name = "Ocena")]
        public int Rating { get; set; }
        [Display(Name = "Notatka")]
        public string? Note { get; set; }
    }
}
