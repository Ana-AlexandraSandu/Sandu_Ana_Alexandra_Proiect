using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//folosit pentru constrangeri sau valori predefinite
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string NumeCategorie { get; set; }
        public ICollection<CategorieVacanta> CategoriiVacanta { get; set; }//relatie 1 to M cu CategorieVacanta


    }
}
