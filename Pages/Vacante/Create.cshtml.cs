using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sandu_Ana_Alexandra_Proiect.Data;
using Sandu_Ana_Alexandra_Proiect.Models;

namespace Sandu_Ana_Alexandra_Proiect.Pages.Vacante
{
    public class CreateModel : VacantaCategoriesPageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public CreateModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["GhidID"] = new SelectList(_context.Set<Ghid>(), "ID", "NumeGhid");
            var vacanta = new Vacanta();
            vacanta.CategoriiVacanta = new List<CategorieVacanta>();
            PopulateAssignedCategoryData(_context, vacanta);

            return Page();
        }

        [BindProperty]
        public Vacanta Vacanta { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newVacanta = new Vacanta();
            if (selectedCategories != null)
            {
                newVacanta.CategoriiVacanta = new List<CategorieVacanta>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieVacanta
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newVacanta.CategoriiVacanta.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Vacanta>(
            newVacanta,
            "Vacanta",
            i => i.Tara, i => i.Categorie,
            i => i.Pret, i => i.Dataplecare, i => i.Datasosire, i => i.GhidID))
            {
                _context.Vacanta.Add(newVacanta);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newVacanta);
            return Page();
        }
    }
}
