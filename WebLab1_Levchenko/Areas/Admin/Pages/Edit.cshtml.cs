using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLab1_Levchenko.DAL.Data;
using WebLab1_Levchenko.DAL.Entities;

namespace WebLab1_Levchenko.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebLab1_Levchenko.DAL.Data.ApplicationDbContext _context;

        private IWebHostEnvironment _environment;

        public EditModel(ApplicationDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;

        }

        [BindProperty]
        public Cats Cats { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

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
           ViewData["CatsGroupID"] = new SelectList(_context.CatsGroups, "CatsGroupID", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }   
            _context.Attach(Cats).State = EntityState.Modified;

            if (Image != null)
            {
                var fileName = $"{Cats.CatsID}" +
                Path.GetExtension(Image.FileName);
                Cats.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatsExists(Cats.CatsID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatsExists(int id)
        {
            return _context.Cats.Any(e => e.CatsID == id);
        }
    }
}
