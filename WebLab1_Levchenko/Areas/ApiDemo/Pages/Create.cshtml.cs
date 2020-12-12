using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Areas.ApiDemo.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebLab1_Levchenko.DAL.Data.ApplicationDbContext _context;

        public CreateModel(WebLab1_Levchenko.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CatsGroupID"] = new SelectList(_context.CatsGroups, "CatsGroupID", "CatsGroupID");
            return Page();
        }

        [BindProperty]
        public Cats Cats { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cats.Add(Cats);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
