using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;//folosit pentru constrangeri sau valori predefinite
using System.ComponentModel.DataAnnotations.Schema;

namespace Sandu_Ana_Alexandra_Proiect.Models
{
    public class Ghid
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Numele trebuie sa fie de forma 'Prenume Nume'"), StringLength(50, MinimumLength = 3)]
        public string NumeGhid { get; set; }
        public int Telefon { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dataangajare { get; set; }
        public ICollection<Vacanta> Vacante { get; set; }
    }
}
