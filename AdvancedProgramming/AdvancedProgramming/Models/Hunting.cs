using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedProgramming.Models
{
    public class Hunting
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Miejsce Polowania")]
        public string Place { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Polowania")]
        public DateTime Date { get; set; }

        [Range(0, 99999.99)]
        [Display(Name = "Kg Mięsa")]
        public Decimal HarvestedMeat { get; set; }
        [Display(Name = "Notatka")]
        public string? Note { get; set; }
    }
}
