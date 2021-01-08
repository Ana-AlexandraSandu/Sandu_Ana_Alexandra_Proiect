using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sandu_Ana_Alexandra_Proiect.Data;
using Sandu_Ana_Alexandra_Proiect.Models;

namespace Sandu_Ana_Alexandra_Proiect.Pages.Ghizi
{
    public class IndexModel : PageModel
    {
        private readonly Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext _context;

        public IndexModel(Sandu_Ana_Alexandra_Proiect.Data.Sandu_Ana_Alexandra_ProiectContext context)
        {
            _context = context;
        }

        public IList<Ghid> Ghid { get;set; }

        public async Task OnGetAsync()
        {
            Ghid = await _context.Ghid.ToListAsync();
        }
    }
}
