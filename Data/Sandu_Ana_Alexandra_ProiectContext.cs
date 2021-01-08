using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sandu_Ana_Alexandra_Proiect.Models;

namespace Sandu_Ana_Alexandra_Proiect.Data
{
    public class Sandu_Ana_Alexandra_ProiectContext : DbContext
    {
        public Sandu_Ana_Alexandra_ProiectContext (DbContextOptions<Sandu_Ana_Alexandra_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Sandu_Ana_Alexandra_Proiect.Models.Vacanta> Vacanta { get; set; }

        public DbSet<Sandu_Ana_Alexandra_Proiect.Models.Ghid> Ghid { get; set; }

        public DbSet<Sandu_Ana_Alexandra_Proiect.Models.Categorie> Categorie { get; set; }
    }
}
