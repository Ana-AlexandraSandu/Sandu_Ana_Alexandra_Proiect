using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sandu_Ana_Alexandra_Proiect.Data;
using Sandu_Ana_Alexandra_Proiect.Models;

namespace Sandu_Ana_Alexandra_Proiect.Pages.Vacante
{
    public class EditModel : VacantaCategoriesPageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public EditModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vacanta Vacanta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vacanta = await _context.Vacanta.Include(b => b.Ghid).Include(b => b.CategoriiVacanta).ThenInclude(b => b.Categorie).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);


            if (Vacanta == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Vacanta);

            ViewData["GhidID"] = new SelectList(_context.Set<Ghid>(), "ID", "NumeGhid");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }
                var vacantaToUpdate = await _context.Vacanta
                //.Include(i => i.Ghid)
                .Include(i => i.CategoriiVacanta)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);
                if (vacantaToUpdate == null)
                {
                    return NotFound();
                }
                if (await TryUpdateModelAsync<Vacanta>(
                vacantaToUpdate,
                "Vacanta",
                i => i.Tara, i=> i.Ghid, i => i.Categorie,
                i => i.Pret, i => i.Dataplecare, i => i.Datasosire, i=> i.GhidID))
                {
                    UpdateVacantaCategories(_context, selectedCategories, vacantaToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                //Apelam UpdateVacantaCategories pentru a aplica informatiile din checkboxuri la entitatea Vacanta care
                //este editata
                UpdateVacantaCategories(_context, selectedCategories, vacantaToUpdate);
                PopulateAssignedCategoryData(_context, vacantaToUpdate);
                return Page();
            }
        }
    }
}

