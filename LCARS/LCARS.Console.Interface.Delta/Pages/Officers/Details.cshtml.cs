﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LCARS.Core;
using LCARS.Core.Data.Crew;

namespace LCARS.Console.Interface.Delta.Pages.Officers
{
    public class DetailsModel : PageModel
    {
        private readonly LcarsDatabase _context;

        public DetailsModel(LcarsDatabase context)
        {
            _context = context;
        }

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
    }
}
