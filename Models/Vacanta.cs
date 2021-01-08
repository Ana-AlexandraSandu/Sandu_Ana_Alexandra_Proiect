using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//folosit pentru constrangeri sau valori predefinite
using System.ComponentModel.DataAnnotations.Schema; 

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Vacanta
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]

        [Display(Name = "Locatie Vacanta")]
        public string Tara { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Categorie { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        
        [Range(1, 3000)]
        [DataType(DataType.Currency)]

        public decimal Pret { get; set; }

        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dataplecare { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datasosire { get; set; }
        public int GhidID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Numele trebuie sa fie de forma 'Prenume Nume'"), StringLength(50, MinimumLength = 3)]
        public Ghid Ghid { get; set; }
        public ICollection<CategorieVacanta> CategoriiVacanta { get; set; }//relatie 1 to M cu CategorieVacanta


    }
}
