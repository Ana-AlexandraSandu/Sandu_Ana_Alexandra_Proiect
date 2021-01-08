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

namespace Sandu_Ana_Alexandra_Proiect.Pages.Ghizi
{
    public class EditModel : PageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public EditModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ghid Ghid { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ghid = await _context.Ghid.FirstOrDefaultAsync(m => m.ID == id);

            if (Ghid == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ghid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GhidExists(Ghid.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GhidExists(int id)
        {
            return _context.Ghid.Any(e => e.ID == id);
        }
    }
}
