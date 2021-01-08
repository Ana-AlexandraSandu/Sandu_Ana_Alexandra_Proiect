using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class DateVacanta
    {
        public IEnumerable<Vacanta> Vacante { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieVacanta> CategoriiVacanta { get; set; }
    }
}
