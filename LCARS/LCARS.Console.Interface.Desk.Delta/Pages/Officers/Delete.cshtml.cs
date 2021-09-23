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
    public class DeleteModel : PageModel
    {
        private readonly LcarsDatabase _context;

        public DeleteModel(LcarsDatabase context)
        {
            _context = context;
        }

        [BindProperty]
        public Officer Officer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Officer = await _context.Officers.FirstOrDefaultAsync(m => m.SerialNo == id);

            if (Officer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Officer = await _context.Officers.FindAsync(id);

            if (Officer != null)
            {
                _context.Officers.Remove(Officer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
