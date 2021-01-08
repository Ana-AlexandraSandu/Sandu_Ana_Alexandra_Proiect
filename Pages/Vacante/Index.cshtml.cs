using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sandu_Ana_Alexandra_Proiect.Data;
using Sandu_Ana_Alexandra_Proiect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Sandu_Ana_Alexandra_Proiect.Pages.Vacante
{
    public class IndexModel : PageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public IndexModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Vacanta> Vacanta { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Categorie{ get; set; }
        [BindProperty(SupportsGet = true)]
        public string CategorieVacanta { get; set; }
        public DateVacanta VacantaD { get; set; }
        public int VacantaID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            VacantaD = new DateVacanta();

            VacantaD.Vacante = await _context.Vacanta
            .Include(b => b.Ghid)
            .Include(b => b.CategoriiVacanta)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Tara)
            .ToListAsync();
            if (id != null)
            {
                VacantaID = id.Value;
                Vacanta vacanta = VacantaD.Vacante
                .Where(i => i.ID == id.Value).Single();
                VacantaD.Categorii = vacanta.CategoriiVacanta.Select(s => s.Categorie);
            }
            IQueryable<string> genreQuery = from m in _context.Vacanta
                                            orderby m.Categorie
                                            select m.Categorie;

            var vacante = from m in _context.Vacanta
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                vacante = vacante.Where(s => s.Tara.Contains(SearchString));
            }
            
            if (!string.IsNullOrEmpty(CategorieVacanta))
            {
                vacante = vacante.Where(x => x.Categorie == CategorieVacanta);
            }
            Categorie = new SelectList(await genreQuery.Distinct().ToListAsync());
            Vacanta = await vacante.ToListAsync();
           
        }
    }
}
