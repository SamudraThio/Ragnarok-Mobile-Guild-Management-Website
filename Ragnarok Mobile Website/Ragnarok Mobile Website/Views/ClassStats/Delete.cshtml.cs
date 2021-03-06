﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ragnarok_Mobile_Website.Data;
using Ragnarok_Mobile_Website.Models;

namespace Ragnarok_Mobile_Website.Views.ClassStats
{
    public class DeleteModel : PageModel
    {
        private readonly Ragnarok_Mobile_Website.Data.PlayerContext _context;

        public DeleteModel(Ragnarok_Mobile_Website.Data.PlayerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClassStat ClassStat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassStat = await _context.ClassStats.FirstOrDefaultAsync(m => m.ClassID == id);

            if (ClassStat == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClassStat = await _context.ClassStats.FindAsync(id);

            if (ClassStat != null)
            {
                _context.ClassStats.Remove(ClassStat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
