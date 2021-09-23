using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LCARS.Core;
using LCARS.Core.Data.Crew;

namespace LCARS.Interfaces.Console.Desk.Pages.Officers
{
    public class IndexModel : PageModel
    {
        private readonly LcarsDatabase _context;

        public IndexModel(LcarsDatabase context)
        {
            _context = context;
        }

        public IList<Officer> Officer { get;set; }

        public async Task OnGetAsync()
        {
            Officer = await _context.Officers.ToListAsync();
        }
    }
}
