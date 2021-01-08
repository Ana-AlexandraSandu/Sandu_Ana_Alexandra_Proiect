using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Ghid
    {
        public int ID { get; set; }
        public string NumeGhid { get; set; }
        public int Telefon { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dataangajare { get; set; }
        public ICollection<Vacanta> Vacante { get; set; }
    }
}
