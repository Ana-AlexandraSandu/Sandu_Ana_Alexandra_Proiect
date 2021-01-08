using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class CategorieVacanta
    {
        public int ID { get; set; }
        public int VacantaID { get; set; }
        public Vacanta Vacanta { get; set; }
        public int CategorieID { get; set; }
        public Categorie Categorie { get; set; }
    }
}
