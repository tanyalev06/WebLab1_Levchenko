using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Areas.ApiDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebLab1_Levchenko.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WebLab1_Levchenko.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cats> Cats { get;set; }

        public async Task OnGetAsync()
        {
            Cats = await _context.Cats
                .Include(c => c.Group).ToListAsync();
        }
    }
}
