﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ragnarok_Mobile_Website.Data;
using Ragnarok_Mobile_Website.Models;

namespace Ragnarok_Mobile_Website.Views.UserInfos
{
    public class DeleteModel : PageModel
    {
        private readonly Ragnarok_Mobile_Website.Data.PlayerContext _context;

        public DeleteModel(Ragnarok_Mobile_Website.Data.PlayerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserInfo UserInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserInfo = await _context.UserInfos.FirstOrDefaultAsync(m => m.UserID == id);

            if (UserInfo == null)
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

            UserInfo = await _context.UserInfos.FindAsync(id);

            if (UserInfo != null)
            {
                _context.UserInfos.Remove(UserInfo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
