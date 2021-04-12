using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LCARS.Core;
using LCARS.Core.Data.Crew;

namespace LCARS.Interfaces.Console.Desk.Pages.Officers
{
    public class CreateModel : PageModel
    {
        private readonly Databank _context;

        public CreateModel(Databank context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Officer Officer { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Officers.Add(Officer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
