﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Areas.Admin.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebLab1_Levchenko.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WebLab1_Levchenko.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cats Cats { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cats = await _context.Cats
                .Include(c => c.Group).FirstOrDefaultAsync(m => m.CatsID == id);

            if (Cats == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
