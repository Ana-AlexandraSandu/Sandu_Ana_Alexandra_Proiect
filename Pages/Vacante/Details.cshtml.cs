using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sandu_Ana_Alexandra_Proiect.Data;
using Sandu_Ana_Alexandra_Proiect.Models;

namespace Sandu_Ana_Alexandra_Proiect.Pages.Vacante
{
    public class DetailsModel : PageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public DetailsModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public Vacanta Vacanta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vacanta = await _context.Vacanta.FirstOrDefaultAsync(m => m.ID == id);

            if (Vacanta == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
