using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }
        public ICollection<CategorieVacanta> CategoriiVacanta { get; set; }//relatie 1 to M cu CategorieVacanta


    }
}
